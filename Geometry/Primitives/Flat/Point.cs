using SharpGL;
using System;
using System.Drawing;

namespace MineCad.Geometry.Primitives.Flat
{
    public class Point : IFlat
    {
        private float x = 0.0f;
        private float y = 0.0f;
        private float z = 0.0f;

        public Point() {}

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
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
                throw new ArgumentException("The radius cannot be negative.");
            }

            /* Нормализация углов. */
            theta = Utility.Math.ConstrainAngle180Degrees(theta);
            phi = Utility.Math.ConstrainAngle360Degrees(phi);

            theta = Utility.Math.ConvertDegreesToRadians(theta);
            phi = Utility.Math.ConvertDegreesToRadians(phi);

            /* Переход к декартовым координатам. */
            this.x = (float)(radius * Math.Sin(theta) * Math.Cos(phi));
            this.y = (float)(radius * Math.Cos(theta));
            this.z = (float)(radius * Math.Sin(theta) * Math.Sin(phi));
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

        public double Abs
        {
            get
            {
                return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            }
        }

        public void Draw(OpenGL gl, float size, Color color)
        {
            gl.PointSize(size);

            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_POINTS);

            gl.Vertex(this.x, this.y, this.z);

            gl.End();
        }

        public static void Draw(OpenGL gl, float x, float y, float z, float size, Color color)
        {
            gl.PointSize(size);

            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_POINTS);

            gl.Vertex(x, y, z);

            gl.End();
        }

        public static void Draw(OpenGL gl, float radius, double theta, double phi, float size, Color color)
        {
            if (radius < 0.0f)
            {
                throw new ArgumentException("The radius cannot be negative.");
            }

            /* Нормализация углов. */
            theta = Utility.Math.ConstrainAngle180Degrees(theta);
            phi = Utility.Math.ConstrainAngle360Degrees(phi);

            theta = Utility.Math.ConvertDegreesToRadians(theta);
            phi = Utility.Math.ConvertDegreesToRadians(phi);

            gl.PointSize(size);

            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_POINTS);

            gl.Vertex((float)(radius * Math.Sin(theta) * Math.Cos(phi)),
                      (float)(radius * Math.Cos(theta)),
                      (float)(radius * Math.Sin(theta) * Math.Sin(phi)));

            gl.End();
        }

        public object Clone()
        {
            return new Point(this.x, this.y, this.z);
        }
    }
}