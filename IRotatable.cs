using MineCad.Geometry.Primitives.Flat;

namespace MineCad
{
    public interface IRotatable : IMineCadObject
    {
        /* Поворот объекта против часовой стрелки на угол angle (измеряется в градусах) вокруг вектора vector. */
        void Rotate(float angle, Point vector);
    }
}