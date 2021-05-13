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
    }
}