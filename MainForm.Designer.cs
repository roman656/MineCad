
namespace MineCad
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openGLControl = new SharpGL.OpenGLControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзПриложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изометрияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.главныеОсиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.главныеСеткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плоскостьXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плоскостьYZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плоскостьXZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.воВсехПлоскостяхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контурыОбъектовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.примитивыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плоскостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кубToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.паралелепипедToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пирамидаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цилиндрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сфераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Плоскость = new System.Windows.Forms.Button();
            this.Куб = new System.Windows.Forms.Button();
            this.Параллелипипед = new System.Windows.Forms.Button();
            this.Пирамида = new System.Windows.Forms.Button();
            this.Цилиндр = new System.Windows.Forms.Button();
            this.Конус = new System.Windows.Forms.Button();
            this.Сфера = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.GridAll = new System.Windows.Forms.Button();
            this.GridXZ = new System.Windows.Forms.Button();
            this.GridYZ = new System.Windows.Forms.Button();
            this.GridXY = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.MainAxis = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl.DrawFPS = false;
            this.openGLControl.FrameRate = 60;
            this.openGLControl.Location = new System.Drawing.Point(14, 117);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(5);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(1233, 571);
            this.openGLControl.TabIndex = 1;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.OpenGLControl1_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.OpenGLControl1_OpenGLDraw);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenGLControl1_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenGLControl1_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenGLControl1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.видToolStripMenuItem,
            this.создатьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1261, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.выходИзПриложенияToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.STLOpenToolStripMenuItem_Click);
            // 
            // выходИзПриложенияToolStripMenuItem
            // 
            this.выходИзПриложенияToolStripMenuItem.Name = "выходИзПриложенияToolStripMenuItem";
            this.выходИзПриложенияToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.выходИзПриложенияToolStripMenuItem.Text = "Выход из приложения";
            this.выходИзПриложенияToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изометрияToolStripMenuItem,
            this.главныеОсиToolStripMenuItem,
            this.главныеСеткиToolStripMenuItem,
            this.контурыОбъектовToolStripMenuItem,
            this.fPSToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // изометрияToolStripMenuItem
            // 
            this.изометрияToolStripMenuItem.Name = "изометрияToolStripMenuItem";
            this.изометрияToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.изометрияToolStripMenuItem.Text = "Изометрия";
            this.изометрияToolStripMenuItem.Click += new System.EventHandler(this.IisometryToolStripMenuItem_Click);
            // 
            // главныеОсиToolStripMenuItem
            // 
            this.главныеОсиToolStripMenuItem.Name = "главныеОсиToolStripMenuItem";
            this.главныеОсиToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.главныеОсиToolStripMenuItem.Text = "Главные оси";
            this.главныеОсиToolStripMenuItem.Click += new System.EventHandler(this.MainAxesToolStripMenuItem_Click);
            // 
            // главныеСеткиToolStripMenuItem
            // 
            this.главныеСеткиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.плоскостьXYToolStripMenuItem,
            this.плоскостьYZToolStripMenuItem,
            this.плоскостьXZToolStripMenuItem,
            this.воВсехПлоскостяхToolStripMenuItem});
            this.главныеСеткиToolStripMenuItem.Name = "главныеСеткиToolStripMenuItem";
            this.главныеСеткиToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.главныеСеткиToolStripMenuItem.Text = "Главные сетки";
            // 
            // плоскостьXYToolStripMenuItem
            // 
            this.плоскостьXYToolStripMenuItem.Name = "плоскостьXYToolStripMenuItem";
            this.плоскостьXYToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.плоскостьXYToolStripMenuItem.Text = "Плоскость XY";
            this.плоскостьXYToolStripMenuItem.Click += new System.EventHandler(this.GridXYToolStripMenuItem_Click);
            // 
            // плоскостьYZToolStripMenuItem
            // 
            this.плоскостьYZToolStripMenuItem.Name = "плоскостьYZToolStripMenuItem";
            this.плоскостьYZToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.плоскостьYZToolStripMenuItem.Text = "Плоскость YZ";
            this.плоскостьYZToolStripMenuItem.Click += new System.EventHandler(this.GridYZToolStripMenuItem_Click);
            // 
            // плоскостьXZToolStripMenuItem
            // 
            this.плоскостьXZToolStripMenuItem.Name = "плоскостьXZToolStripMenuItem";
            this.плоскостьXZToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.плоскостьXZToolStripMenuItem.Text = "Плоскость XZ";
            this.плоскостьXZToolStripMenuItem.Click += new System.EventHandler(this.GridXZToolStripMenuItem_Click);
            // 
            // воВсехПлоскостяхToolStripMenuItem
            // 
            this.воВсехПлоскостяхToolStripMenuItem.Name = "воВсехПлоскостяхToolStripMenuItem";
            this.воВсехПлоскостяхToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.воВсехПлоскостяхToolStripMenuItem.Text = "Во всех плоскостях";
            this.воВсехПлоскостяхToolStripMenuItem.Click += new System.EventHandler(this.AllGridToolStripMenuItem_Click);
            // 
            // контурыОбъектовToolStripMenuItem
            // 
            this.контурыОбъектовToolStripMenuItem.Name = "контурыОбъектовToolStripMenuItem";
            this.контурыОбъектовToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.контурыОбъектовToolStripMenuItem.Text = "Контуры объектов";
            this.контурыОбъектовToolStripMenuItem.Click += new System.EventHandler(this.ObjectsContoursToolStripMenuItem_Click);
            // 
            // fPSToolStripMenuItem
            // 
            this.fPSToolStripMenuItem.Name = "fPSToolStripMenuItem";
            this.fPSToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.fPSToolStripMenuItem.Text = "FPS";
            this.fPSToolStripMenuItem.Click += new System.EventHandler(this.FPSToolStripMenuItem_Click);
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.примитивыToolStripMenuItem});
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.создатьToolStripMenuItem.Text = "Создать";
            // 
            // примитивыToolStripMenuItem
            // 
            this.примитивыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.плоскостьToolStripMenuItem,
            this.кубToolStripMenuItem,
            this.паралелепипедToolStripMenuItem,
            this.пирамидаToolStripMenuItem,
            this.цилиндрToolStripMenuItem,
            this.конусToolStripMenuItem,
            this.сфераToolStripMenuItem});
            this.примитивыToolStripMenuItem.Name = "примитивыToolStripMenuItem";
            this.примитивыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.примитивыToolStripMenuItem.Text = "Примитивы";
            // 
            // плоскостьToolStripMenuItem
            // 
            this.плоскостьToolStripMenuItem.Name = "плоскостьToolStripMenuItem";
            this.плоскостьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.плоскостьToolStripMenuItem.Text = "Плоскость";
            this.плоскостьToolStripMenuItem.Click += new System.EventHandler(this.PlaneToolStripMenuItem_Click);
            // 
            // кубToolStripMenuItem
            // 
            this.кубToolStripMenuItem.Name = "кубToolStripMenuItem";
            this.кубToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.кубToolStripMenuItem.Text = "Куб";
            this.кубToolStripMenuItem.Click += new System.EventHandler(this.CubeToolStripMenuItem_Click);
            // 
            // паралелепипедToolStripMenuItem
            // 
            this.паралелепипедToolStripMenuItem.Name = "паралелепипедToolStripMenuItem";
            this.паралелепипедToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.паралелепипедToolStripMenuItem.Text = "Параллелепипед";
            this.паралелепипедToolStripMenuItem.Click += new System.EventHandler(this.ParallelepipedToolStripMenuItem_Click);
            // 
            // пирамидаToolStripMenuItem
            // 
            this.пирамидаToolStripMenuItem.Name = "пирамидаToolStripMenuItem";
            this.пирамидаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.пирамидаToolStripMenuItem.Text = "Пирамида";
            this.пирамидаToolStripMenuItem.Click += new System.EventHandler(this.PyramidToolStripMenuItem_Click);
            // 
            // цилиндрToolStripMenuItem
            // 
            this.цилиндрToolStripMenuItem.Name = "цилиндрToolStripMenuItem";
            this.цилиндрToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.цилиндрToolStripMenuItem.Text = "Цилиндр";
            this.цилиндрToolStripMenuItem.Click += new System.EventHandler(this.CylinderToolStripMenuItem_Click);
            // 
            // конусToolStripMenuItem
            // 
            this.конусToolStripMenuItem.Name = "конусToolStripMenuItem";
            this.конусToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.конусToolStripMenuItem.Text = "Конус";
            this.конусToolStripMenuItem.Click += new System.EventHandler(this.ConeToolStripMenuItem_Click);
            // 
            // сфераToolStripMenuItem
            // 
            this.сфераToolStripMenuItem.Name = "сфераToolStripMenuItem";
            this.сфераToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сфераToolStripMenuItem.Text = "Сфера";
            this.сфераToolStripMenuItem.Click += new System.EventHandler(this.SphereToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(4, 7);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 30);
            this.button4.TabIndex = 6;
            this.button4.Text = "Начало координат";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Куб";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "Выстрел";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Fire_Click);
            // 
            // Плоскость
            // 
            this.Плоскость.Location = new System.Drawing.Point(8, 7);
            this.Плоскость.Margin = new System.Windows.Forms.Padding(4);
            this.Плоскость.Name = "Плоскость";
            this.Плоскость.Size = new System.Drawing.Size(100, 30);
            this.Плоскость.TabIndex = 9;
            this.Плоскость.Text = "Плоскость";
            this.Плоскость.UseVisualStyleBackColor = true;
            this.Плоскость.Click += new System.EventHandler(this.Plane_Click);
            // 
            // Куб
            // 
            this.Куб.Location = new System.Drawing.Point(116, 7);
            this.Куб.Margin = new System.Windows.Forms.Padding(4);
            this.Куб.Name = "Куб";
            this.Куб.Size = new System.Drawing.Size(100, 30);
            this.Куб.TabIndex = 10;
            this.Куб.Text = "Куб";
            this.Куб.UseVisualStyleBackColor = true;
            this.Куб.Click += new System.EventHandler(this.Cube_Click);
            // 
            // Параллелипипед
            // 
            this.Параллелипипед.Location = new System.Drawing.Point(224, 7);
            this.Параллелипипед.Margin = new System.Windows.Forms.Padding(4);
            this.Параллелипипед.Name = "Параллелипипед";
            this.Параллелипипед.Size = new System.Drawing.Size(135, 30);
            this.Параллелипипед.TabIndex = 11;
            this.Параллелипипед.Text = "Параллелепипед";
            this.Параллелипипед.UseVisualStyleBackColor = true;
            this.Параллелипипед.Click += new System.EventHandler(this.Parallelipiped_Click);
            // 
            // Пирамида
            // 
            this.Пирамида.Location = new System.Drawing.Point(367, 7);
            this.Пирамида.Margin = new System.Windows.Forms.Padding(4);
            this.Пирамида.Name = "Пирамида";
            this.Пирамида.Size = new System.Drawing.Size(100, 30);
            this.Пирамида.TabIndex = 12;
            this.Пирамида.Text = "Пирамида";
            this.Пирамида.UseVisualStyleBackColor = true;
            this.Пирамида.Click += new System.EventHandler(this.Pyramid_Click);
            // 
            // Цилиндр
            // 
            this.Цилиндр.Location = new System.Drawing.Point(475, 7);
            this.Цилиндр.Margin = new System.Windows.Forms.Padding(4);
            this.Цилиндр.Name = "Цилиндр";
            this.Цилиндр.Size = new System.Drawing.Size(100, 30);
            this.Цилиндр.TabIndex = 13;
            this.Цилиндр.Text = "Цилиндр";
            this.Цилиндр.UseVisualStyleBackColor = true;
            this.Цилиндр.Click += new System.EventHandler(this.Cylinder_Click);
            // 
            // Конус
            // 
            this.Конус.Location = new System.Drawing.Point(583, 7);
            this.Конус.Margin = new System.Windows.Forms.Padding(4);
            this.Конус.Name = "Конус";
            this.Конус.Size = new System.Drawing.Size(100, 30);
            this.Конус.TabIndex = 14;
            this.Конус.Text = "Конус";
            this.Конус.UseVisualStyleBackColor = true;
            this.Конус.Click += new System.EventHandler(this.Cone_Click);
            // 
            // Сфера
            // 
            this.Сфера.Location = new System.Drawing.Point(691, 7);
            this.Сфера.Margin = new System.Windows.Forms.Padding(4);
            this.Сфера.Name = "Сфера";
            this.Сфера.Size = new System.Drawing.Size(100, 30);
            this.Сфера.TabIndex = 15;
            this.Сфера.Text = "Сфера";
            this.Сфера.UseVisualStyleBackColor = true;
            this.Сфера.Click += new System.EventHandler(this.Sphere_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(16, 33);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1231, 75);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.Line);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1223, 46);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Альфа-билд";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(438, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 10;
            this.button3.Text = "Танки";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.TanksVisibilityButton_Click);
            // 
            // Line
            // 
            this.Line.Location = new System.Drawing.Point(330, 8);
            this.Line.Margin = new System.Windows.Forms.Padding(4);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(100, 30);
            this.Line.TabIndex = 9;
            this.Line.Text = "Линия";
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Плоскость);
            this.tabPage2.Controls.Add(this.Сфера);
            this.tabPage2.Controls.Add(this.Куб);
            this.tabPage2.Controls.Add(this.Конус);
            this.tabPage2.Controls.Add(this.Параллелипипед);
            this.tabPage2.Controls.Add(this.Цилиндр);
            this.tabPage2.Controls.Add(this.Пирамида);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1223, 46);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Создание";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.GridAll);
            this.tabPage3.Controls.Add(this.GridXZ);
            this.tabPage3.Controls.Add(this.GridYZ);
            this.tabPage3.Controls.Add(this.GridXY);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1223, 46);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Сетки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // GridAll
            // 
            this.GridAll.Location = new System.Drawing.Point(393, 7);
            this.GridAll.Margin = new System.Windows.Forms.Padding(4);
            this.GridAll.Name = "GridAll";
            this.GridAll.Size = new System.Drawing.Size(160, 28);
            this.GridAll.TabIndex = 3;
            this.GridAll.Text = "Во всех плоскостях";
            this.GridAll.UseVisualStyleBackColor = true;
            this.GridAll.Click += new System.EventHandler(this.GridAll_Click);
            // 
            // GridXZ
            // 
            this.GridXZ.Location = new System.Drawing.Point(265, 7);
            this.GridXZ.Margin = new System.Windows.Forms.Padding(4);
            this.GridXZ.Name = "GridXZ";
            this.GridXZ.Size = new System.Drawing.Size(120, 28);
            this.GridXZ.TabIndex = 2;
            this.GridXZ.Text = "Плоскость XZ";
            this.GridXZ.UseVisualStyleBackColor = true;
            this.GridXZ.Click += new System.EventHandler(this.GridXZ_Click);
            // 
            // GridYZ
            // 
            this.GridYZ.Location = new System.Drawing.Point(136, 7);
            this.GridYZ.Margin = new System.Windows.Forms.Padding(4);
            this.GridYZ.Name = "GridYZ";
            this.GridYZ.Size = new System.Drawing.Size(121, 28);
            this.GridYZ.TabIndex = 1;
            this.GridYZ.Text = "Плоскость YZ";
            this.GridYZ.UseVisualStyleBackColor = true;
            this.GridYZ.Click += new System.EventHandler(this.GridYZ_Click);
            // 
            // GridXY
            // 
            this.GridXY.Location = new System.Drawing.Point(9, 7);
            this.GridXY.Margin = new System.Windows.Forms.Padding(4);
            this.GridXY.Name = "GridXY";
            this.GridXY.Size = new System.Drawing.Size(119, 28);
            this.GridXY.TabIndex = 0;
            this.GridXY.Text = "Плоскость XY";
            this.GridXY.UseVisualStyleBackColor = true;
            this.GridXY.Click += new System.EventHandler(this.GridXY_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.MainAxis);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(1223, 46);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Оси";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // MainAxis
            // 
            this.MainAxis.Location = new System.Drawing.Point(8, 7);
            this.MainAxis.Margin = new System.Windows.Forms.Padding(4);
            this.MainAxis.Name = "MainAxis";
            this.MainAxis.Size = new System.Drawing.Size(123, 28);
            this.MainAxis.TabIndex = 0;
            this.MainAxis.Text = "Главные оси";
            this.MainAxis.UseVisualStyleBackColor = true;
            this.MainAxis.Click += new System.EventHandler(this.MainAxis_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(1191, 6);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 22);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(987, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Масштаб для модели из STL";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1261, 702);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(860, 500);
            this.Name = "MainForm";
            this.Text = "MineCad";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem изометрияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem главныеОсиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem главныеСеткиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плоскостьXYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плоскостьYZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плоскостьXZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контурыОбъектовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem примитивыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кубToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem паралелепипедToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цилиндрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сфераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плоскостьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пирамидаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конусToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem воВсехПлоскостяхToolStripMenuItem;
		private System.Windows.Forms.Button Плоскость;
		private System.Windows.Forms.Button Куб;
		private System.Windows.Forms.Button Параллелипипед;
		private System.Windows.Forms.Button Пирамида;
		private System.Windows.Forms.Button Цилиндр;
		private System.Windows.Forms.Button Конус;
		private System.Windows.Forms.Button Сфера;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ToolStripMenuItem выходИзПриложенияToolStripMenuItem;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button GridAll;
		private System.Windows.Forms.Button GridXZ;
		private System.Windows.Forms.Button GridYZ;
		private System.Windows.Forms.Button GridXY;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button MainAxis;
		private System.Windows.Forms.Button Line;
		private System.Windows.Forms.ToolStripMenuItem fPSToolStripMenuItem;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}

