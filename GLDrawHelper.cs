using System.Drawing;
using System.Collections.Generic;
using System;

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

        // TODO: реализовать функционал гизмо.
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

        public static void DrawPyramid(SharpGL.OpenGL gl, float width, float height, float depth, Color polygonColor, Color lineColor)
        {
            float pR = polygonColor.R / 255.0f;
            float pG = polygonColor.G / 255.0f;
            float pB = polygonColor.B / 255.0f;
            gl.Color(pR, pG, pB);

            gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(width / 2, 0f, depth / 2);
            gl.Vertex(-width / 2, 0f, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(width / 2, 0f, -depth / 2);
            gl.Vertex(width / 2, 0f, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(-width / 2, 0f, -depth / 2);
            gl.Vertex(width / 2, 0f, -depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(-width / 2, 0f, depth / 2);
            gl.Vertex(-width / 2, 0f, -depth / 2);
            gl.End();


            gl.Begin(SharpGL.OpenGL.GL_QUADS);
            gl.Vertex(-width / 2, 0.0f, depth / 2);
            gl.Vertex(width / 2, 0.0f, depth / 2);
            gl.Vertex(width / 2, 0.0f, -depth / 2);
            gl.Vertex(-width / 2, 0.0f, -depth / 2);
            gl.End();

            float lR = lineColor.R / 255.0f;
            float lG = lineColor.G / 255.0f;
            float lB = lineColor.B / 255.0f;
            gl.Color(lR, lG, lB);

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(width / 2, 0f, depth / 2);
            gl.Vertex(-width / 2, 0f, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(width / 2, 0f, -depth / 2);
            gl.Vertex(width / 2, 0f, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(-width / 2, 0f, -depth / 2);
            gl.Vertex(width / 2, 0f, -depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(-width / 2, 0f, depth / 2);
            gl.Vertex(-width / 2, 0f, -depth / 2);
            gl.End();
        }

        public static void DrawCylinder(SharpGL.OpenGL gl, float height, double radiusBottom, double radiusTop, int polCount, Color polColour, Color lineColour)
        {

            float diVal = 360 / polCount;

            float pR = polColour.R / 255.0f;
            float pG = polColour.G / 255.0f;
            float pB = polColour.B / 255.0f;

            float lR = lineColour.R / 255.0f;
            float lG = lineColour.G / 255.0f;
            float lB = lineColour.B / 255.0f;

            gl.Color(lR, lG, lB);

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);

            double degrees = 0;

            List<Tuple<double, double>> coordsBottom = new List<Tuple<double, double>>();

            List<Tuple<double, double>> coordsTop = new List<Tuple<double, double>>();

            for (int i = 0; i < polCount; i++)
            {
                double angle = Math.PI * degrees / 180.0;

                Tuple<double, double> tmpBottom = new Tuple<double, double>(Math.Cos(angle) * radiusBottom, Math.Sin(angle) * radiusBottom);

                Tuple<double, double> tmpTop = new Tuple<double, double>(Math.Cos(angle) * radiusTop, Math.Sin(angle) * radiusTop);

                gl.Vertex(tmpBottom.Item1, 0f, tmpBottom.Item2);

                coordsBottom.Add(tmpBottom);

                coordsTop.Add(tmpTop);

                degrees += diVal;
            }
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < polCount; i++)
            {
                gl.Vertex(coordsTop[i].Item1, height, coordsTop[i].Item2);
            }
            gl.End();

            gl.Color(pR, pG, pB);

            for (int i = 0; i < polCount-1; i++)
            {
                gl.Begin(SharpGL.OpenGL.GL_POLYGON);
                gl.Vertex(coordsBottom[i].Item1, 0f, coordsBottom[i].Item2);
                gl.Vertex(coordsTop[i].Item1, height, coordsTop[i].Item2);
                gl.Vertex(coordsTop[i + 1].Item1, height, coordsTop[i + 1].Item2);
                gl.Vertex(coordsBottom[i + 1].Item1, 0f, coordsBottom[i + 1].Item2);
                gl.End();
            }

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);
            gl.Vertex(coordsBottom[polCount - 1].Item1, 0f, coordsBottom[polCount - 1].Item2);
            gl.Vertex(coordsTop[polCount - 1].Item1, height, coordsTop[polCount - 1].Item2);
            gl.Vertex(coordsTop[0].Item1, height, coordsTop[0].Item2);
            gl.Vertex(coordsBottom[0].Item1, 0f, coordsBottom[0].Item2);
            gl.End();

            for (int i = 0; i < polCount - 1; i++)
            {
                gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);
                gl.Vertex(coordsBottom[i].Item1, 0f, coordsBottom[i].Item2);
                gl.Vertex(coordsBottom[i+1].Item1, 0f, coordsBottom[i+1].Item2);
                gl.Vertex(0f, 0f, 0f);
                gl.End();

                gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);
                gl.Vertex(coordsTop[i].Item1, height, coordsTop[i].Item2);
                gl.Vertex(coordsTop[i + 1].Item1, height, coordsTop[i + 1].Item2);
                gl.Vertex(0f, height, 0f);
                gl.End();
            }

            gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);
            gl.Vertex(coordsBottom[polCount - 1].Item1, 0f, coordsBottom[polCount - 1].Item2);
            gl.Vertex(coordsBottom[0].Item1, 0f, coordsBottom[0].Item2);
            gl.Vertex(0f, 0f, 0f);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);
            gl.Vertex(coordsTop[polCount - 1].Item1, height, coordsTop[polCount - 1].Item2);
            gl.Vertex(coordsTop[0].Item1, height, coordsTop[0].Item2);
            gl.Vertex(0f, height, 0f);
            gl.End();
        }

        public static void DrawSphere(SharpGL.OpenGL gl, float diameter, Color polygonColor, Color lineColor)
        {
            int sph_ng = 24; float sph_radius = diameter / 2;

            List<double[,]> slices = new List<double[,]>();

            double dPhi = 2 * Math.PI / sph_ng;
            double dPsi = 2 * Math.PI / sph_ng;
            for (int i = 0; i <= sph_ng; i++)
            {
                double[,] slice = new double[sph_ng + 1, 3];

                double Psi = -Math.PI + dPsi * i;

                for (int j = 0; j <= sph_ng; ++j)
                {
                    double Phi = dPhi * j;

                    double x = (sph_radius * Math.Cos(Phi));
                    double y = (sph_radius * Math.Sin(Phi)) * Math.Sin(Psi);
                    double z = (sph_radius * Math.Sin(Phi)) * Math.Cos(Psi);
                    slice[j, 0] = x; slice[j, 1] = y; slice[j, 2] = z;
                }
                slices.Add(slice);
            }

            float pR = polygonColor.R / 255.0f;
            float pG = polygonColor.G / 255.0f;
            float pB = polygonColor.B / 255.0f;
            gl.Color(pR, pG, pB);

            for (int i = 0; i < slices.Count - 1; i++)
            {
                for (int j = 0; j < sph_ng; ++j)
                {
                    gl.Begin(SharpGL.OpenGL.GL_QUADS);
                    gl.Vertex(slices[i][j, 0], slices[i][j, 1], slices[i][j, 2]);
                    gl.Vertex(slices[i + 1][j, 0], slices[i + 1][j, 1], slices[i + 1][j, 2]);
                    gl.Vertex(slices[i + 1][j + 1, 0], slices[i + 1][j + 1, 1], slices[i + 1][j + 1, 2]);
                    gl.Vertex(slices[i][j + 1, 0], slices[i][j + 1, 1], slices[i][j + 1, 2]);
                    gl.End();
                }
            }


            float lR = lineColor.R / 255.0f;
            float lG = lineColor.G / 255.0f;
            float lB = lineColor.B / 255.0f;
            gl.Color(lR, lG, lB);

            for (int i = 0; i < slices.Count - 1; i++)
            {
                for (int j = 0; j < sph_ng; ++j)
                {
                    gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
                    gl.Vertex(slices[i][j, 0], slices[i][j, 1], slices[i][j, 2]);
                    gl.Vertex(slices[i + 1][j, 0], slices[i + 1][j, 1], slices[i + 1][j, 2]);
                    gl.Vertex(slices[i + 1][j + 1, 0], slices[i + 1][j + 1, 1], slices[i + 1][j + 1, 2]);
                    gl.Vertex(slices[i][j + 1, 0], slices[i][j + 1, 1], slices[i][j + 1, 2]);
                    gl.End();
                }
            }
        }
    }
}