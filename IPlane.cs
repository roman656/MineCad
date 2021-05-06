using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineCad
{
    interface IPlane:ICloneable
    {
        bool CheckPoints(in Point leftTop, in Point rigthTop, in Point rigthBottom);
        void Draw(SharpGL.OpenGL gl, in Point leftTop, in Point rigthTop, in Point rigthBottom, Color color);
        void Draw(SharpGL.OpenGL gl, Color color);
    }
}
