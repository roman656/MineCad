using MineCad.Geometry.Primitives.Flat;
using SharpGL;
using System;
using System.Drawing;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad.Geometry.Primitives.Volumetric
{
    public class Box : IVolumetric
    {
        private Point center = new Point();
        private float sizeX = 1.0f;
        private float sizeY = 1.0f;
        private float sizeZ = 1.0f;
        private Point[] points;

        private static Point[] RecalculatePoints(in Point center, float sizeX, float sizeY, float sizeZ)
        {
            Point[] points = { new Point(center.X - sizeX / 2.0f, center.Y + sizeY / 2.0f, center.Z - sizeZ / 2.0f),
                               new Point(center.X + sizeX / 2.0f, center.Y + sizeY / 2.0f, center.Z - sizeZ / 2.0f),
                               new Point(center.X + sizeX / 2.0f, center.Y + sizeY / 2.0f, center.Z + sizeZ / 2.0f),
                               new Point(center.X - sizeX / 2.0f, center.Y + sizeY / 2.0f, center.Z + sizeZ / 2.0f),
                               new Point(center.X - sizeX / 2.0f, center.Y - sizeY / 2.0f, center.Z - sizeZ / 2.0f),
                               new Point(center.X - sizeX / 2.0f, center.Y - sizeY / 2.0f, center.Z + sizeZ / 2.0f),
                               new Point(center.X + sizeX / 2.0f, center.Y - sizeY / 2.0f, center.Z + sizeZ / 2.0f),
                               new Point(center.X + sizeX / 2.0f, center.Y - sizeY / 2.0f, center.Z - sizeZ / 2.0f) };

            return points;
        }

        public Box()
        {
            this.points = RecalculatePoints(this.center, this.sizeX, this.sizeY, this.sizeZ);
        }

        public Box(in Point center, float sizeX, float sizeY, float sizeZ)
        {
            if ((sizeX <= 0.0f) || (sizeY <= 0.0f) || (sizeZ <= 0.0f))
            {
                throw new ArgumentException("Impossible to create a box with the following parameters.");
            }

            this.center = (Point)center.Clone();
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.sizeZ = sizeZ;
            this.points = RecalculatePoints(this.center, this.sizeX, this.sizeY, this.sizeZ);
        }

        /* Построение прямоугольного параллелепипеда по 2м точкам его диагонали. */
        public Box(in Point begin, in Point end)
        {
            if ((begin.Equals(end)) || (Math.Abs(begin.X - end.X) <= 0.0f) || (Math.Abs(begin.Y - end.Y) <= 0.0f) || (Math.Abs(begin.Z - end.Z) <= 0.0f))
            {
                throw new ArgumentException("Impossible to create a box with the following parameters.");
            }

            this.center = Line.GetCenter(begin, end);
            this.sizeX = Math.Abs(begin.X - end.X);
            this.sizeY = Math.Abs(begin.Y - end.Y);
            this.sizeZ = Math.Abs(begin.Z - end.Z);
            this.points = RecalculatePoints(this.center, this.sizeX, this.sizeY, this.sizeZ);
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
            }
        }

        public float SizeX
        {
            get
            {
                return this.sizeX;
            }

            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("Impossible to modify a box: sizeX must be greater than 0.");
                }

                this.sizeX = value;
                RecalculatePoints(this.center, this.sizeX, this.sizeY, this.sizeZ);
            }
        }

        public float SizeY
        {
            get
            {
                return this.sizeY;
            }

            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("Impossible to modify a box: sizeY must be greater than 0.");
                }

                this.sizeY = value;
                RecalculatePoints(this.center, this.sizeX, this.sizeY, this.sizeZ);
            }
        }

        public float SizeZ
        {
            get
            {
                return this.sizeZ;
            }

            set
            {
                if (value <= 0.0f)
                {
                    throw new ArgumentException("Impossible to modify a box: sizeZ must be greater than 0.");
                }

                this.sizeZ = value;
                RecalculatePoints(this.center, this.sizeX, this.sizeY, this.sizeZ);
            }
        }

        public Point[] Points
        {
            get
            {      
                return RecalculatePoints(this.center, this.sizeX, this.sizeY, this.sizeZ);
            }
        }

        public void Draw(OpenGL gl, float width, Color color)
        {
            gl.LineWidth(width);

            gl.Color(color.R, color.G, color.B, color.A);

            /* Отрисовка ребер верхней грани. */
            gl.Begin(OpenGL.GL_LINE_LOOP);

            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[1].X, this.points[1].Y, this.points[1].Z);
            gl.Vertex(this.points[2].X, this.points[2].Y, this.points[2].Z);
            gl.Vertex(this.points[3].X, this.points[3].Y, this.points[3].Z);

            gl.End();

            /* Отрисовка ребер нижней грани. */
            gl.Begin(OpenGL.GL_LINE_LOOP);

            gl.Vertex(this.points[4].X, this.points[4].Y, this.points[4].Z);
            gl.Vertex(this.points[5].X, this.points[5].Y, this.points[5].Z);
            gl.Vertex(this.points[6].X, this.points[6].Y, this.points[6].Z);
            gl.Vertex(this.points[7].X, this.points[7].Y, this.points[7].Z);

            gl.End();

            /* Отрисовка вертикальных ребер. */
            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[4].X, this.points[4].Y, this.points[4].Z);

            gl.Vertex(this.points[1].X, this.points[1].Y, this.points[1].Z);
            gl.Vertex(this.points[7].X, this.points[7].Y, this.points[7].Z);

            gl.Vertex(this.points[2].X, this.points[2].Y, this.points[2].Z);
            gl.Vertex(this.points[6].X, this.points[6].Y, this.points[6].Z);

            gl.Vertex(this.points[3].X, this.points[3].Y, this.points[3].Z);
            gl.Vertex(this.points[5].X, this.points[5].Y, this.points[5].Z);

            gl.End();
        }

        public void DrawArea(OpenGL gl, Color color)
        {
            gl.Color(color.R, color.G, color.B, color.A);

            gl.Begin(OpenGL.GL_QUADS);

            /* Отрисовка верхней грани. */
            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[1].X, this.points[1].Y, this.points[1].Z);
            gl.Vertex(this.points[2].X, this.points[2].Y, this.points[2].Z);
            gl.Vertex(this.points[3].X, this.points[3].Y, this.points[3].Z);

            /* Отрисовка нижней грани. */
            gl.Vertex(this.points[4].X, this.points[4].Y, this.points[4].Z);
            gl.Vertex(this.points[5].X, this.points[5].Y, this.points[5].Z);
            gl.Vertex(this.points[6].X, this.points[6].Y, this.points[6].Z);
            gl.Vertex(this.points[7].X, this.points[7].Y, this.points[7].Z);

            gl.End();

            /* Отрисовка боковых граней. */
            gl.Begin(OpenGL.GL_QUAD_STRIP);

            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[4].X, this.points[4].Y, this.points[4].Z);

            gl.Vertex(this.points[1].X, this.points[1].Y, this.points[1].Z);
            gl.Vertex(this.points[7].X, this.points[7].Y, this.points[7].Z);

            gl.Vertex(this.points[2].X, this.points[2].Y, this.points[2].Z);
            gl.Vertex(this.points[6].X, this.points[6].Y, this.points[6].Z);

            gl.Vertex(this.points[3].X, this.points[3].Y, this.points[3].Z);
            gl.Vertex(this.points[5].X, this.points[5].Y, this.points[5].Z);

            gl.Vertex(this.points[0].X, this.points[0].Y, this.points[0].Z);
            gl.Vertex(this.points[4].X, this.points[4].Y, this.points[4].Z);

            gl.End();
        }

        public object Clone()
        {
            return new Box(this.center, this.sizeX, this.sizeY, this.sizeZ);
        }
    }
}