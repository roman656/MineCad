using SharpGL;
using System;
using System.Drawing;

namespace MineCad.Geometry.Primitives.Flat
{
    public class Plane : IFlatShape
    {
        private Point center = new Point();
        private Point[] points = { new Point(-1.0f, 0.0f, -1.0f),
                                   new Point( 1.0f, 0.0f, -1.0f),
                                   new Point( 1.0f, 0.0f,  1.0f),
                                   new Point(-1.0f, 0.0f,  1.0f) };

        /* 
         * Вычисляет значение 4й точки плоскости на основании первых трех. Значение 4й точки будет обновлено.
         * Обновится и центральная точка плоскости.
         */
        private void RecalculatePlane()
        {
            this.points[3].X = this.points[2].X + this.points[0].X - this.points[1].X;
            this.points[3].Y = this.points[0].Y - this.points[1].Y + this.points[2].Y;
            this.points[3].Z = this.points[2].Z + this.points[0].Z - this.points[1].Z;
            this.center = Line.GetCenter(this.points[0], this.points[2]);
        }

        public Plane() {}

        public Plane(in Point leftTop, in Point rigthTop, in Point rigthBottom)
        {
            /* Если все 3 точки лежат на 1й прямой. */
            if (Utility.Math.CheckHasLineThisPoint(new Line(leftTop, rigthTop), rigthBottom))
            {
                throw new ArgumentException("Impossible to create a plane based on this points.");
            }

            this.points[0] = (Point)leftTop.Clone();
            this.points[1] = (Point)rigthTop.Clone();
            this.points[2] = (Point)rigthBottom.Clone();

            RecalculatePlane();
        }

        public Point LeftTop
        {
            get
            {
                return (Point)this.points[0].Clone();
            }

            set
            {
                if (Utility.Math.CheckHasLineThisPoint(new Line(value, this.points[1]), this.points[2]))
                {
                    throw new ArgumentException("Impossible to modify the plane: the new plane is undefined.");
                }

                this.points[0] = (Point)value.Clone();
                RecalculatePlane();
            }
        }

        public Point RightTop
        {
            get
            {
                return (Point)this.points[1].Clone();
            }

            set
            {
                if (Utility.Math.CheckHasLineThisPoint(new Line(this.points[0], value), this.points[2]))
                {
                    throw new ArgumentException("Impossible to modify the plane: the new plane is undefined.");
                }

                this.points[1] = (Point)value.Clone();
                RecalculatePlane();
            }
        }

        public Point RightBottom
        {
            get
            {
                return (Point)this.points[2].Clone();
            }

            set
            {
                if (Utility.Math.CheckHasLineThisPoint(new Line(this.points[0], this.points[1]), value))
                {
                    throw new ArgumentException("Impossible to modify the plane: the new plane is undefined.");
                }

                this.points[2] = (Point)value.Clone();
                RecalculatePlane();
            }
        }

        /* Для 4й точки нет сеттера, так как она зависит от остальных трех. */
        public Point LeftBottom
        {
            get
            {
                return (Point)this.points[3].Clone();
            }
        }

        public Point[] Points
        {
            get
            {
                Point[] output = { (Point)this.points[0].Clone(),
                                   (Point)this.points[1].Clone(),
                                   (Point)this.points[2].Clone(),
                                   (Point)this.points[3].Clone() };
                return output;
            }
        }

        public Point Center
        {
            get
            {
                return (Point)this.center.Clone();
            }
        }

        public void Draw(OpenGL gl, float width, Color color)
        {
            gl.LineWidth(width);

            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_LINE_LOOP);

            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[1].X, this.points[1].Y, this.points[1].Z);
            gl.Vertex(this.points[2].X, this.points[2].Y, this.points[2].Z);
            gl.Vertex(this.points[3].X, this.points[3].Y, this.points[3].Z);

            gl.End();
        }

        public void DrawArea(OpenGL gl, Color color)
        {
            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_QUADS);

            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[1].X, this.points[1].Y, this.points[1].Z);
            gl.Vertex(this.points[2].X, this.points[2].Y, this.points[2].Z);
            gl.Vertex(this.points[3].X, this.points[3].Y, this.points[3].Z);

            gl.End();
        }

        public object Clone()
        {
            return new Plane(this.points[0], this.points[1], this.points[2]);
        }
    }
}