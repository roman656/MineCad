using SharpGL;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Point = MineCad.Geometry.Primitives.Flat.Point;

namespace MineCad.Geometry.Primitives.Volumetric.Bullets
{
    public class HighExplosiveBullet : IBullet
    {
        private Point center = new Point();
        private int timeDelay = 60;
        private Point step = new Point(5.0f, 0.0f, 0.0f);
        private float distance = 100.0f;
        private Sphere model = new Sphere(new Point(), 0.5f, 12);

        public HighExplosiveBullet() {}

        public HighExplosiveBullet(in Point center)
        {
            this.center = (Point)center.Clone();
            this.model.Center = this.center;
        }

        public Point Step
        {
            get
            {
                return (Point)this.step.Clone();
            }

            set
            {
                this.step = (Point)value.Clone();
            }
        }

        public async void Run()
        {
            await Task.Run(() =>
            {
                this.center.X += step.X;
                this.center.Y += step.Y;
                this.center.Z += step.Z;

                this.model.Center = this.center;

                Thread.Sleep(this.timeDelay);
            });
        }

        public void Draw(OpenGL gl, Color color)
        {
            this.model.DrawArea(gl, color);
        }

        public object Clone()
        {
            return new HighExplosiveBullet(this.center);
        }
    }
}
