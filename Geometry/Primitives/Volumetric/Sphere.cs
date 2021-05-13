using System;
using System.Collections.Generic;
using System.Drawing;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad.Geometry.Primitives.Volumetric
{
    class Sphere : ICloneable
    {
        /* 
         * Константа, необходимая для конвертации RGB цвета [0; 255]
         * в RGB цвет [0.0f; 1.0f].
         */
        private const float colorConversionConstant = byte.MaxValue;
        private Point center = new Point();
        private float radius = 1.0f;
        private uint linesAmountInEachCircle = 4;
        private List<Point[]> points;

        private static List<Point[]> RecalculatePoints(in Point center, float radius, uint linesAmountInEachCircle)
        {
            List<Point[]> points = new List<Point[]>();

            /* Используется сферическая система координат. Углы в градусах. */
            double theta;
            double phi;
            double pi = 180.0;
            double deltaTheta = (pi / 2) / (linesAmountInEachCircle / 4.0);
            double deltaPhi = (pi / 2) / (linesAmountInEachCircle / 4.0);

            for (int i = 0; i <= (linesAmountInEachCircle / 2.0f); i++)
            {
                Point[] layerPoints = new Point[linesAmountInEachCircle];

                theta = deltaTheta * i;

                for (int j = 0; j < linesAmountInEachCircle; j++)
                {
                    phi = deltaPhi * j;

                    layerPoints[j] = new Point(radius, theta, phi);
                    layerPoints[j].X += center.X;
                    layerPoints[j].Y += center.Y;
                    layerPoints[j].Z += center.Z;
                }

                points.Add(layerPoints);
            }

            return points;
        }

        public Sphere()
        {
            this.points = RecalculatePoints(this.center, this.radius, this.linesAmountInEachCircle);
        }

        public Sphere(in Point center, float radius, uint linesAmountInEachCircle)
        {
            this.center = (Point)center.Clone();
            this.radius = (radius > 0.0f) ? radius : 1.0f;
            this.linesAmountInEachCircle = (linesAmountInEachCircle > 3) ? linesAmountInEachCircle : 4;
            this.points = RecalculatePoints(this.center, this.radius, this.linesAmountInEachCircle);
        }

        public Point Center
        {
            get
            {
                return (Point)this.center.Clone();
            }

            set
            {
                this.center = (Point)value.Clone();
                this.points = RecalculatePoints(this.center, this.radius, this.linesAmountInEachCircle);
            }
        }

        public float Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value > 0.0f)
                {
                    this.radius = value;
                    this.points = RecalculatePoints(this.center, this.radius, this.linesAmountInEachCircle);
                }
            }
        }

        public uint LinesAmountInEachCircle
        {
            get
            {
                return this.linesAmountInEachCircle;
            }

            set
            {
                if (value > 3)
                {
                    this.linesAmountInEachCircle = value;
                    this.points = RecalculatePoints(this.center, this.radius, this.linesAmountInEachCircle);
                }
            }
        }

        public List<Point[]> Points
        {
            get
            {
                return RecalculatePoints(this.center, this.radius, this.linesAmountInEachCircle);
            }
        }

        public void DrawOutline(SharpGL.OpenGL gl, float width, Color color)
        {
            /* Установка толщины линий. */
            gl.LineWidth(width);

            /* Установка цвета линий. */
            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            for (int i = 0; i < this.points.Count - 1; i++)
            {
                for (int j = 0; j < this.linesAmountInEachCircle - 1; j++)
                {
                    gl.Begin(SharpGL.OpenGL.GL_LINE_STRIP);

                    gl.Vertex(this.points[i][j + 1].X, this.points[i][j + 1].Y, this.points[i][j + 1].Z);
                    gl.Vertex(this.points[i][j].X, this.points[i][j].Y, this.points[i][j].Z);
                    gl.Vertex(this.points[i + 1][j].X, this.points[i + 1][j].Y, this.points[i + 1][j].Z);

                    gl.End();
                }

                /* Дополнительный элемент для корректного завершения текущего слоя, соединяющий начало с концом. */
                gl.Begin(SharpGL.OpenGL.GL_LINE_STRIP);

                gl.Vertex(this.points[i][0].X, this.points[i][0].Y, this.points[i][0].Z);
                gl.Vertex(this.points[i][this.linesAmountInEachCircle - 1].X,
                          this.points[i][this.linesAmountInEachCircle - 1].Y,
                          this.points[i][this.linesAmountInEachCircle - 1].Z);
                gl.Vertex(this.points[i + 1][this.linesAmountInEachCircle - 1].X,
                          this.points[i + 1][this.linesAmountInEachCircle - 1].Y,
                          this.points[i + 1][this.linesAmountInEachCircle - 1].Z);

                gl.End();
            }
        }

        public void Draw(SharpGL.OpenGL gl, Color color)
        {
            /* Установка цвета сферы. */
            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_QUAD_STRIP);

            for (int i = 0; i < this.points.Count - 1; i++)
            {
                for (int j = 0; j < this.linesAmountInEachCircle; j++)
                {
                    gl.Vertex(this.points[i][j].X, this.points[i][j].Y, this.points[i][j].Z);
                    gl.Vertex(this.points[i + 1][j].X, this.points[i + 1][j].Y, this.points[i + 1][j].Z);
                }

                /* Для корректного завершения текущего слоя (из-за GL_QUAD_STRIP). */
                gl.Vertex(this.points[i][0].X, this.points[i][0].Y, this.points[i][0].Z);
                gl.Vertex(this.points[i + 1][0].X, this.points[i + 1][0].Y, this.points[i + 1][0].Z);
            }

            gl.End();
        }

        public static void DrawOutline(SharpGL.OpenGL gl, in Point center, float radius, uint linesAmountInEachCircle, float width, Color color)
        {
            if ((radius > 0.0f) && (linesAmountInEachCircle > 3))
            {
                List<Point[]> points = RecalculatePoints(center, radius, linesAmountInEachCircle);

                gl.LineWidth(width);

                gl.Color(color.R / colorConversionConstant,
                         color.G / colorConversionConstant,
                         color.B / colorConversionConstant);

                for (int i = 0; i < points.Count - 1; i++)
                {
                    for (int j = 0; j < linesAmountInEachCircle - 1; j++)
                    {
                        gl.Begin(SharpGL.OpenGL.GL_LINE_STRIP);

                        gl.Vertex(points[i][j + 1].X, points[i][j + 1].Y, points[i][j + 1].Z);
                        gl.Vertex(points[i][j].X, points[i][j].Y, points[i][j].Z);
                        gl.Vertex(points[i + 1][j].X, points[i + 1][j].Y, points[i + 1][j].Z);

                        gl.End();
                    }

                    /* Дополнительный элемент для корректного завершения текущего слоя, соединяющий начало с концом. */
                    gl.Begin(SharpGL.OpenGL.GL_LINE_STRIP);

                    gl.Vertex(points[i][0].X, points[i][0].Y, points[i][0].Z);
                    gl.Vertex(points[i][linesAmountInEachCircle - 1].X,
                              points[i][linesAmountInEachCircle - 1].Y,
                              points[i][linesAmountInEachCircle - 1].Z);
                    gl.Vertex(points[i + 1][linesAmountInEachCircle - 1].X,
                              points[i + 1][linesAmountInEachCircle - 1].Y,
                              points[i + 1][linesAmountInEachCircle - 1].Z);

                    gl.End();
                }
            }
        }

        public static void Draw(SharpGL.OpenGL gl, in Point center, float radius, uint linesAmountInEachCircle, Color color)
        {
            if ((radius > 0.0f) && (linesAmountInEachCircle > 3))
            {
                List<Point[]> points = RecalculatePoints(center, radius, linesAmountInEachCircle);

                gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

                gl.Begin(SharpGL.OpenGL.GL_QUAD_STRIP);

                for (int i = 0; i < points.Count - 1; i++)
                {
                    for (int j = 0; j < linesAmountInEachCircle; j++)
                    {
                        gl.Vertex(points[i][j].X, points[i][j].Y, points[i][j].Z);
                        gl.Vertex(points[i + 1][j].X, points[i + 1][j].Y, points[i + 1][j].Z);
                    }

                    /* Для корректного завершения текущего слоя (из-за GL_QUAD_STRIP). */
                    gl.Vertex(points[i][0].X, points[i][0].Y, points[i][0].Z);
                    gl.Vertex(points[i + 1][0].X, points[i + 1][0].Y, points[i + 1][0].Z);
                }

                gl.End();
            }
        }

        public object Clone()
        {
            return new Sphere(this.center, this.radius, this.linesAmountInEachCircle);
        }
    }
}
