using System.Numerics;

namespace MineCad
{
    public class Pivot : IMoveable, IRotatable
    {
        private Vector3 center = new Vector3(0.0f);

        /* Вектора локального базиса - локальные координатные оси. */
        private Vector3 xAxis = new Vector3(1.0f, 0.0f, 0.0f);
        private Vector3 yAxis = new Vector3(0.0f, 1.0f, 0.0f);
        private Vector3 zAxis = new Vector3(0.0f, 0.0f, 1.0f);

        /* Матрица перевода в локальные координаты. */
        private Accord.Math.Matrix3x3 localCoordsMatrix;

        /* Матрица перевода в глобальные координаты. */
        private Accord.Math.Matrix3x3 globalCoordsMatrix;

        public Pivot()
        {
            this.localCoordsMatrix = new Accord.Math.Matrix3x3
            {
                V00 = this.xAxis.X,
                V01 = this.yAxis.X,
                V02 = this.zAxis.X,
                V10 = this.xAxis.Y,
                V11 = this.yAxis.Y,
                V12 = this.zAxis.Y,
                V20 = this.xAxis.Z,
                V21 = this.yAxis.Z,
                V22 = this.zAxis.Z
            };

            this.globalCoordsMatrix = new Accord.Math.Matrix3x3
            {
                V00 = this.xAxis.X,
                V01 = this.xAxis.Y,
                V02 = this.xAxis.Z,
                V10 = this.yAxis.X,
                V11 = this.yAxis.Y,
                V12 = this.yAxis.Z,
                V20 = this.zAxis.X,
                V21 = this.zAxis.Y,
                V22 = this.zAxis.Z
            };
        }

        public Pivot(Vector3 center, Vector3 xAxis, Vector3 yAxis, Vector3 zAxis)
        {
            this.center = new Vector3(center.X, center.Y, center.Z);

            this.xAxis = new Vector3(xAxis.X, xAxis.Y, xAxis.Z);
            this.yAxis = new Vector3(yAxis.X, yAxis.Y, yAxis.Z);
            this.zAxis = new Vector3(zAxis.X, zAxis.Y, zAxis.Z);

            this.localCoordsMatrix = new Accord.Math.Matrix3x3
            {
                V00 = this.xAxis.X,
                V01 = this.yAxis.X,
                V02 = this.zAxis.X,
                V10 = this.xAxis.Y,
                V11 = this.yAxis.Y,
                V12 = this.zAxis.Y,
                V20 = this.xAxis.Z,
                V21 = this.yAxis.Z,
                V22 = this.zAxis.Z
            };

            this.globalCoordsMatrix = new Accord.Math.Matrix3x3
            {
                V00 = this.xAxis.X,
                V01 = this.xAxis.Y,
                V02 = this.xAxis.Z,
                V10 = this.yAxis.X,
                V11 = this.yAxis.Y,
                V12 = this.yAxis.Z,
                V20 = this.zAxis.X,
                V21 = this.zAxis.Y,
                V22 = this.zAxis.Z
            };
        }

        public Vector3 ToLocalCoords(Vector3 global)
        {
            //Находим позицию вектора относительно точки центра и раскладываем в локальном базисе
            return this.localCoordsMatrix * (global - this.center);
        }
        public Vector3 ToGlobalCoords(Vector3 local)
        {
            //В точности да наоборот - раскладываем локальный вектор в глобальном базисе и находим позицию относительно глобального центра
            return this.globalCoordsMatrix * local + this.center;
        }

        public void Move(Vector3 vector)
        {
            this.center += vector;
        }

        public void Rotate(float angle, Vector3 vector)
        {
            this.xAxis = this.xAxis.Rotate(angle, vector);
            this.yAxis = this.yAxis.Rotate(angle, vector);
            this.zAxis = this.zAxis.Rotate(angle, vector);
        }

        public object Clone()
        {
            return new Pivot(this.center, this.xAxis, this.yAxis, this.zAxis);
        }
    }
}