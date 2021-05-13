using System;
using System.Drawing;

namespace MineCad.Geometry.Primitives.Flat
{
    public class Plane : ICloneable
    {
        /* 
         * Константа, необходимая для конвертации RGB цвета [0; 255]
         * в RGB цвет [0.0f; 1.0f].
         */
        private const float colorConversionConstant = byte.MaxValue;
        private Point[] points = { new Point(), new Point(), new Point(), new Point() };

        /* Вычисляет значение 4й точки плоскости на основании первых трех. Значение 4й точки будет обновлено. */
        private void RecalculatePlane()
        {
            this.points[3].X = this.points[2].X + this.points[0].X - this.points[1].X;
            this.points[3].Y = this.points[0].Y - this.points[1].Y + this.points[2].Y;
            this.points[3].Z = this.points[2].Z + this.points[0].Z - this.points[1].Z;
        }

        /* 
         * Проверяет, не находятся ли все 3 точки на одной прямой: в таком случае плоскость построить не удастся.
         * Возвращает: true - точки валидны; false - построить плоскость нельзя.
         */
        private static bool CheckPoints(in Point leftTop, in Point rigthTop, in Point rigthBottom)
        {
            /* Вектора по координатам точек (хранятся в Point ради удобства). */
            Point AB = new Point(rigthTop.X - leftTop.X, rigthTop.Y - leftTop.Y, rigthTop.Z - leftTop.Z);
            Point AC = new Point(rigthBottom.X - leftTop.X, rigthBottom.Y - leftTop.Y, rigthBottom.Z - leftTop.Z);

            /* Векторное произведение AB и AC. */
            Point C = new Point(AB.Y * AC.Z - AB.Z * AC.Y, -1.0f * (AB.X * AC.Z - AB.Z * AC.X), AB.X * AC.Y - AB.Y * AC.X);

            /* Модуль вектора C. */
            double modC = Math.Sqrt(C.X * C.X + C.Y * C.Y + C.Z * C.Z);

            /* Площадь треугольника (по данным точкам). */
            double S = modC / 2.0f;

            /* Если площадь образуемого этими точками треугольника не равна 0, то они не на 1й прямой. */
            return (S != 0.0f) ? true : false;
        }

        public Plane()
        {
            this.points[0].X = -1.0f;
            this.points[0].Z = -1.0f;

            this.points[1].X = 1.0f;
            this.points[1].Z = -1.0f;

            this.points[2].X = 1.0f;
            this.points[2].Z = 1.0f;

            this.points[3].X = -1.0f;
            this.points[3].Z = 1.0f;
        }

        public Plane(in Point leftTop, in Point rigthTop, in Point rigthBottom)
        {
            /* Если по заданным точкам построить плоскость нельзя, то строим плоскость по умолчанию. */
            if (CheckPoints(leftTop, rigthTop, rigthBottom))
            {
                this.points[0] = (Point)leftTop.Clone();
                this.points[1] = (Point)rigthTop.Clone();
                this.points[2] = (Point)rigthBottom.Clone();

                RecalculatePlane();
            }
            else
            {
                this.points[0].X = -1.0f;
                this.points[0].Z = -1.0f;

                this.points[1].X = 1.0f;
                this.points[1].Z = -1.0f;

                this.points[2].X = 1.0f;
                this.points[2].Z = 1.0f;

                this.points[3].X = -1.0f;
                this.points[3].Z = 1.0f;
            }
        }

        public Point LeftTop
        {
            get
            {
                return (Point)this.points[0].Clone();
            }

            set
            {
                if (CheckPoints(value, this.points[1], this.points[2]))
                {
                    this.points[0] = (Point)value.Clone();
                    RecalculatePlane();
                }
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
                if (CheckPoints(this.points[0], value, this.points[2]))
                {
                    this.points[1] = (Point)value.Clone();
                    RecalculatePlane();
                }
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
                if (CheckPoints(this.points[0], this.points[1], value))
                {
                    this.points[2] = (Point)value.Clone();
                    RecalculatePlane();
                }
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

        public Point Center
        {
            get
            {
                return Line.GetCenter(this.points[0], this.points[2]);
            }
        }

        public void DrawOutline(SharpGL.OpenGL gl, float width, Color color)
        {
            gl.LineWidth(width);

            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);

            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[1].X, this.points[1].Y, this.points[1].Z);
            gl.Vertex(this.points[2].X, this.points[2].Y, this.points[2].Z);
            gl.Vertex(this.points[3].X, this.points[3].Y, this.points[3].Z);

            gl.End();
        }

        public void Draw(SharpGL.OpenGL gl, Color color)
        {
            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(SharpGL.OpenGL.GL_QUADS);

            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[1].X, this.points[1].Y, this.points[1].Z);
            gl.Vertex(this.points[2].X, this.points[2].Y, this.points[2].Z);
            gl.Vertex(this.points[3].X, this.points[3].Y, this.points[3].Z);

            gl.End();
        }

        public static void DrawOutline(SharpGL.OpenGL gl, in Point leftTop, in Point rigthTop, in Point rigthBottom, float width, Color color)
        {
            if (CheckPoints(leftTop, rigthTop, rigthBottom))
            {
                gl.LineWidth(width);

                gl.Color(color.R, color.G, color.B, color.A);

                gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);

                gl.Vertex(leftTop.X, leftTop.Y, leftTop.Z);
                gl.Vertex(rigthTop.X, rigthTop.Y, rigthTop.Z);
                gl.Vertex(rigthBottom.X, rigthBottom.Y, rigthBottom.Z);
                gl.Vertex(rigthBottom.X + leftTop.X - rigthTop.X,
                          leftTop.Y - rigthTop.Y + rigthBottom.Y,
                          rigthBottom.Z + leftTop.Z - rigthTop.Z);

                gl.End();
            }
        }

        public static void Draw(SharpGL.OpenGL gl, in Point leftTop, in Point rigthTop, in Point rigthBottom, Color color)
        {
            if (CheckPoints(leftTop, rigthTop, rigthBottom))
            {
                gl.Color(color.R, color.G, color.B, color.A);

                gl.Begin(SharpGL.OpenGL.GL_QUADS);

                gl.Vertex(leftTop.X, leftTop.Y, leftTop.Z);
                gl.Vertex(rigthTop.X, rigthTop.Y, rigthTop.Z);
                gl.Vertex(rigthBottom.X, rigthBottom.Y, rigthBottom.Z);
                gl.Vertex(rigthBottom.X + leftTop.X - rigthTop.X,
                          leftTop.Y - rigthTop.Y + rigthBottom.Y,
                          rigthBottom.Z + leftTop.Z - rigthTop.Z);

                gl.End();
            }
        }

        public static Point GetCenter(in Point leftTop, in Point rigthTop, in Point rigthBottom)
        {
            /* Если по заданным точкам построить плоскость нельзя, то возвращается нулевая точка (TODO: исключение). */
            if (CheckPoints(leftTop, rigthTop, rigthBottom))
            {
                return Line.GetCenter(leftTop, rigthBottom);
            }
            else
            {
                return new Point();
            }
        }

        public object Clone()
        {
            return new Plane(this.points[0], this.points[1], this.points[2]);
        }
    }
}