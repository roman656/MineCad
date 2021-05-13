using SharpGL;
using System.Drawing;

namespace MineCad.Geometry.Primitives.Flat
{
    public class Line : IFlat
    {
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

        public Point Center
        {
            get
            {
                return new Point((this.begin.X + this.end.X) / 2.0f,
                                 (this.begin.Y + this.end.Y) / 2.0f,
                                 (this.begin.Z + this.end.Z) / 2.0f);
            }
        }

        public void Draw(OpenGL gl, float width, Color color)
        {
            gl.LineWidth(width);

            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(this.begin.X, this.begin.Y, this.begin.Z);
            gl.Vertex(this.end.X, this.end.Y, this.end.Z);

            gl.End();
        }

        public static void Draw(OpenGL gl, in Point begin, in Point end, float width, Color color)
        {
            gl.LineWidth(width);

            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(begin.X, begin.Y, begin.Z);
            gl.Vertex(end.X, end.Y, end.Z);

            gl.End();
        }

        public static void Draw(OpenGL gl, float beginX, float beginY, float beginZ,
                float endX, float endY, float endZ, float width, Color color)
        {
            gl.LineWidth(width);

            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(beginX, beginY, beginZ);
            gl.Vertex(endX, endY, endZ);

            gl.End();
        }

        public static Point GetCenter(in Point begin, in Point end)
        {
            return new Point((begin.X + end.X) / 2.0f, (begin.Y + end.Y) / 2.0f, (begin.Z + end.Z) / 2.0f);
        }

        public static Point GetCenter(float beginX, float beginY, float beginZ, float endX, float endY, float endZ)
        {
            return new Point((beginX + endX) / 2.0f, (beginY + endY) / 2.0f, (beginZ + endZ) / 2.0f);
        }

        public object Clone()
        {
            return new Line(this.begin, this.end);
        }
    }
}