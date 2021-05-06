using System;
using System.Drawing;

namespace MineCad
{
    class Quadrangle:IPlane
    {
        private const float colorConversionConstant = byte.MaxValue;
        private Point[] points = { new Point(), new Point(), new Point(), new Point() };
        public object Clone() {
            return new Quadrangle();
        }

        public bool CheckPoints(in Point leftTop, in Point rigthTop, in Point rigthBottom)
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
        public void Draw(SharpGL.OpenGL gl, in Point leftTop, in Point rigthTop, in Point rigthBottom, Color color)
        {
            if (this.CheckPoints(leftTop, rigthTop, rigthBottom))
            {
                gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

                gl.Begin(SharpGL.OpenGL.GL_POLYGON);

                gl.Vertex(leftTop.X, leftTop.Y, leftTop.Z);
                gl.Vertex(rigthTop.X, rigthTop.Y, rigthTop.Z);
                gl.Vertex(rigthBottom.X, rigthBottom.Y, rigthBottom.Z);
                gl.Vertex(rigthBottom.X + leftTop.X - rigthTop.X,
                          leftTop.Y - rigthTop.Y + rigthBottom.Y,
                          rigthBottom.Z + leftTop.Z - rigthTop.Z);

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
    }
}
