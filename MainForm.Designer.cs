
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
			this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изометрияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.главныеОсиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.главныеСеткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.плоскостьXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.плоскостьYZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.плоскостьXZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.контурыОбъектовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.воВсехПлоскостяхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Плоскость = new System.Windows.Forms.Button();
			this.Куб = new System.Windows.Forms.Button();
			this.Параллелипипед = new System.Windows.Forms.Button();
			this.Пирамида = new System.Windows.Forms.Button();
			this.Цилиндр = new System.Windows.Forms.Button();
			this.Конус = new System.Windows.Forms.Button();
			this.Сфера = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.выходИзПриложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.GridXY = new System.Windows.Forms.Button();
			this.GridYZ = new System.Windows.Forms.Button();
			this.GridXZ = new System.Windows.Forms.Button();
			this.GridAll = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.MainAxis = new System.Windows.Forms.Button();
			this.Line = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// openGLControl
			// 
			this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.openGLControl.DrawFPS = false;
			this.openGLControl.FrameRate = 60;
			this.openGLControl.Location = new System.Drawing.Point(10, 91);
			this.openGLControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.openGLControl.Name = "openGLControl";
			this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
			this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
			this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
			this.openGLControl.Size = new System.Drawing.Size(926, 510);
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
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(946, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.выходИзПриложенияToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.открытьToolStripMenuItem.Text = "Открыть";
			this.открытьToolStripMenuItem.Click += new System.EventHandler(this.STLOpenToolStripMenuItem_Click);
			// 
			// правкаToolStripMenuItem
			// 
			this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
			this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.правкаToolStripMenuItem.Text = "Правка";
			// 
			// видToolStripMenuItem
			// 
			this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изометрияToolStripMenuItem,
            this.главныеОсиToolStripMenuItem,
            this.главныеСеткиToolStripMenuItem,
            this.контурыОбъектовToolStripMenuItem});
			this.видToolStripMenuItem.Name = "видToolStripMenuItem";
			this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.видToolStripMenuItem.Text = "Вид";
			// 
			// изометрияToolStripMenuItem
			// 
			this.изометрияToolStripMenuItem.Name = "изометрияToolStripMenuItem";
			this.изометрияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.изометрияToolStripMenuItem.Text = "Изометрия";
			this.изометрияToolStripMenuItem.Click += new System.EventHandler(this.IisometryToolStripMenuItem_Click);
			// 
			// главныеОсиToolStripMenuItem
			// 
			this.главныеОсиToolStripMenuItem.Name = "главныеОсиToolStripMenuItem";
			this.главныеОсиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
			this.главныеСеткиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.главныеСеткиToolStripMenuItem.Text = "Главные сетки";
			// 
			// плоскостьXYToolStripMenuItem
			// 
			this.плоскостьXYToolStripMenuItem.Name = "плоскостьXYToolStripMenuItem";
			this.плоскостьXYToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.плоскостьXYToolStripMenuItem.Text = "Плоскость XY";
			this.плоскостьXYToolStripMenuItem.Click += new System.EventHandler(this.GridXYToolStripMenuItem_Click);
			// 
			// плоскостьYZToolStripMenuItem
			// 
			this.плоскостьYZToolStripMenuItem.Name = "плоскостьYZToolStripMenuItem";
			this.плоскостьYZToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.плоскостьYZToolStripMenuItem.Text = "Плоскость YZ";
			this.плоскостьYZToolStripMenuItem.Click += new System.EventHandler(this.GridYZToolStripMenuItem_Click);
			// 
			// плоскостьXZToolStripMenuItem
			// 
			this.плоскостьXZToolStripMenuItem.Name = "плоскостьXZToolStripMenuItem";
			this.плоскостьXZToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.плоскостьXZToolStripMenuItem.Text = "Плоскость XZ";
			this.плоскостьXZToolStripMenuItem.Click += new System.EventHandler(this.GridXZToolStripMenuItem_Click);
			// 
			// контурыОбъектовToolStripMenuItem
			// 
			this.контурыОбъектовToolStripMenuItem.Name = "контурыОбъектовToolStripMenuItem";
			this.контурыОбъектовToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.контурыОбъектовToolStripMenuItem.Text = "Контуры объектов";
			this.контурыОбъектовToolStripMenuItem.Click += new System.EventHandler(this.ObjectsContoursToolStripMenuItem_Click);
			// 
			// создатьToolStripMenuItem
			// 
			this.создатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.примитивыToolStripMenuItem});
			this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
			this.создатьToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
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
			this.примитивыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.примитивыToolStripMenuItem.Text = "Примитивы";
			// 
			// плоскостьToolStripMenuItem
			// 
			this.плоскостьToolStripMenuItem.Name = "плоскостьToolStripMenuItem";
			this.плоскостьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.плоскостьToolStripMenuItem.Text = "Плоскость";
			this.плоскостьToolStripMenuItem.Click += new System.EventHandler(this.PlaneToolStripMenuItem_Click);
			// 
			// кубToolStripMenuItem
			// 
			this.кубToolStripMenuItem.Name = "кубToolStripMenuItem";
			this.кубToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.кубToolStripMenuItem.Text = "Куб";
			this.кубToolStripMenuItem.Click += new System.EventHandler(this.CubeToolStripMenuItem_Click);
			// 
			// паралелепипедToolStripMenuItem
			// 
			this.паралелепипедToolStripMenuItem.Name = "паралелепипедToolStripMenuItem";
			this.паралелепипедToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.паралелепипедToolStripMenuItem.Text = "Параллелепипед";
			this.паралелепипедToolStripMenuItem.Click += new System.EventHandler(this.ParallelepipedToolStripMenuItem_Click);
			// 
			// пирамидаToolStripMenuItem
			// 
			this.пирамидаToolStripMenuItem.Name = "пирамидаToolStripMenuItem";
			this.пирамидаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.пирамидаToolStripMenuItem.Text = "Пирамида";
			this.пирамидаToolStripMenuItem.Click += new System.EventHandler(this.PyramidToolStripMenuItem_Click);
			// 
			// цилиндрToolStripMenuItem
			// 
			this.цилиндрToolStripMenuItem.Name = "цилиндрToolStripMenuItem";
			this.цилиндрToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.цилиндрToolStripMenuItem.Text = "Цилиндр";
			this.цилиндрToolStripMenuItem.Click += new System.EventHandler(this.CylinderToolStripMenuItem_Click);
			// 
			// конусToolStripMenuItem
			// 
			this.конусToolStripMenuItem.Name = "конусToolStripMenuItem";
			this.конусToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.конусToolStripMenuItem.Text = "Конус";
			this.конусToolStripMenuItem.Click += new System.EventHandler(this.ConeToolStripMenuItem_Click);
			// 
			// сфераToolStripMenuItem
			// 
			this.сфераToolStripMenuItem.Name = "сфераToolStripMenuItem";
			this.сфераToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.сфераToolStripMenuItem.Text = "Сфера";
			this.сфераToolStripMenuItem.Click += new System.EventHandler(this.SphereToolStripMenuItem_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(3, 6);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(109, 24);
			this.button4.TabIndex = 6;
			this.button4.Text = "Начало координат";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(117, 6);
			this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(56, 24);
			this.button1.TabIndex = 7;
			this.button1.Text = "Куб";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(177, 6);
			this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(65, 24);
			this.button2.TabIndex = 8;
			this.button2.Text = "Выстрел";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Fire_Click);
			// 
			// воВсехПлоскостяхToolStripMenuItem
			// 
			this.воВсехПлоскостяхToolStripMenuItem.Name = "воВсехПлоскостяхToolStripMenuItem";
			this.воВсехПлоскостяхToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.воВсехПлоскостяхToolStripMenuItem.Text = "Во всех плоскостях";
			this.воВсехПлоскостяхToolStripMenuItem.Click += new System.EventHandler(this.AllGridToolStripMenuItem_Click);
			// 
			// Плоскость
			// 
			this.Плоскость.Location = new System.Drawing.Point(6, 6);
			this.Плоскость.Name = "Плоскость";
			this.Плоскость.Size = new System.Drawing.Size(75, 24);
			this.Плоскость.TabIndex = 9;
			this.Плоскость.Text = "Плоскость";
			this.Плоскость.UseVisualStyleBackColor = true;
			this.Плоскость.Click += new System.EventHandler(this.Plane_Click);
			// 
			// Куб
			// 
			this.Куб.Location = new System.Drawing.Point(87, 6);
			this.Куб.Name = "Куб";
			this.Куб.Size = new System.Drawing.Size(75, 24);
			this.Куб.TabIndex = 10;
			this.Куб.Text = "Куб";
			this.Куб.UseVisualStyleBackColor = true;
			this.Куб.Click += new System.EventHandler(this.Cube_Click);
			// 
			// Параллелипипед
			// 
			this.Параллелипипед.Location = new System.Drawing.Point(168, 6);
			this.Параллелипипед.Name = "Параллелипипед";
			this.Параллелипипед.Size = new System.Drawing.Size(101, 24);
			this.Параллелипипед.TabIndex = 11;
			this.Параллелипипед.Text = "Параллелипипед";
			this.Параллелипипед.UseVisualStyleBackColor = true;
			this.Параллелипипед.Click += new System.EventHandler(this.Parallelipiped_Click);
			// 
			// Пирамида
			// 
			this.Пирамида.Location = new System.Drawing.Point(275, 6);
			this.Пирамида.Name = "Пирамида";
			this.Пирамида.Size = new System.Drawing.Size(75, 24);
			this.Пирамида.TabIndex = 12;
			this.Пирамида.Text = "Пирамида";
			this.Пирамида.UseVisualStyleBackColor = true;
			this.Пирамида.Click += new System.EventHandler(this.Pyramid_Click);
			// 
			// Цилиндр
			// 
			this.Цилиндр.Location = new System.Drawing.Point(356, 6);
			this.Цилиндр.Name = "Цилиндр";
			this.Цилиндр.Size = new System.Drawing.Size(75, 24);
			this.Цилиндр.TabIndex = 13;
			this.Цилиндр.Text = "Цилиндр";
			this.Цилиндр.UseVisualStyleBackColor = true;
			this.Цилиндр.Click += new System.EventHandler(this.Cylinder_Click);
			// 
			// Конус
			// 
			this.Конус.Location = new System.Drawing.Point(437, 6);
			this.Конус.Name = "Конус";
			this.Конус.Size = new System.Drawing.Size(75, 24);
			this.Конус.TabIndex = 14;
			this.Конус.Text = "Конус";
			this.Конус.UseVisualStyleBackColor = true;
			this.Конус.Click += new System.EventHandler(this.Cone_Click);
			// 
			// Сфера
			// 
			this.Сфера.Location = new System.Drawing.Point(518, 6);
			this.Сфера.Name = "Сфера";
			this.Сфера.Size = new System.Drawing.Size(75, 24);
			this.Сфера.TabIndex = 15;
			this.Сфера.Text = "Сфера";
			this.Сфера.UseVisualStyleBackColor = true;
			this.Сфера.Click += new System.EventHandler(this.Sphere_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(12, 27);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(607, 61);
			this.tabControl1.TabIndex = 16;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.Line);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(599, 35);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Альфа-билд";
			this.tabPage1.UseVisualStyleBackColor = true;
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
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(599, 35);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Создание";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// выходИзПриложенияToolStripMenuItem
			// 
			this.выходИзПриложенияToolStripMenuItem.Name = "выходИзПриложенияToolStripMenuItem";
			this.выходИзПриложенияToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.выходИзПриложенияToolStripMenuItem.Text = "Выход из приложения";
			this.выходИзПриложенияToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.GridAll);
			this.tabPage3.Controls.Add(this.GridXZ);
			this.tabPage3.Controls.Add(this.GridYZ);
			this.tabPage3.Controls.Add(this.GridXY);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(599, 35);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Сетки";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// GridXY
			// 
			this.GridXY.Location = new System.Drawing.Point(7, 6);
			this.GridXY.Name = "GridXY";
			this.GridXY.Size = new System.Drawing.Size(89, 23);
			this.GridXY.TabIndex = 0;
			this.GridXY.Text = "Плоскость XY";
			this.GridXY.UseVisualStyleBackColor = true;
			this.GridXY.Click += new System.EventHandler(this.GridXY_Click);
			// 
			// GridYZ
			// 
			this.GridYZ.Location = new System.Drawing.Point(102, 6);
			this.GridYZ.Name = "GridYZ";
			this.GridYZ.Size = new System.Drawing.Size(91, 23);
			this.GridYZ.TabIndex = 1;
			this.GridYZ.Text = "Плоскость YZ";
			this.GridYZ.UseVisualStyleBackColor = true;
			this.GridYZ.Click += new System.EventHandler(this.GridYZ_Click);
			// 
			// GridXZ
			// 
			this.GridXZ.Location = new System.Drawing.Point(199, 6);
			this.GridXZ.Name = "GridXZ";
			this.GridXZ.Size = new System.Drawing.Size(90, 23);
			this.GridXZ.TabIndex = 2;
			this.GridXZ.Text = "Плоскость XZ";
			this.GridXZ.UseVisualStyleBackColor = true;
			this.GridXZ.Click += new System.EventHandler(this.GridXZ_Click);
			// 
			// GridAll
			// 
			this.GridAll.Location = new System.Drawing.Point(295, 6);
			this.GridAll.Name = "GridAll";
			this.GridAll.Size = new System.Drawing.Size(120, 23);
			this.GridAll.TabIndex = 3;
			this.GridAll.Text = "Во всех плоскостях";
			this.GridAll.UseVisualStyleBackColor = true;
			this.GridAll.Click += new System.EventHandler(this.GridAll_Click);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.MainAxis);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(599, 35);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Оси";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// MainAxis
			// 
			this.MainAxis.Location = new System.Drawing.Point(6, 6);
			this.MainAxis.Name = "MainAxis";
			this.MainAxis.Size = new System.Drawing.Size(92, 23);
			this.MainAxis.TabIndex = 0;
			this.MainAxis.Text = "Главные оси";
			this.MainAxis.UseVisualStyleBackColor = true;
			this.MainAxis.Click += new System.EventHandler(this.MainAxis_Click);
			// 
			// Line
			// 
			this.Line.Location = new System.Drawing.Point(247, 6);
			this.Line.Name = "Line";
			this.Line.Size = new System.Drawing.Size(75, 23);
			this.Line.TabIndex = 9;
			this.Line.Text = "Линия";
			this.Line.UseVisualStyleBackColor = true;
			this.Line.Click += new System.EventHandler(this.Line_Click_1);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(946, 570);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.openGLControl);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
	}
}

