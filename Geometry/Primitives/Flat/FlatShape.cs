using SharpGL;
using System.Drawing;
using System.Numerics;

namespace MineCad.Geometry.Primitives.Flat
{
    public abstract class FlatShape : IFlatShape
    {
        protected Color color;
        protected Color areaColor;
        protected float width;
        protected Pivot pivot;

        public abstract object Clone();
        public abstract void Draw(OpenGL gl);
        public abstract void DrawArea(OpenGL gl);
        public abstract void Move(Vector3 vector);
        public abstract void Rotate(float angle, Vector3 vector);
        public abstract void Scale(Vector3 scale);
    }
}