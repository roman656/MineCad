using SharpGL;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace MineCad
{
    class Tank : ICloneable
    {
        private int timeDelay = 60;
        private Point center = new Point();
        private Point step = new Point(0.15f, 0.0f, 0.0f);
        private Point rotationValue = new Point();
        private Point direction = new Point(1.0f, 1.0f, 1.0f);

        private Plane[] turret = { new Plane(new Point(3, 3.5f, 1.5f), new Point(3, 3.5f, -1.5f), new Point(3.3f, 2, -1.5f)),
                                   new Plane(new Point(-2, 3.5f, -1.5f), new Point(-2, 3.5f, 1.5f), new Point(-1.7f, 2, 1.5f)),
                                   new Plane(new Point(-2, 3.5f, 1.5f), new Point(-2, 3.5f, -1.5f), new Point(3, 3.5f, -1.5f)),
                                   new Plane(new Point(-2, 3.5f, 1.5f), new Point(3, 3.5f, 1.5f), new Point(3.3f, 2, 1.5f)),
                                   new Plane(new Point(-2, 3.5f, -1.5f), new Point(3, 3.5f, -1.5f), new Point(3.3f, 2, -1.5f)) };

        private Plane[] hull = { new Plane(new Point(5, 2, 4), new Point(5, 2, -4), new Point(7, 0, -4)),
                                 new Plane(new Point(-5, 2, -4), new Point(-5, 2, 4), new Point(-5, 0, 4)),
                                 new Plane(new Point(-5, 2, 4), new Point(-5, 2, -4), new Point(5, 2, -4)),
                                 new Plane(new Point(7, 0, 2.5f), new Point(7, 0, -2.5f), new Point(5, -1, -2.5f)),
                                 new Plane(new Point(-5f, 0, -2.5f), new Point(-5f, 0, 2.5f), new Point(-4.3f, -1, 2.5f)),
                                 new Plane(new Point(-4.3f, -1, -2.5f), new Point(-4.3f, -1, 2.5f), new Point(5, -1, 2.5f)),
                                 new Plane(new Point(-7, 2, 4), new Point(5, 2, 4), new Point(7, 0, 4)),
                                 new Plane(new Point(5, 2, -4), new Point(-7, 2, -4), new Point(-5, 0, -4)) };

        public Tank() {}

        public Tank(in Point center)
        {
            this.center = (Point)center.Clone();
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

        public Point Direction
        {
            get
            {
                return (Point)this.direction.Clone();
            }

            set
            {
                this.direction = (Point)value.Clone();
            }
        }

        public Point RotationValue
        {
            get
            {
                return (Point)this.rotationValue.Clone();
            }

            set
            {
                this.rotationValue = (Point)value.Clone();
            }
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

        public Bullet Fire()
        {
            Bullet bullet = new Bullet(new Point(this.center.X, 2.7f + this.center.Y, this.center.Z));

            if (this.rotationValue.Y < 0.0f)
            {
                Point temp = ((Point)bullet.Step.Clone());
                temp.X = ((Point)bullet.Step.Clone()).X * -1.0f;
                bullet.Step = temp;
            }


            return bullet;
        }

        public void Draw(OpenGL gl, Color gunColor, Color turretColor, Color hullColor)
        {
            gl.Translate(this.center.X * this.direction.X, this.center.Y * this.direction.Y, this.center.Z * this.direction.Z);
            gl.Rotate(this.rotationValue.X, this.rotationValue.Y, this.rotationValue.Z);

            foreach (var temp in this.turret)
            {
                temp.Draw(gl, turretColor);
                temp.DrawOutline(gl, 3, Color.YellowGreen);
            }
            
            foreach (var temp in this.hull)
            {
                temp.Draw(gl, hullColor);
                temp.DrawOutline(gl, 3, Color.YellowGreen);
            }

            gl.Translate(2.5f, 2.7f, 0);
            gl.Rotate(-90.0f, 0.0f, 0.0f, 1.0f);

            GLDrawHelper.DrawCylinder(gl, 6.0f, 0.1f, 0.1f, 12, gunColor, Color.YellowGreen);

            gl.Rotate(90.0f, 0.0f, 0.0f, 1.0f);
            gl.Translate(-2.5f, -2.7f, 0);

            gl.Rotate(-this.rotationValue.X, -this.rotationValue.Y, -this.rotationValue.Z);
            gl.Translate(-this.center.X * this.direction.X, -this.center.Y * this.direction.Y, -this.center.Z * this.direction.Z);
        }

        public object Clone()
        {
            return new Tank();
        }
    }
}
