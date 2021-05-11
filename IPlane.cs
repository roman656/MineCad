using System;
using System.Drawing;

namespace MineCad
{
    interface IPlane : ICloneable, IMineCadObject
    {
        bool CheckPoints(in Point[] points);
        void Draw(SharpGL.OpenGL gl, Point[] points, Color color);
        void Draw(SharpGL.OpenGL gl, Color color);
        void DrawOutline(SharpGL.OpenGL gl, float width, Color color);
    }
}