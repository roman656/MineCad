using System.Drawing;

namespace MineCad
{
    public static class GLDrawHelper
    {
        /* 
         * Константа, необходимая для конвертации RGB цвета [0; 255]
         * в RGB цвет [0.0f; 1.0f].
         */
        private const float colorConversionConstant = byte.MaxValue;

        public static void DrawLine3D(SharpGL.OpenGL gl, float beginX, float beginY, float beginZ,
                                                         float endX,   float endY,   float endZ,
                                                         float width, Color color)
        {
            /* Установка толщины линии. */
            gl.LineWidth(width);

            /* Установка цвета линии. */
            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_LINES);

            gl.Vertex(beginX, beginY, beginZ);
            gl.Vertex(endX, endY, endZ);

            gl.End();
        }

        public static void DrawAxis3D(SharpGL.OpenGL gl, float beginX,    float beginY,    float beginZ,
                                                         float minXValue, float minYValue, float minZValue,
                                                         float maxXValue, float maxYValue, float maxZValue,
                                                         float width,
                                                         Color axisXColor, Color axisYColor, Color axisZColor)
        {
            /* Ось OX. */
            DrawLine3D(gl, beginX + minXValue, beginY, beginZ,
                           beginX + maxXValue, beginY, beginZ,
                           width, axisXColor);

            /* Ось OY. */
            DrawLine3D(gl, beginX, beginY + minYValue, beginZ,
                           beginX, beginY + maxYValue, beginZ,
                           width, axisYColor);

            /* Ось OZ. */
            DrawLine3D(gl, beginX, beginY, beginZ + minZValue,
                           beginX, beginY, beginZ + maxZValue,
                           width, axisZColor);
        }

        public static void DrawGrid2D(SharpGL.OpenGL gl, int plane, float beginX, float beginY, float beginZ,
                float minValue, float maxValue, float cellSize, float width, Color color)
        {
            /* Определение количества линий по одной оси. */
            int linesAmount = (int) System.Math.Ceiling((maxValue - minValue) / cellSize);
            linesAmount++;

            /* Отрисовка сетки. */
            for (var i = linesAmount; i > 0; i--)
            {
                if (plane == 0)
                {
                    /* В плоскости XY. */
                    DrawLine3D(gl,
                            beginX + minValue, beginY + minValue + (cellSize * (i - 1)), beginZ,
                            beginX + maxValue, beginY + minValue + (cellSize * (i - 1)), beginZ,
                            width, color);

                    DrawLine3D(gl,
                            beginX + minValue + (cellSize * (i - 1)), beginY + minValue, beginZ,
                            beginX + minValue + (cellSize * (i - 1)), beginY + maxValue, beginZ,
                            width, color);
                }
                else if (plane == 1)
                {
                    /* В плоскости YZ. */
                    DrawLine3D(gl,
                            beginX, beginY + minValue + (cellSize * (i - 1)), beginZ + minValue,
                            beginX, beginY + minValue + (cellSize * (i - 1)), beginZ + maxValue,
                            width, color);

                    DrawLine3D(gl,
                            beginX, beginY + minValue, beginZ + minValue + (cellSize * (i - 1)),
                            beginX, beginY + maxValue, beginZ + minValue + (cellSize * (i - 1)),
                            width, color);
                }
                else
                {
                    /* В плоскости XZ. */
                    DrawLine3D(gl,
                            beginX + minValue, beginY, beginZ + minValue + (cellSize * (i - 1)),
                            beginX + maxValue, beginY, beginZ + minValue + (cellSize * (i - 1)),
                            width, color);

                    DrawLine3D(gl,
                            beginX + minValue + (cellSize * (i - 1)), beginY, beginZ + minValue,
                            beginX + minValue + (cellSize * (i - 1)), beginY, beginZ + maxValue,
                            width, color);
                }
            }
        }

        //TODO: реализовать функционал гизмо.
        public static void DrawStartTriangle(SharpGL.OpenGL gl)
        {
            /* Создание пирамиды. */
            gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);

