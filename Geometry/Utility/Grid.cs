using MineCad.Geometry.Primitives.Flat;
using System.Drawing;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad
{
    class Grid : IMineCadObject
    {
        private Point center = new Point();
        private float cellSize = 1.0f;
        private uint lengthInCells = 1;
        private uint widthInCells = 1;

        public Grid() {}

        public Grid(in Point center, float cellSize, uint lengthInCells, uint widthInCells)
        {
            this.center = (Point)center.Clone();
            this.cellSize = (cellSize > 0.0f) ? cellSize : 1.0f;
            this.lengthInCells = (lengthInCells > 0) ? lengthInCells : 1;
            this.widthInCells = (widthInCells > 0) ? widthInCells : 1;
        }

        public Grid(in Point center, float cellSize, uint sizeInCells)
        {
            this.center = (Point)center.Clone();
            this.cellSize = (cellSize > 0.0f) ? cellSize : 1.0f;
            this.lengthInCells = (sizeInCells > 0) ? sizeInCells : 1;
            this.widthInCells = (sizeInCells > 0) ? sizeInCells : 1;
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

        public float CellSize
        {
            get
            {
                return this.cellSize;
            }

            set
            {
                if (value > 0.0f)
                {
                    this.cellSize = value;
                }
            }
        }

        public uint LengthInCells
        {
            get
            {
                return this.lengthInCells;
            }

            set
            {
                if (value > 0)
                {
                    this.lengthInCells = value;
                }
            }
        }

        public uint WidthInCells
        {
            get
            {
                return this.widthInCells;
            }

            set
            {
                if (value > 0)
                {
                    this.widthInCells = value;
                }
            }
        }

        public void Draw(SharpGL.OpenGL gl, uint plane, float width, Color color)
        {
            float gridLength = this.lengthInCells * this.cellSize;
            float gridWidth = this.widthInCells * this.cellSize;

            for (uint i = 0; i <= this.widthInCells; i++)
            {
                if (plane == 0)
                {
                    /* В плоскости XY. */
                    Line.Draw(gl, this.center.X - gridLength / 2.0f, this.center.Y - gridWidth / 2.0f + this.cellSize * i, this.center.Z,
                            this.center.X + gridLength / 2.0f, this.center.Y - gridWidth / 2.0f + this.cellSize * i, this.center.Z,
                            width, color);
                }
                else if (plane == 1)
                {
                    /* В плоскости YZ. */
                    Line.Draw(gl, this.center.X, this.center.Y - gridWidth / 2.0f + this.cellSize * i, this.center.Z - gridLength / 2.0f,
                            this.center.X, this.center.Y - gridWidth / 2.0f + this.cellSize * i, this.center.Z + gridLength / 2.0f,
                            width, color);
                }
                else
                {
                    /* В плоскости XZ. */
                    Line.Draw(gl, this.center.X - gridLength / 2.0f, this.center.Y, this.center.Z - gridWidth / 2.0f + this.cellSize * i,
                            this.center.X + gridLength / 2.0f, this.center.Y, this.center.Z - gridWidth / 2.0f + this.cellSize * i,
                            width, color);
                }
            }

            for (uint j = 0; j <= this.lengthInCells; j++)
            {
                if (plane == 0)
                {
                    Line.Draw(gl, this.center.X - gridLength / 2.0f + this.cellSize * j, this.center.Y - gridWidth / 2.0f, this.center.Z,
                            this.center.X - gridLength / 2.0f + this.cellSize * j, this.center.Y + gridWidth / 2.0f, this.center.Z,
                            width, color);
                }
                else if (plane == 1)
                {
                    Line.Draw(gl, this.center.X, this.center.Y - gridWidth / 2.0f, this.center.Z - gridLength / 2.0f + this.cellSize * j,
                            this.center.X, this.center.Y + gridWidth / 2.0f, this.center.Z - gridLength / 2.0f + this.cellSize * j,
                            width, color);
                }
                else
                {
                    Line.Draw(gl, this.center.X - gridLength / 2.0f + this.cellSize * j, this.center.Y, this.center.Z - gridWidth / 2.0f,
                            this.center.X - gridLength / 2.0f + this.cellSize * j, this.center.Y, this.center.Z + gridWidth / 2.0f,
                            width, color); 
                }
            }
        }

        public static void Draw(SharpGL.OpenGL gl, uint plane, in Point center, float cellSize, uint lengthInCells, uint widthInCells,
                float width, Color color)
        {
            float gridLength = lengthInCells * cellSize;
            float gridWidth = widthInCells * cellSize;

            for (uint i = 0; i <= widthInCells; i++)
            {
                if (plane == 0)
                {
                    /* В плоскости XY. */
                    Line.Draw(gl, center.X - gridLength / 2.0f, center.Y - gridWidth / 2.0f + cellSize * i, center.Z,
                            center.X + gridLength / 2.0f, center.Y - gridWidth / 2.0f + cellSize * i, center.Z, width, color);
                }
                else if (plane == 1)
                {
                    /* В плоскости YZ. */
                    Line.Draw(gl, center.X, center.Y - gridWidth / 2.0f + cellSize * i, center.Z - gridLength / 2.0f,
                            center.X, center.Y - gridWidth / 2.0f + cellSize * i, center.Z + gridLength / 2.0f, width, color);
                }
                else
                {
                    /* В плоскости XZ. */
                    Line.Draw(gl, center.X - gridLength / 2.0f, center.Y, center.Z - gridWidth / 2.0f + cellSize * i,
                            center.X + gridLength / 2.0f, center.Y, center.Z - gridWidth / 2.0f + cellSize * i, width, color);
                }
            }

            for (uint j = 0; j <= lengthInCells; j++)
            {
                if (plane == 0)
                {
                    Line.Draw(gl, center.X - gridLength / 2.0f + cellSize * j, center.Y - gridWidth / 2.0f, center.Z,
                            center.X - gridLength / 2.0f + cellSize * j, center.Y + gridWidth / 2.0f, center.Z, width, color);
                }
                else if (plane == 1)
                {
                    Line.Draw(gl, center.X, center.Y - gridWidth / 2.0f, center.Z - gridLength / 2.0f + cellSize * j,
                            center.X, center.Y + gridWidth / 2.0f, center.Z - gridLength / 2.0f + cellSize * j, width, color);
                }
                else
                {
                    Line.Draw(gl, center.X - gridLength / 2.0f + cellSize * j, center.Y, center.Z - gridWidth / 2.0f,
                            center.X - gridLength / 2.0f + cellSize * j, center.Y, center.Z + gridWidth / 2.0f, width, color);
                }
            }
        }

        public object Clone()
        {
            return new Grid(this.center, this.cellSize, this.lengthInCells, this.widthInCells);
        }
    }
}
