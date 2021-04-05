using System;
using System.Windows.Forms;
using SharpGL;

namespace MineCad
{
    public partial class MainForm : Form
    {
        /* Настройка цвета фона OpenGLControl. */
        private const float backgroundColorRConstant = 0.3f;
        private const float backgroundColorGConstant = 0.3f;
        private const float backgroundColorBConstant = 0.4f;

        /* Режимы работы. */
        private bool isRotatingMode = false;
        private bool isMovingMode = false;
        private bool isZoomingMode = false;

        /* В тестовом режиме проверка создания куба. */
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
        private bool isAxisVisible = true;
        private float coordinateSystemSize = 30.0f;
        private float coordinateSystemLineWidth = 3.0f;

        /* Параметры главных сеток. */
        private bool isXYGridVisible = false;
        private bool isYZGridVisible = false;
        private bool isXZGridVisible = true;
        private float gridSize = 60.0f;
        private float gridCellSize = 2.0f;
        private float gridLineWidth = 1.0f;

        /* Параметры гизмо. Тест. */
        private bool isStartVisible = false;

        private bool isPyramidVisible = false;
        private bool isCylinderVisible = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            /* Получение ссылки на окно OpenGL. */
            OpenGL gl = this.openGLControl.OpenGL;

            /* Установка цвета очистки экрана. */
            gl.ClearColor(backgroundColorRConstant, backgroundColorGConstant, backgroundColorBConstant, 0.0f);
        }

        private void OpenGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
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
            if (this.isAxisVisible)
            {
                GLDrawHelper.DrawAxis3D(gl,
                    0.0f, 0.0f, 0.0f,
                    0.0f, 0.0f, 0.0f,
                    this.coordinateSystemSize, this.coordinateSystemSize, this.coordinateSystemSize,
                    this.coordinateSystemLineWidth,
                    System.Drawing.Color.Red, System.Drawing.Color.GreenYellow, System.Drawing.Color.DeepSkyBlue);
            }

            /* Создание гизмо в центре. */
            if (this.isStartVisible)
            {
                GLDrawHelper.DrawStartTriangle(gl);
            }

            /* Отрисовка главных сеток. */
            if (this.isXYGridVisible)
            {
                GLDrawHelper.DrawGrid2D(gl, 0,
                        0.0f, 0.0f, 0.0f,
                        -1.0f * (this.gridSize / 2.0f), this.gridSize / 2.0f,
                        this.gridCellSize, this.gridLineWidth, System.Drawing.Color.DarkGray);
            }

            if (this.isYZGridVisible)
            {
                GLDrawHelper.DrawGrid2D(gl, 1,
                        0.0f, 0.0f, 0.0f,
                        -1.0f * (this.gridSize / 2.0f), this.gridSize / 2.0f,
                        this.gridCellSize, this.gridLineWidth, System.Drawing.Color.DarkGray);
            }

            if (this.isXZGridVisible)
            {
                GLDrawHelper.DrawGrid2D(gl, 2,
                        0.0f, 0.0f, 0.0f,
                        -1.0f * (this.gridSize / 2.0f), this.gridSize / 2.0f,
                        this.gridCellSize, this.gridLineWidth, System.Drawing.Color.DarkGray);
            }

            if (this.isCreatingCube)
            {
                GLDrawHelper.DrawCube3D(gl, this.cubeX, this.cubeY, 0.0f,
                        this.cubeSize, 3.0f, System.Drawing.Color.OrangeRed);
            }

            if (this.isCubeCreated)
            {
                GLDrawHelper.DrawFilledCube3D(gl, this.cubeX, this.cubeY, 0.0f,
                        this.cubeSize, System.Drawing.Color.LightSkyBlue);
            }

            if (this.isPyramidVisible)
            {
                GLDrawHelper.DrawPyramid(gl, 10f, 10f, 2f,
                        System.Drawing.Color.LightSkyBlue, System.Drawing.Color.Chocolate);
            }

            if (this.isCylinderVisible)
            {
                GLDrawHelper.DrawCylinder(gl, 10f, 10f, 16, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.Chocolate);
            }

            gl.LoadIdentity();
        }

        private void OpenGLControl1_MouseDown(object sender, MouseEventArgs e)
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

        private void OpenGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isRotatingMode = false;
            this.isMovingMode = false;
            this.isZoomingMode = false;
        }

        private void OpenGLControl1_MouseMove(object sender, MouseEventArgs e)
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

        private void Button2_Click(object sender, EventArgs e)
        {
            this.isCreatingCube = true;
            this.isCubeCreated = false;
            this.pressedMouseX = 0;
            this.pressedMouseY = 0;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.isStartVisible = !this.isStartVisible;
        }

        private void IisometryToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void MainAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isAxisVisible = !this.isAxisVisible;
        }

        private void GridXYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isXYGridVisible = !this.isXYGridVisible;
        }

        private void GridYZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isYZGridVisible = !this.isYZGridVisible;
        }

        private void GridXZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isXZGridVisible = !this.isXZGridVisible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenGL gl = this.openGLControl.OpenGL;
            int[] ttt = new int[1];
            gl.GetInteger(SharpGL.OpenGL.GL_MAX_ELEMENTS_VERTICES, ttt);// Enable()

            MessageBox.Show($"{ttt[0]}");
        }

        private void пирамидаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isPyramidVisible = !this.isPyramidVisible;
        }

        private void цилиндрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isCylinderVisible = !this.isCylinderVisible;
        }
    }
}
