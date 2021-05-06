using SharpGL;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace MineCad
{
    class Bullet
    {
        private Point center = new Point();
        private int timeDelay = 60;
        private Point step = new Point(5.0f, 0.0f, 0.0f);
        private float distance = 100.0f;

        public Bullet() {}

        public Bullet(in Point center)
        {
            this.center = (Point)center.Clone();
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

        public async void Go()
        {
            await Task.Run(() =>
            {
                this.center.X += step.X;
                this.center.Y += step.Y;
                this.center.Z += step.Z;

                Thread.Sleep(this.timeDelay);
            });
        }

        public void Draw(OpenGL gl, float diameter, Color color)
        {
            gl.Translate(this.center.X, this.center.Y, this.center.Z);

            GLDrawHelper.DrawSphere(gl, diameter, color, color);

            gl.Translate(-this.center.X, -this.center.Y, -this.center.Z);
        }
    }
}
