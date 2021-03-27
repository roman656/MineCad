
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
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изометрияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.главныеОсиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.главныеСеткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плоскостьXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плоскостьYZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плоскостьXZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl.DrawFPS = false;
            this.openGLControl.FrameRate = 60;
            this.openGLControl.Location = new System.Drawing.Point(13, 64);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(5);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(1235, 676);
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
            this.видToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1262, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
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
            this.главныеСеткиToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // изометрияToolStripMenuItem
            // 
            this.изометрияToolStripMenuItem.Name = "изометрияToolStripMenuItem";
            this.изометрияToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.изометрияToolStripMenuItem.Text = "Изометрия";
            this.изометрияToolStripMenuItem.Click += new System.EventHandler(this.IisometryToolStripMenuItem_Click);
            // 
            // главныеОсиToolStripMenuItem
            // 
            this.главныеОсиToolStripMenuItem.Name = "главныеОсиToolStripMenuItem";
            this.главныеОсиToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.главныеОсиToolStripMenuItem.Text = "Главные оси";
            this.главныеОсиToolStripMenuItem.Click += new System.EventHandler(this.MainAxisToolStripMenuItem_Click);
            // 
            // главныеСеткиToolStripMenuItem
            // 
            this.главныеСеткиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.плоскостьXYToolStripMenuItem,
            this.плоскостьYZToolStripMenuItem,
            this.плоскостьXZToolStripMenuItem});
            this.главныеСеткиToolStripMenuItem.Name = "главныеСеткиToolStripMenuItem";
            this.главныеСеткиToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.главныеСеткиToolStripMenuItem.Text = "Главные сетки";
            // 
            // плоскостьXYToolStripMenuItem
            // 
            this.плоскостьXYToolStripMenuItem.Name = "плоскостьXYToolStripMenuItem";
            this.плоскостьXYToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.плоскостьXYToolStripMenuItem.Text = "Плоскость XY";
            this.плоскостьXYToolStripMenuItem.Click += new System.EventHandler(this.GridXYToolStripMenuItem_Click);
            // 
            // плоскостьYZToolStripMenuItem
            // 
            this.плоскостьYZToolStripMenuItem.Name = "плоскостьYZToolStripMenuItem";
            this.плоскостьYZToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.плоскостьYZToolStripMenuItem.Text = "Плоскость YZ";
            this.плоскостьYZToolStripMenuItem.Click += new System.EventHandler(this.GridYZToolStripMenuItem_Click);
            // 
            // плоскостьXZToolStripMenuItem
            // 
            this.плоскостьXZToolStripMenuItem.Name = "плоскостьXZToolStripMenuItem";
            this.плоскостьXZToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.плоскостьXZToolStripMenuItem.Text = "Плоскость XZ";
            this.плоскостьXZToolStripMenuItem.Click += new System.EventHandler(this.GridXZToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 30);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Куб";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 30);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 29);
            this.button4.TabIndex = 6;
            this.button4.Text = "Начало координат";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MineCad";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem изометрияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem главныеОсиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem главныеСеткиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плоскостьXYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плоскостьYZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плоскостьXZToolStripMenuItem;
    }
}

