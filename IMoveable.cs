using System.Numerics;

namespace MineCad
{
    public interface IMoveable : IMineCadObject
    {
        void Move(Vector3 vector);
    }
}