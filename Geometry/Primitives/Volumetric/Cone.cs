using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad.Geometry.Primitives.Volumetric
{
    public class Cone : IVolumetric
    {
        private Point center = new Point();
        private float topRadius = 0.0f;
        private float bottomRadius = 0.5f;
        private float height = 1.0f;
        private uint edgesAmount = 3;
        private List<Point[]> points;

        private static List<Point[]> RecalculatePoints(in Point center, float topRadius, float bottomRadius, float height, uint edgesAmount)
        {
            List<Point[]> points = new List<Point[]>();
            Point[] topPoints = new Point[edgesAmount];
            Point[] bottomPoints = new Point[edgesAmount];

            /* Используется сферическая система координат. Углы в градусах. */  
            double pi = Utility.Math.piInDegrees;
            double phi;
            double theta = pi / 2.0;
            double deltaPhi = pi / (edgesAmount / 2.0);

            for (int i = 0; i < edgesAmount; i++)
            {
                phi = deltaPhi * i;

                topPoints[i] = new Point(topRadius, theta, phi);
                topPoints[i].X += center.X;
                topPoints[i].Y += center.Y + height / 2.0f;
                topPoints[i].Z += center.Z;

                bottomPoints[i] = new Point(bottomRadius, theta, phi);
                bottomPoints[i].X += center.X;
                bottomPoints[i].Y += center.Y - height / 2.0f;
                bottomPoints[i].Z += center.Z;
            }

            points.Add(topPoints);
            points.Add(bottomPoints);

            return points;
        }

        public Cone() 
        {
            this.points = RecalculatePoints(this.center, this.topRadius, this.bottomRadius, this.height, this.edgesAmount);
        }

        public Cone(in Point center, float topRadius, float bottomRadius, float height, uint edgesAmount)
        {
            if ((topRadius == 0.0f) && (bottomRadius == 0.0f) || (topRadius < 0.0f) || (bottomRadius < 0.0f) || (height <= 0.0f) || (edgesAmount < 3))
            {
                throw new ArgumentException("Impossible to create a cone with the following parameters.");
            }

            this.center = (Point)center.Clone();
            this.topRadius = topRadius;
            this.bottomRadius = bottomRadius;
            this.height = height;
            this.edgesAmount = edgesAmount;
            this.points = RecalculatePoints(this.center, this.topRadius, this.bottomRadius, this.height, this.edgesAmount);
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
                this.points = RecalculatePoints(this.center, this.topRadius, this.bottomRadius, this.height, this.edgesAmount);
            }
        }

        public float TopRadius
        {
            get
            {
                return this.topRadius;
            }

            set
            {
                if ((value < 0.0f) || ((this.bottomRadius == 0.0f) && (value == 0.0f)))
                {
                    throw new ArgumentException("Impossible to modify a cone: wrong value for topRadius.");
                }

                this.topRadius = value;
                this.points = RecalculatePoints(this.center, this.topRadius, this.bottomRadius, this.height, this.edgesAmount);
            }
        }

        public float BottomRadius
        {
            get
            {
                return this.bottomRadius;
            }

            set
            {
                if ((value < 0.0f) || ((this.topRadius == 0.0f) && (value == 0.0f)))
                {
                    throw new ArgumentException("Impossible to modify a cone: wrong value for bottomRadius.");
                }

                this.bottomRadius = value;
                this.points = RecalculatePoints(this.center, this.topRadius, this.bottomRadius, this.height, this.edgesAmount);
            }
        }

        public float Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("Impossible to modify a cone: height must be greater than 0.");
                }

                this.height = value;
                this.points = RecalculatePoints(this.center, this.topRadius, this.bottomRadius, this.height, this.edgesAmount);
            }
        }

        public uint EdgesAmount
        {
            get
            {
                return this.edgesAmount;
            }

            set
            {
                if (value < 3)
                {
                    throw new ArgumentException("Impossible to modify a cone: edges amount must be greater than 2.");
                }

                this.edgesAmount = value;
                this.points = RecalculatePoints(this.center, this.topRadius, this.bottomRadius, this.height, this.edgesAmount);
            }
        }

        public List<Point[]> Points
        {
            get
            {
                return RecalculatePoints(this.center, this.topRadius, this.bottomRadius, this.height, this.edgesAmount);
            }
        }

        public void Draw(OpenGL gl, float width, Color color)
        {
            gl.LineWidth(width);

            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_LINES);

            for (int i = 0; i < this.edgesAmount; i++)
            {
                gl.Vertex(this.points[0][i].X, this.points[0][i].Y, this.points[0][i].Z);
                gl.Vertex(this.points[1][i].X, this.points[1][i].Y, this.points[1][i].Z);
            }

            gl.Vertex(this.points[0][0].X, this.points[0][0].Y, this.points[0][0].Z);
            gl.Vertex(this.points[1][0].X, this.points[1][0].Y, this.points[1][0].Z);

            gl.End();

            gl.Begin(OpenGL.GL_LINES);

            for (int j = 0; j < this.edgesAmount - 1; j++)
            {
                gl.Vertex(this.center.X, this.center.Y + this.height / 2.0f, this.center.Z);
                gl.Vertex(this.points[0][j].X, this.points[0][j].Y, this.points[0][j].Z);
                gl.Vertex(this.points[0][j].X, this.points[0][j].Y, this.points[0][j].Z);
                gl.Vertex(this.points[0][j + 1].X, this.points[0][j + 1].Y, this.points[0][j + 1].Z);

                gl.Vertex(this.center.X, this.center.Y - this.height / 2.0f, this.center.Z);
                gl.Vertex(this.points[1][j].X, this.points[1][j].Y, this.points[1][j].Z);
                gl.Vertex(this.points[1][j].X, this.points[1][j].Y, this.points[1][j].Z);
                gl.Vertex(this.points[1][j + 1].X, this.points[1][j + 1].Y, this.points[1][j + 1].Z);
            }

            gl.Vertex(this.center.X, this.center.Y + this.height / 2.0f, this.center.Z);
            gl.Vertex(this.points[0][this.edgesAmount - 1].X, this.points[0][this.edgesAmount - 1].Y, this.points[0][this.edgesAmount - 1].Z);
            gl.Vertex(this.points[0][this.edgesAmount - 1].X, this.points[0][this.edgesAmount - 1].Y, this.points[0][this.edgesAmount - 1].Z);
            gl.Vertex(this.points[0][0].X, this.points[0][0].Y, this.points[0][0].Z);

            gl.Vertex(this.center.X, this.center.Y - this.height / 2.0f, this.center.Z);
            gl.Vertex(this.points[1][this.edgesAmount - 1].X, this.points[1][this.edgesAmount - 1].Y, this.points[1][this.edgesAmount - 1].Z);
            gl.Vertex(this.points[1][this.edgesAmount - 1].X, this.points[1][this.edgesAmount - 1].Y, this.points[1][this.edgesAmount - 1].Z);
            gl.Vertex(this.points[1][0].X, this.points[1][0].Y, this.points[1][0].Z);

            gl.End();
        }

        public void DrawArea(OpenGL gl, Color color)
        {
            gl.Color(color.R, color.G, color.B, color.A);

            /* Отрисовка боковой поверхности. */
            gl.Begin(OpenGL.GL_QUAD_STRIP);

            for (int i = 0; i < this.edgesAmount; i++)
            {
                gl.Vertex(this.points[0][i].X, this.points[0][i].Y, this.points[0][i].Z);
                gl.Vertex(this.points[1][i].X, this.points[1][i].Y, this.points[1][i].Z);
            }

            /* Для корректного завершения текущего слоя (из-за GL_QUAD_STRIP). */
            gl.Vertex(this.points[0][0].X, this.points[0][0].Y, this.points[0][0].Z);
            gl.Vertex(this.points[1][0].X, this.points[1][0].Y, this.points[1][0].Z);

            gl.End();
            
            gl.Begin(OpenGL.GL_TRIANGLE_FAN);

            /* Центральная точка верхней "крышки". */
            gl.Vertex(this.center.X, this.center.Y + this.height / 2.0f, this.center.Z);

            for (int j = 0; j < this.edgesAmount; j++)
            {
                gl.Vertex(this.points[0][j].X, this.points[0][j].Y, this.points[0][j].Z);
            }

            gl.Vertex(this.points[0][0].X, this.points[0][0].Y, this.points[0][0].Z);

            gl.End();

            gl.Begin(OpenGL.GL_TRIANGLE_FAN);

            /* Центральная точка нижней "крышки". */
            gl.Vertex(this.center.X, this.center.Y - this.height / 2.0f, this.center.Z);

            for (int k = 0; k < this.edgesAmount; k++)
            {
                gl.Vertex(this.points[1][k].X, this.points[1][k].Y, this.points[1][k].Z);
            }

            gl.Vertex(this.points[1][0].X, this.points[1][0].Y, this.points[1][0].Z);

            gl.End();
        }

        public object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}