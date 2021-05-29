using MineCad.Geometry.Primitives.Flat;
using System.Collections.Generic;

namespace MineCad.Utility
{
    public class DrawerSTL
    {
        public static void DrawSTL(SharpGL.OpenGL gl, List<float[,]> stlData, int scale, float angle, Point vector, System.Drawing.Color polygonColor, System.Drawing.Color lineColor)
        {
            float scaleCoefficient = (float)scale / 100;

            if (stlData.Count <= 0) { return; }

            gl.Rotate(angle, vector.X, vector.Y, vector.Z);

            for (int i = 0; i < stlData.Count; i++)
            {
                float pR = polygonColor.R / 255.0f;
                float pG = polygonColor.G / 255.0f;
                float pB = polygonColor.B / 255.0f;
                gl.Color(pR, pG, pB);

                gl.Begin(SharpGL.Enumerations.BeginMode.Polygon);
                gl.Vertex(stlData[i][0, 0] * scaleCoefficient, stlData[i][0, 1] * scaleCoefficient, stlData[i][0, 2] * scaleCoefficient);
                gl.Vertex(stlData[i][1, 0] * scaleCoefficient, stlData[i][1, 1] * scaleCoefficient, stlData[i][1, 2] * scaleCoefficient);
                gl.Vertex(stlData[i][2, 0] * scaleCoefficient, stlData[i][2, 1] * scaleCoefficient, stlData[i][2, 2] * scaleCoefficient);
                gl.End();
            }

            for (int i = 0; i < stlData.Count; i++)
            {
                float lR = lineColor.R / 255.0f;
                float lG = lineColor.G / 255.0f;
                float lB = lineColor.B / 255.0f;
                gl.Color(lR, lG, lB);

                gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
                gl.Vertex(stlData[i][0, 0] * scaleCoefficient, stlData[i][0, 1] * scaleCoefficient, stlData[i][0, 2] * scaleCoefficient);
                gl.Vertex(stlData[i][1, 0] * scaleCoefficient, stlData[i][1, 1] * scaleCoefficient, stlData[i][1, 2] * scaleCoefficient);
                gl.Vertex(stlData[i][2, 0] * scaleCoefficient, stlData[i][2, 1] * scaleCoefficient, stlData[i][2, 2] * scaleCoefficient);
                gl.End();
            }

            gl.Rotate(-angle, vector.X, vector.Y, vector.Z);
        }
    }
}