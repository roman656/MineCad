using System;
using System.Drawing;

namespace MineCad
{
    class Line : ICloneable
    {
        /* 
         * Константа, необходимая для конвертации RGB цвета [0; 255]
         * в RGB цвет [0.0f; 1.0f].
         */
        private const float colorConversionConstant = byte.MaxValue;
        private Point begin;
        private Point end;

        public Line(in Point begin, in Point end)
        {
            this.begin = (Point)begin.Clone();
            this.end = (Point)end.Clone();
        }

        public Line(float beginX, float beginY, float beginZ, float endX, float endY, float endZ)
        {
            this.begin = new Point(beginX, beginY, beginZ);
            this.end = new Point(endX, endY, endZ);
        }

        public Point Begin
        {
            get
            {
                return (Point)this.begin.Clone();
            }

            set
            {
                this.begin = (Point)value.Clone();
            }
        }

        public Point End
        {
            get
            {
                return (Point)this.end.Clone();
            }

            set
            {
                this.end = (Point)value.Clone();
            }
        }

        public void Draw(SharpGL.OpenGL gl, float width, Color color)
        {
            /* Установка толщины линии. */
            gl.LineWidth(width);

            /* Установка цвета линии. */
            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_LINES);

            gl.Vertex(this.begin.X, this.begin.Y, this.begin.Z);
            gl.Vertex(this.end.X, this.end.Y, this.end.Z);

            gl.End();
        }

        public static void Draw(SharpGL.OpenGL gl, in Point begin, in Point end, float width, Color color)
        {
            gl.LineWidth(width);

            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_LINES);

            gl.Vertex(begin.X, begin.Y, begin.Z);
            gl.Vertex(end.X, end.Y, end.Z);

            gl.End();
        }

        public static void Draw(SharpGL.OpenGL gl, float beginX, float beginY, float beginZ,
                                                   float endX, float endY, float endZ,
                                                   float width, Color color)
        {
            gl.LineWidth(width);

            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_LINES);

            gl.Vertex(beginX, beginY, beginZ);
            gl.Vertex(endX, endY, endZ);

            gl.End();
        }

        public object Clone()
        {
            return new Line(this.begin, this.end);
        }
    }
}
