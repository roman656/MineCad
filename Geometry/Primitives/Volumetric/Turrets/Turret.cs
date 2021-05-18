using SharpGL;
using System.Drawing;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad.Geometry.Primitives.Volumetric.Turrets
{
    public class Turret : ITurret
    {
        private Point center = new Point();
        private Box model = new Box();

        public Turret() {}

        public Turret(in Point center, float sizeX, float sizeY, float sizeZ)
        {
            this.center = (Point)center.Clone();
            this.model = new Box(center, sizeX, sizeY, sizeZ);
        }

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
            return new Turret(this.center, this.model.SizeX, this.model.SizeY, this.model.SizeZ);
        }
    }
}