            // XY triangle
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 0.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, 0.0f, 0.0f);

            // ZY triangle
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 0.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(0.0f, 0.0f, 1.0f);

            // XZ triangle
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, 0.0f, 0.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 0.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(0.0f, 0.0f, 1.0f);

            // XYZ triangle
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, 0.0f, 0.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(0.0f, 0.0f, 1.0f);

            gl.End();
        }

        public static void DrawQuadrate2D(SharpGL.OpenGL gl, int plane,
                float beginX, float beginY, float beginZ,
                float size, float linesWidth, Color color)
        {
            /* Установка толщины линий. */
            gl.LineWidth(linesWidth);

            /* Установка цвета линий. */
            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);

            /* Отрисовка контура квадрата. */
            if (plane == 0)
            {
                /* В плоскости XY. */
                gl.Vertex(beginX + (size / 2.0f), beginY + (size / 2.0f), beginZ);
                gl.Vertex(beginX + (size / 2.0f), beginY - (size / 2.0f), beginZ);
                gl.Vertex(beginX - (size / 2.0f), beginY - (size / 2.0f), beginZ);
                gl.Vertex(beginX - (size / 2.0f), beginY + (size / 2.0f), beginZ);
            }
            else if (plane == 1)
            {
                /* В плоскости YZ. */
                gl.Vertex(beginX, beginY + (size / 2.0f), beginZ + (size / 2.0f));
                gl.Vertex(beginX, beginY - (size / 2.0f), beginZ + (size / 2.0f));
                gl.Vertex(beginX, beginY - (size / 2.0f), beginZ - (size / 2.0f));
                gl.Vertex(beginX, beginY + (size / 2.0f), beginZ - (size / 2.0f));
            }
            else
            {
                /* В плоскости XZ. */
                gl.Vertex(beginX + (size / 2.0f), beginY, beginZ + (size / 2.0f));
                gl.Vertex(beginX - (size / 2.0f), beginY, beginZ + (size / 2.0f));
                gl.Vertex(beginX - (size / 2.0f), beginY, beginZ - (size / 2.0f));
                gl.Vertex(beginX + (size / 2.0f), beginY, beginZ - (size / 2.0f));
            }

            gl.End();
        }

        public static void DrawCube3D(SharpGL.OpenGL gl,
                float beginX, float beginY, float beginZ,
                float size, float linesWidth, Color color)
        {
            /* В плоскости XZ. */
            DrawQuadrate2D(gl, 2, beginX, beginY,        beginZ, size, linesWidth, color);
            DrawQuadrate2D(gl, 2, beginX, beginY + size, beginZ, size, linesWidth, color);

            /* В плоскости YZ. */
            DrawQuadrate2D(gl, 1, beginX + (size / 2.0f), beginY + (size / 2.0f), beginZ,
                    size, linesWidth, color);
            DrawQuadrate2D(gl, 1, beginX - (size / 2.0f), beginY + (size / 2.0f), beginZ,
                    size, linesWidth, color);
        }

        //TODO: implemet  this.
        public static void DrawSolid(SharpGL.OpenGL gl) {}

        public static void DrawPlane2D(SharpGL.OpenGL gl, int plane,
                float beginX, float beginY, float beginZ, float size, Color color)
        {
            /* Установка цвета полигона (плоскости). */
            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);

            if (plane == 0)
            {
                /* В плоскости XY. */
                gl.Vertex(beginX + (size / 2.0f), beginY + (size / 2.0f), beginZ);
                gl.Vertex(beginX + (size / 2.0f), beginY - (size / 2.0f), beginZ);
                gl.Vertex(beginX - (size / 2.0f), beginY - (size / 2.0f), beginZ);
                gl.Vertex(beginX - (size / 2.0f), beginY + (size / 2.0f), beginZ);
            }
            else if (plane == 1)
            {
                /* В плоскости YZ. */
                gl.Vertex(beginX, beginY + (size / 2.0f), beginZ + (size / 2.0f));
                gl.Vertex(beginX, beginY - (size / 2.0f), beginZ + (size / 2.0f));
                gl.Vertex(beginX, beginY - (size / 2.0f), beginZ - (size / 2.0f));
                gl.Vertex(beginX, beginY + (size / 2.0f), beginZ - (size / 2.0f));
            }
            else
            {
                /* В плоскости XZ. */
                gl.Vertex(beginX + (size / 2.0f), beginY, beginZ + (size / 2.0f));
                gl.Vertex(beginX - (size / 2.0f), beginY, beginZ + (size / 2.0f));
                gl.Vertex(beginX - (size / 2.0f), beginY, beginZ - (size / 2.0f));
                gl.Vertex(beginX + (size / 2.0f), beginY, beginZ - (size / 2.0f));
            }

            gl.End();
        }

        public static void DrawFilledBox3D(SharpGL.OpenGL gl,
                float beginX, float beginY, float beginZ,
                float xSize,  float ySize, float zSize, Color color)
        {
            gl.Color(color.R / colorConversionConstant,
                     color.G / colorConversionConstant,
                     color.B / colorConversionConstant);

            /* В плоскости XZ. */
            gl.Begin(SharpGL.OpenGL.GL_POLYGON);

            gl.Vertex(beginX + xSize / 2.0f, beginY, beginZ - zSize / 2.0f);
            gl.Vertex(beginX + xSize / 2.0f, beginY, beginZ + zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY, beginZ + zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY, beginZ - zSize / 2.0f);

            gl.End();

            /* В плоскости YZ. */
            gl.Begin(SharpGL.OpenGL.GL_POLYGON);

            gl.Vertex(beginX + xSize / 2.0f, beginY,         beginZ - zSize / 2.0f);
            gl.Vertex(beginX + xSize / 2.0f, beginY,         beginZ + zSize / 2.0f);
            gl.Vertex(beginX + xSize / 2.0f, beginY + ySize, beginZ + zSize / 2.0f);
            gl.Vertex(beginX + xSize / 2.0f, beginY + ySize, beginZ - zSize / 2.0f);

            gl.End();

            /* В плоскости XZ. */
            gl.Begin(SharpGL.OpenGL.GL_POLYGON);

            gl.Vertex(beginX + xSize / 2.0f, beginY + ySize, beginZ - zSize / 2.0f);
            gl.Vertex(beginX + xSize / 2.0f, beginY + ySize, beginZ + zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY + ySize, beginZ + zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY + ySize, beginZ - zSize / 2.0f);

            gl.End();

            /* В плоскости YZ. */
            gl.Begin(SharpGL.OpenGL.GL_POLYGON);

            gl.Vertex(beginX - xSize / 2.0f, beginY,         beginZ - zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY,         beginZ + zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY + ySize, beginZ + zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY + ySize, beginZ - zSize / 2.0f);

            gl.End();

            /* В плоскости XY. */
            gl.Begin(SharpGL.OpenGL.GL_POLYGON);

            gl.Vertex(beginX + xSize / 2.0f, beginY,         beginZ - zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY,         beginZ - zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY + ySize, beginZ - zSize / 2.0f);
            gl.Vertex(beginX + xSize / 2.0f, beginY + ySize, beginZ - zSize / 2.0f);

            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);

            gl.Vertex(beginX + xSize / 2.0f, beginY,         beginZ + zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY,         beginZ + zSize / 2.0f);
            gl.Vertex(beginX - xSize / 2.0f, beginY + ySize, beginZ + zSize / 2.0f);
            gl.Vertex(beginX + xSize / 2.0f, beginY + ySize, beginZ + zSize / 2.0f);

            gl.End();
        }

        public static void DrawFilledCube3D(SharpGL.OpenGL gl,
                float beginX, float beginY, float beginZ, float size, Color color)
        {
            DrawFilledBox3D(gl, beginX, beginY, beginZ, size, size, size, color);
        }
    }
}