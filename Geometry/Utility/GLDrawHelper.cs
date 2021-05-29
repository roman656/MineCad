using System.Drawing;
using System.Collections.Generic;
using System;

namespace MineCad
{
    public static class GLDrawHelper
    {
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
    }
}