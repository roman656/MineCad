using SharpGL;
using System.Drawing;

namespace MineCad.Geometry.Primitives.Flat
{
    public interface IFlat : IMineCadObject
    {
        void Draw(OpenGL gl, float width, Color color);
    }
}