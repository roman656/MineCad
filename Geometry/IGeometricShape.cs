using SharpGL;

namespace MineCad.Geometry
{
    public interface IGeometricShape : IMoveable, IRotatable, IScaleable
    {
        void Draw(OpenGL gl);
        void DrawArea(OpenGL gl);
    }
}