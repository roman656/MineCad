using System;
using System.Drawing;

namespace MineCad
{
    class Quadrangle:IPlane
    {
        private const float colorConversionConstant = byte.MaxValue;
        private Point[] points;


        public Quadrangle(Point[] points)
        {
            if (this.CheckPoints(points))
            {
                this.points = points;
            }
            else
            {
                this.points = null;
            }
        }

        public bool CheckPoints(in Point[] points)
        {
            if (points.Length != 4){
                return false;
            }

            Point AB = new Point(
                points[0].X - points[1].X, points[0].Y - points[1].Y, points[0].Z - points[1].Z
            );

            Point CD = new Point(
                points[2].X - points[3].X, points[2].Y - points[3].Y, points[2].Z - points[3].Z
            );

            Point BC = new Point(
                points[1].X - points[2].X, points[1].Y - points[2].Y, points[1].Z - points[2].Z
            );

            ///<coplanarity>
            ///
            /// 
            ///     | AB.X AB.Y AB.Z|     
            ///  det| BC.X BC.Y BC.Z| = 0
            ///     | CD.X CD.Y CD.Z| 
            /// 
            ///   </ coplanarity>

            float det = AB.X * (BC.Y * CD.Z - CD.Y * BC.Z) - AB.Y * (BC.X * CD.Z - BC.Z* CD.X) + AB.Z * (BC.X * CD.Y - BC.Y * CD.X);

            return det == 0.0f;
        }

        public void Draw(SharpGL.OpenGL gl, Point[] points, Color color)
        {
            if (this.CheckPoints(points))
            {
                gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

                gl.Begin(SharpGL.OpenGL.GL_POLYGON);

               foreach(Point p in points)
                {
                    gl.Vertex(p.X, p.Y, p.Z);
                }

                gl.End();
            }
        }

        public void Draw(SharpGL.OpenGL gl, Color color)
        {
            /* Установка цвета плоскости. */
            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);

            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[1].X, this.points[1].Y, this.points[1].Z);
            gl.Vertex(this.points[2].X, this.points[2].Y, this.points[2].Z);
            gl.Vertex(this.points[3].X, this.points[3].Y, this.points[3].Z);

            gl.End();
        }

        public object Clone()
        {
            return new Quadrangle(this.points);
        }
    }
}
