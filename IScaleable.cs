using System.Numerics;

namespace MineCad
{
    public interface IScaleable : IMineCadObject
    {
        void Scale(Vector3 scale);
    }
}