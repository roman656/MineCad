using SharpGL;
using System;
using System.Drawing;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad.Geometry.Primitives.Volumetric.Cannons
{
    public class Cannon : ICannon
    {
        private Point center = new Point();
        private Cone model = new Cone(new Point(), 0.152f, 0.152f, 6.0f, 10);

        public Cannon() {}

        public void Draw(OpenGL gl, float width, Color color)
        {
            this.model.Draw(gl, width, color);
        }

        public void DrawArea(OpenGL gl, Color color)
        {
            this.model.DrawArea(gl, color);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
