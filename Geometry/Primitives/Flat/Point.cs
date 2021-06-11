using SharpGL;
using System;
using System.Drawing;
using System.Numerics;

namespace MineCad.Geometry.Primitives.Flat
{
    public class Point : FlatShape
    {
        private Vector3 coordinates;

        public Point() 
        {
            this.coordinates = new Vector3(0.0f);
        }

        public Point(float x, float y)
        {
            this.coordinates = new Vector3(x, y, 0.0f);
        }

        public Point(float x, float y, float z)
        {
            this.coordinates = new Vector3(x, y, z);
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
            this.coordinates = new Vector3(
                    (float)(radius * Math.Sin(theta) * Math.Cos(phi)),
                    (float)(radius * Math.Cos(theta)),
                    (float)(radius * Math.Sin(theta) * Math.Sin(phi)));
        }

        public float X
        {
            get
            {
                return this.coordinates.X;
            }

            set
            {
                this.coordinates.X = value;
            }
        }

        public float Y
        {
            get
            {
                return this.coordinates.Y;
            }

            set
            {
                this.coordinates.Y = value;
            }
        }

        public float Z
        {
            get
            {
                return this.coordinates.Z;
            }

            set
            {
                this.coordinates.Z = value;
            }
        }

        public float Abs
        {
            get
            {
                return Vector3.Distance(new Vector3(0.0f), this.coordinates);
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

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Point temp = (Point)obj;
                return ((temp.X == this.x) && (temp.Y == this.y) && (temp.Z == this.z));
            }
        }

        public override int GetHashCode()
        {
            int hashCode = 373119288;

            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();

            return hashCode;
        }

        public object Clone()
        {
            return new Point(this.x, this.y, this.z);
        }

        public void Draw(OpenGL gl)
        {
            throw new NotImplementedException();
        }

        public void DrawArea(OpenGL gl)
        {
            throw new NotImplementedException();
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override void Draw(OpenGL gl)
        {
            throw new NotImplementedException();
        }

        public override void DrawArea(OpenGL gl)
        {
            throw new NotImplementedException();
        }
    }
}