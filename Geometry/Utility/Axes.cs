using MineCad.Geometry.Primitives.Flat;
using System.Drawing;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad
{
    class Axes : IMineCadObject
    {
        private Point center = new Point();
        private float size = 1.0f;

        public Axes() {}

        public Axes(in Point center, float size)
        {
            this.center = (Point)center.Clone();
            this.size = (size > 0.0f) ? size : 1.0f;
        }

        public Point Center
        {
            get
            {
                return (Point)this.center.Clone();
            }

            set
            {
                this.center = (Point)value.Clone();
            }
        }

        public float Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value > 0.0f)
                {
                    this.size = value;
                }
            }
        }

        public void Draw(SharpGL.OpenGL gl, float axisXWidth, float axisYWidth, float axisZWidth,
                Color axisXColor, Color axisYColor, Color axisZColor)
        {
            /* Ось OX. */
            Line.Draw(gl, this.center.X, this.center.Y, this.center.Z, this.center.X + this.size, this.center.Y, this.center.Z,
                    axisXWidth, axisXColor);

            /* Ось OY. */
            Line.Draw(gl, this.center.X, this.center.Y, this.center.Z, this.center.X, this.center.Y + this.size, this.center.Z,
                    axisYWidth, axisYColor);

            /* Ось OZ. */
            Line.Draw(gl, this.center.X, this.center.Y, this.center.Z, this.center.X, this.center.Y, this.center.Z + this.size,
                    axisZWidth, axisZColor);
        }

        public static void Draw(SharpGL.OpenGL gl, in Point center, float size, float axisXWidth, float axisYWidth, float axisZWidth,
                Color axisXColor, Color axisYColor, Color axisZColor)
        {
            /* Ось OX. */
            Line.Draw(gl, center.X, center.Y, center.Z, center.X + size, center.Y, center.Z, axisXWidth, axisXColor);

            /* Ось OY. */
            Line.Draw(gl, center.X, center.Y, center.Z, center.X, center.Y + size, center.Z, axisYWidth, axisYColor);

            /* Ось OZ. */
            Line.Draw(gl, center.X, center.Y, center.Z, center.X, center.Y, center.Z + size, axisZWidth, axisZColor);
        }

        public object Clone()
        {
            return new Axes(this.center, this.size);
        }
    }
}
