using System;
using System.Drawing;

namespace MineCad
{
    interface IPlane : ICloneable
    {
        bool CheckPoints(in Point[] points);
        void Draw(SharpGL.OpenGL gl, Point[] points, Color color);
        void Draw(SharpGL.OpenGL gl, Color color);
    }
}
