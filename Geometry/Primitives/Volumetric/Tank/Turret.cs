using MineCad.Geometry.Primitives.Flat;
using SharpGL;
using System;
using System.Drawing;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad
{
    class Turret : ICloneable, IMineCadObject
    {
        private Point center = new Point();
        private Point direction = new Point(1.0f, 0.0f, 0.0f);
        private Plane[] turret = { new Plane(new Point(3, 3.5f, 1.5f), new Point(3, 3.5f, -1.5f), new Point(3.3f, 2, -1.5f)),
                                   new Plane(new Point(-2, 3.5f, -1.5f), new Point(-2, 3.5f, 1.5f), new Point(-1.7f, 2, 1.5f)),
                                   new Plane(new Point(-2, 3.5f, 1.5f), new Point(-2, 3.5f, -1.5f), new Point(3, 3.5f, -1.5f)),
                                   new Plane(new Point(-2, 3.5f, 1.5f), new Point(3, 3.5f, 1.5f), new Point(3.3f, 2, 1.5f)),
                                   new Plane(new Point(-2, 3.5f, -1.5f), new Point(3, 3.5f, -1.5f), new Point(3.3f, 2, -1.5f)) };

        public Turret() { }

        public Turret(in Point center)
        {
            this.center = (Point)center.Clone();
        }

        public void Draw(OpenGL gl, Color gunColor, Color turretColor)
        {
            gl.Translate(this.center.X * this.direction.X, this.center.Y * this.direction.Y, this.center.Z * this.direction.Z);

            foreach (var temp in this.turret)
            {
                temp.Draw(gl, turretColor);
                temp.DrawOutline(gl, 3, Color.YellowGreen);
            }

            gl.Translate(2.5f, 2.7f, 0);
            gl.Rotate(-90.0f, 0.0f, 0.0f, 1.0f);

            GLDrawHelper.DrawCylinder(gl, 6.0f, 0.1f, 0.1f, 12, gunColor, Color.YellowGreen);

            gl.Rotate(90.0f, 0.0f, 0.0f, 1.0f);
            gl.Translate(-2.5f, -2.7f, 0);

            gl.Translate(-this.center.X * this.direction.X, -this.center.Y * this.direction.Y, -this.center.Z * this.direction.Z);
        }

        public object Clone()
        {
            return new Turret();
        }
    }
}