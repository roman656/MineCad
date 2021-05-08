using System;
using System.Drawing;

namespace MineCad
{
    class Point : ICloneable
    {
        /* 
         * Константа, необходимая для конвертации RGB цвета [0; 255]
         * в RGB цвет [0.0f; 1.0f].
         */
        private const float colorConversionConstant = byte.MaxValue;
        private float x;
        private float y;
        private float z;

        public Point()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.z = 0.0f;
        }

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0f;
        }

        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /* 
         * Сферические координаты. Углы в градусах.
         * theta - угол от оси Y до итогового радиуса, на конце которого расположена точка (уже с учетом доворота на phi). [0 ; 180]
         * phi - угол от оси X в плоскости XZ. [0 ; 360) 
         */
        public Point(float radius, double theta, double phi)
        {
            if (radius < 0.0f)
            {
                this.x = 0;
                this.y = 0;
                this.z = 0;
            }
            else
            {
                /* Нормализация углов. */
                if (theta < 0.0f || theta > 180.0f)
                {
                    theta = theta % 180.0f;

                    if (theta <= 0.0f)
                    {
                        theta += 180.0f;
                    }
                }

                phi = phi % 360.0f;

                if (phi < 0.0f)
                {
                    phi += 360.0f;
                }

                /* Перевод градусов в радианы. */
                theta = theta * Math.PI / 180.0f;
                phi = phi * Math.PI / 180.0f;

                /* Переход к декартовым координатам. */
                this.x = (float)(radius * Math.Sin(theta) * Math.Cos(phi));
                this.y = (float)(radius * Math.Cos(theta));
                this.z = (float)(radius * Math.Sin(theta) * Math.Sin(phi));
            }
        }

        public float X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public float Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public float Z
        {
            get
            {
                return this.z;
            }

            set
            {
                this.z = value;
            }
        }

        public void Draw(SharpGL.OpenGL gl, float size, Color color)
        {
            /* Установка размера точки. */
            gl.PointSize(size);

            /* Установка цвета точки. */
            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_POINTS);

            gl.Vertex(this.x, this.y, this.z);

            gl.End();
        }

        public static void Draw(SharpGL.OpenGL gl, float x, float y, float z, float size, Color color)
        {
            gl.PointSize(size);

            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_POINTS);

            gl.Vertex(x, y, z);

            gl.End();
        }

        public static void Draw(SharpGL.OpenGL gl, float radius, double theta, double phi, float size, Color color)
        {
            if (radius >= 0.0f)
            {
                /* Нормализация углов. */
                if (theta < 0.0f || theta > 180.0f)
                {
                    theta = theta % 180.0f;

                    if (theta <= 0.0f)
                    {
                        theta += 180.0f;
                    }
                }

                phi = phi % 360.0f;

                if (phi < 0.0f)
                {
                    phi += 360.0f;
                }

                /* Перевод градусов в радианы. */
                theta = theta * Math.PI / 180.0f;
                phi = phi * Math.PI / 180.0f;
            
                gl.PointSize(size);

                gl.Color(color.R / colorConversionConstant,
                         color.G / colorConversionConstant,
                         color.B / colorConversionConstant);

                gl.Begin(SharpGL.OpenGL.GL_POINTS);

                gl.Vertex((float)(radius * Math.Sin(theta) * Math.Cos(phi)),
                          (float)(radius * Math.Cos(theta)),
                          (float)(radius * Math.Sin(theta) * Math.Sin(phi)));

                gl.End();
            }
        }

        public object Clone()
        {
            return new Point(this.x, this.y, this.z);
        }
    }
}
