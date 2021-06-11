using System.Numerics;

namespace MineCad
{
    public interface IRotatable : IMineCadObject
    {
        /* Поворот объекта против часовой стрелки на угол angle (измеряется в градусах) вокруг вектора vector. */
        void Rotate(float angle, Vector3 vector);
    }
}