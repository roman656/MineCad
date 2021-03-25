using System;
using System.Windows.Forms;
using SharpGL;

namespace MineCad
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        /* Настройка цвета фона OpenGLControl. */
        private const float BACKGROUND_COLOR_R = 0.3f;
        private const float BACKGROUND_COLOR_G = 0.3f;
        private const float BACKGROUND_COLOR_B = 0.4f;

        /* Режимы работы. */
        private bool isRotatingMode = false;
        private bool isMovingMode = false;
        private bool isZoomingMode = false;

        private bool isCreatingCube = false;
        private float cubeSize = 10.0f;
        private float cubeX = 0.0f;
        private float cubeY = 0.0f;
        private bool isCubeCreated = false;


        /* Координаты последнего клика мышью в рабочей зоне. */
        private int pressedMouseX = 0;
        private int pressedMouseY = 0;

        /* Параметры, отвечающие за перемещение сцены. */
        private float newXCoordinate = 0.0f;
        private float newYCoordinate = 0.0f;
        private float movingSpeed = 0.02f;

        /* Параметры, отвечающие за масштаб сцены. */
        private float zoom = 1.0f;
        private float zoomSpeed = 0.005f;

        /* Параметры, отвечающие за вращение сцены. */
        private float axisRotateX = 15.0f;
        private float axisRotateY = -45.0f;
        private float rotationSpeed = 1.0f;

        /* Параметры главной системы координат. */
        private float coordinateSystemSize = 25.0f;
        private float coordinateSystemLineWidth = 3.0f;

        /* Параметры главной сетки. */
        private float gridSize = 20.0f;
        private float gridCellSize = 2.0f;
        private float gridLineWidth = 1.0f;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            /* Получение ссылки на окно OpenGL. */
        OpenGL gl = this.openGLControl.OpenGL;

            /* Установка цвета очистки экрана. */
            gl.ClearColor(BACKGROUND_COLOR_R, BACKGROUND_COLOR_G, BACKGROUND_COLOR_B, 0.0f);
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl.OpenGL;

            /* Очистка экрана и буфера глубины. */
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();

            /* Перемещение сцены. */
            gl.Translate(this.newXCoordinate, this.newYCoordinate, -10.0f);

            /* Вращение вокруг сцены. */
            gl.Rotate(this.axisRotateX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(this.axisRotateY, 0.0f, 1.0f, 0.0f);

            /* Масштаб сцены. */
            gl.Scale(this.zoom, this.zoom, this.zoom);

            /* Отрисовка главной системы координат. */
            GLDrawHelper.drawAxis3D(gl, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, this.coordinateSystemSize,
                    this.coordinateSystemSize, this.coordinateSystemSize, this.coordinateSystemLineWidth,
                    System.Drawing.Color.Red, System.Drawing.Color.GreenYellow,
                    System.Drawing.Color.DeepSkyBlue);

            /* Отрисовка главной сетки. */
            GLDrawHelper.drawGrid2D(gl, 2, 0.0f, 0.0f, 0.0f, -1.0f * this.gridSize,
                    this.gridSize, this.gridCellSize, this.gridLineWidth,
                    System.Drawing.Color.DarkGray);

            /* Создание пирамиды. */
            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);

            gl.End();
            
            if (this.isCreatingCube)
            {
                GLDrawHelper.drawCube3D(gl, this.cubeX, this.cubeY, 0.0f, this.cubeSize, 3.0f, System.Drawing.Color.OrangeRed);
            }

            if (this.isCubeCreated)
            {
                GLDrawHelper.drawCube3D(gl, this.cubeX, this.cubeY, 0.0f, this.cubeSize, 5.0f, System.Drawing.Color.LightSkyBlue);
            }

            gl.LoadIdentity();
        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!this.isCreatingCube)
                {
                    this.isRotatingMode = true;
                }
                else
                {
                    this.isCreatingCube = false;
                    this.isCubeCreated = true;
                }
            }
            else if (e.Button == MouseButtons.Right) 
            { 
                this.isMovingMode = true; 
            }
            else if (e.Button == MouseButtons.Middle) 
            {
                this.isZoomingMode = true;
            }

            this.pressedMouseX = e.X;
            this.pressedMouseY = e.Y;
        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isRotatingMode = false;
            this.isMovingMode = false;
            this.isZoomingMode = false;
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            int deltaX = this.pressedMouseX - e.X;
            int deltaY = this.pressedMouseY - e.Y;

            if (this.isMovingMode)
            {
                this.newXCoordinate -= this.movingSpeed * deltaX;
                this.newYCoordinate += this.movingSpeed * deltaY;
            }
            else if (this.isRotatingMode)
            {
                this.axisRotateX -= this.rotationSpeed * deltaY;
                this.axisRotateY -= this.rotationSpeed * deltaX;
            }
            else if (this.isZoomingMode)
            {
                this.zoom = ((this.zoom + deltaY * this.zoomSpeed) > 0.0f) ?
                        (this.zoom + deltaY * this.zoomSpeed) : this.zoom;
            }
            else if (this.isCreatingCube)
            {
                this.cubeSize += this.movingSpeed * deltaX;
                this.cubeSize += this.movingSpeed * deltaY;
            }

            this.pressedMouseX = e.X;
            this.pressedMouseY = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Сброс параметров, отвечающих за перемещение сцены. */
            this.newXCoordinate = 0.0f;
            this.newYCoordinate = 0.0f;

            /* Сброс параметров, отвечающих за масштаб сцены. */
            this.zoom = 1.0f;

            /* Сброс параметров, отвечающих за вращение сцены. */
            this.axisRotateX = 15.0f;
            this.axisRotateY = -45.0f;
    }

        private void button2_Click(object sender, EventArgs e)
        {
            this.isCreatingCube = true;
            this.isCubeCreated = false;
            this.pressedMouseX = 0;
            this.pressedMouseY = 0;
        }
    }
}
