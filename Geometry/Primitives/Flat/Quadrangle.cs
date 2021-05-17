using SharpGL;
using System;
using System.Drawing;

namespace MineCad.Geometry.Primitives.Flat
{
    public class Quadrangle : IFlat
    {
        private Point center = new Point();
        private Point[] points = { new Point(-1.0f, 0.0f, -1.0f),
                                   new Point( 1.0f, 0.0f, -1.0f),
                                   new Point( 1.0f, 0.0f,  1.0f),
                                   new Point(-1.0f, 0.0f,  1.0f) };

        /*
         * Проверяет, существует ли четырехугольник при данных точках.
         * Возвращает: true - четырехугольник существует; false - в противном случае.
         */
        private bool CheckPoints(in Point leftTop, in Point rigthTop, in Point rigthBottom, in Point leftBottom)
        {
            bool result = true;

            /* Вектора по координатам точек (хранятся в Point ради удобства). */
            Point AB = new Point(rigthTop.X - leftTop.X, rigthTop.Y - leftTop.Y, rigthTop.Z - leftTop.Z);
            Point BC = new Point(rigthBottom.X - rigthTop.X, rigthBottom.Y - rigthTop.Y, rigthBottom.Z - rigthTop.Z);
            Point CD = new Point(leftBottom.X - rigthBottom.X, leftBottom.Y - rigthBottom.Y, leftBottom.Z - rigthBottom.Z);
            
            result = result && Utility.Math.CheckVectorsCoplanarity(AB, BC, CD);
            result = result && (Utility.Math.CheckHasLineThisPoint(new Line(leftTop, rigthTop), rigthBottom) == false);
            result = result && (Utility.Math.CheckHasLineThisPoint(new Line(rigthTop, rigthBottom), leftBottom) == false);
            result = result && (Utility.Math.CheckHasLineThisPoint(new Line(rigthBottom, leftBottom), leftTop) == false);
            result = result && (Utility.Math.CheckHasLineThisPoint(new Line(leftBottom, leftTop), rigthTop) == false);

            return result;
        }

        private void RecalculateCenter()
        {
            Point tempCenter1 = Line.GetCenter(this.points[0], this.points[2]);
            Point tempCenter2 = Line.GetCenter(this.points[1], this.points[3]);
            this.center = Line.GetCenter(tempCenter1, tempCenter2);
        }

        public Quadrangle() {}

        public Quadrangle(in Point leftTop, in Point rigthTop, in Point rigthBottom, in Point leftBottom)
        {
            if (CheckPoints(leftTop, rigthTop, rigthBottom, leftBottom) == false)
            {
                throw new ArgumentException("Impossible to create a quadrangle based on this points.");
            }

            this.points[0] = (Point)leftTop.Clone();
            this.points[1] = (Point)rigthTop.Clone();
            this.points[2] = (Point)rigthBottom.Clone();
            this.points[3] = (Point)leftBottom.Clone();
            RecalculateCenter();
        }

        public Point LeftTop
        {
            get
            {
                return (Point)this.points[0].Clone();
            }

            set
            {
                if (CheckPoints(value, this.points[1], this.points[2], this.points[3]) == false)
                {
                    throw new ArgumentException("Impossible to modify the quadrangle: the new quadrangle is undefined.");
                }

                this.points[0] = (Point)value.Clone();
                RecalculateCenter();
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
                if (CheckPoints(this.points[0], value, this.points[2], this.points[3]) == false)
                {
                    throw new ArgumentException("Impossible to modify the quadrangle: the new quadrangle is undefined.");
                }

                this.points[1] = (Point)value.Clone();
                RecalculateCenter();
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
                if (CheckPoints(this.points[0], this.points[1], value, this.points[3]) == false)
                {
                    throw new ArgumentException("Impossible to modify the quadrangle: the new quadrangle is undefined.");
                }

                this.points[2] = (Point)value.Clone();
                RecalculateCenter();
            }
        }

        public Point LeftBottom
        {
            get
            {
                return (Point)this.points[3].Clone();
            }

            set
            {
                if (CheckPoints(this.points[0], this.points[1], this.points[2], value) == false)
                {
                    throw new ArgumentException("Impossible to modify the quadrangle: the new quadrangle is undefined.");
                }

                this.points[3] = (Point)value.Clone();
                RecalculateCenter();
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
            return new Quadrangle(this.points[0], this.points[1], this.points[2], this.points[3]);
        }
    }
}