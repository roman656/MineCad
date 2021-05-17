using MineCad.Geometry.Primitives.Flat;

namespace MineCad.Utility
{
    public static class Math
    {
        public const double piInDegrees = 180.0;

        public static double ConvertDegreesToRadians(double degrees)
        {
            return (degrees * System.Math.PI / piInDegrees);
        }

        public static double ConvertRadiansToDegrees(double radians)
        {
            return (radians * piInDegrees / System.Math.PI);
        }

        /* 
         * Нормализует (ограничивает) угол (градусы) в указанном диапазоне: [0 ; 360).
         * Если значение выходит за диапазон, угол пересчитывается так,
         * чтобы "визуально" он остался прежним, но его значение укладывалось бы в заданный диапазон.
         */
        public static double ConstrainAngle360Degrees(double degrees)
        {
            degrees = degrees % (2.0 * piInDegrees);

            if (degrees < 0.0)
            {
                degrees += (2.0 * piInDegrees);
            }

            return degrees;
        }

        /* Нормализует (ограничивает) угол (градусы) в указанном диапазоне: [0 ; 180]. */
        public static double ConstrainAngle180Degrees(double degrees)
        {
            if (degrees < 0.0 || degrees > piInDegrees)
            {
                degrees = degrees % piInDegrees;

                if (degrees <= 0.0)
                {
                    degrees += piInDegrees;
                }
            }

            return degrees;
        }

        /* 
         * Проверяет, не находится ли полученная точка на данной прямой.
         * В данном случае Line рассматривается, как бесконечная прямая, а не отрезок.
         * Возвращает: true - точка находится на прямой; false - в противном случае.
         */
        public static bool CheckHasLineThisPoint(in Line line, in Point point)
        {
            /* Вектора по координатам точек (хранятся в Point ради удобства). */
            Point AB = new Point(line.End.X - line.Begin.X, line.End.Y - line.Begin.Y, line.End.Z - line.Begin.Z);
            Point AC = new Point(point.X - line.Begin.X, point.Y - line.Begin.Y, point.Z - line.Begin.Z);

            /* Векторное произведение AB и AC. */
            Point C = new Point((AB.Y * AC.Z - AB.Z * AC.Y),
                                (AB.X * AC.Z - AB.Z * AC.X) * -1.0f,
                                (AB.X * AC.Y - AB.Y * AC.X));

            /* Площадь треугольника, образованного данными точками. */
            double S = C.Abs / 2.0;

            /* Если площадь образуемого этими точками треугольника равна 0, то они на 1й прямой. */
            return (S == 0.0);
        }

        /*
         * Проверка компланарности 3х векторов.
         * 3 вектора называются компланарными, если они, будучи приведенными к общему началу, лежат в одной плоскости.
         * Смешанное произведение компланарных векторов равно 0.
         * Возвращает: true - вектора компланарны; false - в противном случае.
         */
        public static bool CheckVectorsCoplanarity(in Point vectorA, in Point vectorB, in Point vectorC)
        {
            float determinant = vectorA.X * vectorB.Y * vectorC.Z
                              + vectorA.Y * vectorB.Z * vectorC.X
                              + vectorA.Z * vectorB.X * vectorC.Y
                              - vectorA.Z * vectorB.Y * vectorC.X
                              - vectorA.X * vectorB.Z * vectorC.Y
                              - vectorA.Y * vectorB.X * vectorC.Z;

            return (determinant == 0.0f);
        }
    }
}