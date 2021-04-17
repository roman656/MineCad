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

        public object Clone()
        {
            return new Point(this.x, this.y, this.z);
        }
    }
}
