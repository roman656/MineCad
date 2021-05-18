using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad.Geometry.Primitives.Volumetric
{
    public class Sphere : IVolumetric
    {
        private Point center = new Point();
        private float radius = 1.0f;
        private uint edgesAmountInEachCircle = 4;
        private List<Point[]> points;

        private static List<Point[]> RecalculatePoints(in Point center, float radius, uint edgesAmountInEachCircle)
        {
            List<Point[]> points = new List<Point[]>();

            /* Используется сферическая система координат. Углы в градусах. */
            double theta;
            double phi;
            double pi = Utility.Math.piInDegrees;
            double deltaTheta = (pi / 2.0) / (edgesAmountInEachCircle / 4.0);
            double deltaPhi = (pi / 2.0) / (edgesAmountInEachCircle / 4.0);

            for (int i = 0; i <= (edgesAmountInEachCircle / 2.0); i++)
            {
                Point[] layerPoints = new Point[edgesAmountInEachCircle];

                theta = deltaTheta * i;

                for (int j = 0; j < edgesAmountInEachCircle; j++)
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
            this.points = RecalculatePoints(this.center, this.radius, this.edgesAmountInEachCircle);
        }

        public Sphere(in Point center, float radius, uint edgesAmountInEachCircle)
        {
            if ((radius <= 0.0f) || (edgesAmountInEachCircle <= 3))
            {
                throw new ArgumentException("Impossible to create a sphere with the following parameters.");
            }

            this.center = (Point)center.Clone();
            this.radius = radius;
            this.edgesAmountInEachCircle = edgesAmountInEachCircle;
            this.points = RecalculatePoints(this.center, this.radius, this.edgesAmountInEachCircle);
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
                this.points = RecalculatePoints(this.center, this.radius, this.edgesAmountInEachCircle);
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
                if (value <= 0.0f)
                {
                    throw new ArgumentException("Impossible to modify a sphere: radius must be greater than 0.");
                }

                this.radius = value;
                this.points = RecalculatePoints(this.center, this.radius, this.edgesAmountInEachCircle);
            }
        }

        public uint EdgesAmountInEachCircle
        {
            get
            {
                return this.edgesAmountInEachCircle;
            }

            set
            {
                if (value <= 3)
                {
                    throw new ArgumentException("Impossible to modify a sphere: edges amount in each circle must be greater than 3.");
                }

                this.edgesAmountInEachCircle = value;
                this.points = RecalculatePoints(this.center, this.radius, this.edgesAmountInEachCircle);
            }
        }

        public List<Point[]> Points
        {
            get
            {
                return RecalculatePoints(this.center, this.radius, this.edgesAmountInEachCircle);
            }
        }

        public void Draw(OpenGL gl, float width, Color color)
        {
            gl.LineWidth(width);

            /* Установка цвета линий. */
            gl.Color(color.R, color.G, color.B, color.A);

            for (int i = 0; i < this.points.Count - 1; i++)
            {
                for (int j = 0; j < this.edgesAmountInEachCircle - 1; j++)
                {
                    gl.Begin(OpenGL.GL_LINE_STRIP);

                    gl.Vertex(this.points[i][j + 1].X, this.points[i][j + 1].Y, this.points[i][j + 1].Z);
                    gl.Vertex(this.points[i][j].X, this.points[i][j].Y, this.points[i][j].Z);
                    gl.Vertex(this.points[i + 1][j].X, this.points[i + 1][j].Y, this.points[i + 1][j].Z);

                    gl.End();
                }

                /* Дополнительный элемент для корректного завершения текущего слоя, соединяющий начало с концом. */
                gl.Begin(OpenGL.GL_LINE_STRIP);

                gl.Vertex(this.points[i][0].X, this.points[i][0].Y, this.points[i][0].Z);
                gl.Vertex(this.points[i][this.edgesAmountInEachCircle - 1].X,
                          this.points[i][this.edgesAmountInEachCircle - 1].Y,
                          this.points[i][this.edgesAmountInEachCircle - 1].Z);
                gl.Vertex(this.points[i + 1][this.edgesAmountInEachCircle - 1].X,
                          this.points[i + 1][this.edgesAmountInEachCircle - 1].Y,
                          this.points[i + 1][this.edgesAmountInEachCircle - 1].Z);

                gl.End();
            }
        }

        public void DrawArea(OpenGL gl, Color color)
        {
            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_QUAD_STRIP);

            for (int i = 0; i < this.points.Count - 1; i++)
            {
                for (int j = 0; j < this.edgesAmountInEachCircle; j++)
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

        public object Clone()
        {
            return new Sphere(this.center, this.radius, this.edgesAmountInEachCircle);
        }
    }
}