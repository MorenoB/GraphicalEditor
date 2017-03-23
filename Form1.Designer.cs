namespace GraphicalEditor
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.PictureBox_DrawArea = new System.Windows.Forms.PictureBox();
            this.Panel_Colorpicker = new System.Windows.Forms.Panel();
            this.label_SelectedTool = new System.Windows.Forms.Label();
            this.Picturebox_CurrentColor = new System.Windows.Forms.PictureBox();
            this.Trackbar_Colorpicker_Alpha = new System.Windows.Forms.TrackBar();
            this.Trackbar_Colorpicker_Blue = new System.Windows.Forms.TrackBar();
            this.Trackbar_Colorpicker_Green = new System.Windows.Forms.TrackBar();
            this.Trackbar_ColorPicker_Red = new System.Windows.Forms.TrackBar();
            this.Label_Colorpicker_alphaval = new System.Windows.Forms.Label();
            this.Label_Colorpicker_blueval = new System.Windows.Forms.Label();
            this.Label_Colorpicker_greenval = new System.Windows.Forms.Label();
            this.Label_Colorpicker_redval = new System.Windows.Forms.Label();
            this.Label_Colorpicker_A = new System.Windows.Forms.Label();
            this.Label_Colorpicker_B = new System.Windows.Forms.Label();
            this.Label_Colorpicker_G = new System.Windows.Forms.Label();
            this.Label_ColorPicker_R = new System.Windows.Forms.Label();
            this.PictureBox_ColorPicker = new System.Windows.Forms.PictureBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.Button_Rectangle = new System.Windows.Forms.ToolStripButton();
            this.Button_Ellipse = new System.Windows.Forms.ToolStripButton();
            this.Button_ColorPicker = new System.Windows.Forms.ToolStripButton();
            this.Button_Line = new System.Windows.Forms.ToolStripButton();
            this.Button_Brush = new System.Windows.Forms.ToolStripButton();
            this.Button_Pencil = new System.Windows.Forms.ToolStripButton();
            this.Button_Eraser = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Button_New = new System.Windows.Forms.ToolStripButton();
            this.Button_Load = new System.Windows.Forms.ToolStripButton();
            this.Button_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.Label_BrushSize = new System.Windows.Forms.ToolStripLabel();
            this.Textbox_BrushSize = new System.Windows.Forms.ToolStripTextBox();
            this.Button_Apply_BrushSize = new System.Windows.Forms.ToolStripButton();
            this.Button_Undo = new System.Windows.Forms.ToolStripButton();
            this.Button_Redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_DrawArea)).BeginInit();
            this.Panel_Colorpicker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picturebox_CurrentColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trackbar_Colorpicker_Alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trackbar_Colorpicker_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trackbar_Colorpicker_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trackbar_ColorPicker_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_ColorPicker)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.PictureBox_DrawArea);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Panel_Colorpicker);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1396, 707);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip4);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1421, 734);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // PictureBox_DrawArea
            // 
            this.PictureBox_DrawArea.BackColor = System.Drawing.Color.White;
            this.PictureBox_DrawArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox_DrawArea.Location = new System.Drawing.Point(0, 0);
            this.PictureBox_DrawArea.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox_DrawArea.Name = "PictureBox_DrawArea";
            this.PictureBox_DrawArea.Size = new System.Drawing.Size(1019, 707);
            this.PictureBox_DrawArea.TabIndex = 1;
            this.PictureBox_DrawArea.TabStop = false;
            this.PictureBox_DrawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_DrawArea_Paint);
            this.PictureBox_DrawArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_DrawArea_MouseClick);
            this.PictureBox_DrawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picturebox_DrawArea_MouseDown);
            this.PictureBox_DrawArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_DrawArea_MouseMove);
            this.PictureBox_DrawArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_DrawArea_MouseUp);
            // 
            // Panel_Colorpicker
            // 
            this.Panel_Colorpicker.Controls.Add(this.label_SelectedTool);
            this.Panel_Colorpicker.Controls.Add(this.Picturebox_CurrentColor);
            this.Panel_Colorpicker.Controls.Add(this.Trackbar_Colorpicker_Alpha);
            this.Panel_Colorpicker.Controls.Add(this.Trackbar_Colorpicker_Blue);
            this.Panel_Colorpicker.Controls.Add(this.Trackbar_Colorpicker_Green);
            this.Panel_Colorpicker.Controls.Add(this.Trackbar_ColorPicker_Red);
            this.Panel_Colorpicker.Controls.Add(this.Label_Colorpicker_alphaval);
            this.Panel_Colorpicker.Controls.Add(this.Label_Colorpicker_blueval);
            this.Panel_Colorpicker.Controls.Add(this.Label_Colorpicker_greenval);
            this.Panel_Colorpicker.Controls.Add(this.Label_Colorpicker_redval);
            this.Panel_Colorpicker.Controls.Add(this.Label_Colorpicker_A);
            this.Panel_Colorpicker.Controls.Add(this.Label_Colorpicker_B);
            this.Panel_Colorpicker.Controls.Add(this.Label_Colorpicker_G);
            this.Panel_Colorpicker.Controls.Add(this.Label_ColorPicker_R);
            this.Panel_Colorpicker.Controls.Add(this.PictureBox_ColorPicker);
            this.Panel_Colorpicker.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_Colorpicker.Location = new System.Drawing.Point(1019, 0);
            this.Panel_Colorpicker.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Colorpicker.Name = "Panel_Colorpicker";
            this.Panel_Colorpicker.Size = new System.Drawing.Size(377, 707);
            this.Panel_Colorpicker.TabIndex = 0;
            // 
            // label_SelectedTool
            // 
            this.label_SelectedTool.AutoSize = true;
            this.label_SelectedTool.Location = new System.Drawing.Point(25, 535);
            this.label_SelectedTool.Name = "label_SelectedTool";
            this.label_SelectedTool.Size = new System.Drawing.Size(184, 17);
            this.label_SelectedTool.TabIndex = 14;
            this.label_SelectedTool.Text = "Selected tool will show here!";
            // 
            // Picturebox_CurrentColor
            // 
            this.Picturebox_CurrentColor.Location = new System.Drawing.Point(25, 63);
            this.Picturebox_CurrentColor.Margin = new System.Windows.Forms.Padding(4);
            this.Picturebox_CurrentColor.Name = "Picturebox_CurrentColor";
            this.Picturebox_CurrentColor.Size = new System.Drawing.Size(155, 160);
            this.Picturebox_CurrentColor.TabIndex = 13;
            this.Picturebox_CurrentColor.TabStop = false;
            // 
            // Trackbar_Colorpicker_Alpha
            // 
            this.Trackbar_Colorpicker_Alpha.Location = new System.Drawing.Point(53, 345);
            this.Trackbar_Colorpicker_Alpha.Margin = new System.Windows.Forms.Padding(4);
            this.Trackbar_Colorpicker_Alpha.Maximum = 255;
            this.Trackbar_Colorpicker_Alpha.Name = "Trackbar_Colorpicker_Alpha";
            this.Trackbar_Colorpicker_Alpha.Size = new System.Drawing.Size(308, 56);
            this.Trackbar_Colorpicker_Alpha.TabIndex = 12;
            this.Trackbar_Colorpicker_Alpha.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Trackbar_Colorpicker_Alpha.Scroll += new System.EventHandler(this.Trackbar_ColorPicker_Alpha_Scroll);
            // 
            // Trackbar_Colorpicker_Blue
            // 
            this.Trackbar_Colorpicker_Blue.Location = new System.Drawing.Point(53, 314);
            this.Trackbar_Colorpicker_Blue.Margin = new System.Windows.Forms.Padding(4);
            this.Trackbar_Colorpicker_Blue.Maximum = 255;
            this.Trackbar_Colorpicker_Blue.Name = "Trackbar_Colorpicker_Blue";
            this.Trackbar_Colorpicker_Blue.Size = new System.Drawing.Size(308, 56);
            this.Trackbar_Colorpicker_Blue.TabIndex = 11;
            this.Trackbar_Colorpicker_Blue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Trackbar_Colorpicker_Blue.Scroll += new System.EventHandler(this.Trackbar_ColorPicker_Blue_Scroll);
            // 
            // Trackbar_Colorpicker_Green
            // 
            this.Trackbar_Colorpicker_Green.Location = new System.Drawing.Point(53, 286);
            this.Trackbar_Colorpicker_Green.Margin = new System.Windows.Forms.Padding(4);
            this.Trackbar_Colorpicker_Green.Maximum = 255;
            this.Trackbar_Colorpicker_Green.Name = "Trackbar_Colorpicker_Green";
            this.Trackbar_Colorpicker_Green.Size = new System.Drawing.Size(308, 56);
            this.Trackbar_Colorpicker_Green.TabIndex = 10;
            this.Trackbar_Colorpicker_Green.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Trackbar_Colorpicker_Green.Scroll += new System.EventHandler(this.Trackbar_ColorPicker_Green_Scroll);
            // 
            // Trackbar_ColorPicker_Red
            // 
            this.Trackbar_ColorPicker_Red.Location = new System.Drawing.Point(53, 256);
            this.Trackbar_ColorPicker_Red.Margin = new System.Windows.Forms.Padding(4);
            this.Trackbar_ColorPicker_Red.Maximum = 255;
            this.Trackbar_ColorPicker_Red.Name = "Trackbar_ColorPicker_Red";
            this.Trackbar_ColorPicker_Red.Size = new System.Drawing.Size(308, 56);
            this.Trackbar_ColorPicker_Red.TabIndex = 9;
            this.Trackbar_ColorPicker_Red.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Trackbar_ColorPicker_Red.Scroll += new System.EventHandler(this.Trackbar_ColorPicker_Red_Scroll);
            // 
            // Label_Colorpicker_alphaval
            // 
            this.Label_Colorpicker_alphaval.AutoSize = true;
            this.Label_Colorpicker_alphaval.Location = new System.Drawing.Point(21, 479);
            this.Label_Colorpicker_alphaval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Colorpicker_alphaval.Name = "Label_Colorpicker_alphaval";
            this.Label_Colorpicker_alphaval.Size = new System.Drawing.Size(21, 17);
            this.Label_Colorpicker_alphaval.TabIndex = 8;
            this.Label_Colorpicker_alphaval.Text = "A:";
            // 
            // Label_Colorpicker_blueval
            // 
            this.Label_Colorpicker_blueval.AutoSize = true;
            this.Label_Colorpicker_blueval.Location = new System.Drawing.Point(21, 452);
            this.Label_Colorpicker_blueval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Colorpicker_blueval.Name = "Label_Colorpicker_blueval";
            this.Label_Colorpicker_blueval.Size = new System.Drawing.Size(21, 17);
            this.Label_Colorpicker_blueval.TabIndex = 7;
            this.Label_Colorpicker_blueval.Text = "B:";
            // 
            // Label_Colorpicker_greenval
            // 
            this.Label_Colorpicker_greenval.AutoSize = true;
            this.Label_Colorpicker_greenval.Location = new System.Drawing.Point(21, 425);
            this.Label_Colorpicker_greenval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Colorpicker_greenval.Name = "Label_Colorpicker_greenval";
            this.Label_Colorpicker_greenval.Size = new System.Drawing.Size(23, 17);
            this.Label_Colorpicker_greenval.TabIndex = 6;
            this.Label_Colorpicker_greenval.Text = "G:";
            // 
            // Label_Colorpicker_redval
            // 
            this.Label_Colorpicker_redval.AutoSize = true;
            this.Label_Colorpicker_redval.Location = new System.Drawing.Point(21, 398);
            this.Label_Colorpicker_redval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Colorpicker_redval.Name = "Label_Colorpicker_redval";
            this.Label_Colorpicker_redval.Size = new System.Drawing.Size(22, 17);
            this.Label_Colorpicker_redval.TabIndex = 5;
            this.Label_Colorpicker_redval.Text = "R:";
            // 
            // Label_Colorpicker_A
            // 
            this.Label_Colorpicker_A.AutoSize = true;
            this.Label_Colorpicker_A.Location = new System.Drawing.Point(21, 348);
            this.Label_Colorpicker_A.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Colorpicker_A.Name = "Label_Colorpicker_A";
            this.Label_Colorpicker_A.Size = new System.Drawing.Size(21, 17);
            this.Label_Colorpicker_A.TabIndex = 4;
            this.Label_Colorpicker_A.Text = "A:";
            // 
            // Label_Colorpicker_B
            // 
            this.Label_Colorpicker_B.AutoSize = true;
            this.Label_Colorpicker_B.Location = new System.Drawing.Point(21, 319);
            this.Label_Colorpicker_B.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Colorpicker_B.Name = "Label_Colorpicker_B";
            this.Label_Colorpicker_B.Size = new System.Drawing.Size(21, 17);
            this.Label_Colorpicker_B.TabIndex = 3;
            this.Label_Colorpicker_B.Text = "B:";
            // 
            // Label_Colorpicker_G
            // 
            this.Label_Colorpicker_G.AutoSize = true;
            this.Label_Colorpicker_G.Location = new System.Drawing.Point(21, 290);
            this.Label_Colorpicker_G.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Colorpicker_G.Name = "Label_Colorpicker_G";
            this.Label_Colorpicker_G.Size = new System.Drawing.Size(23, 17);
            this.Label_Colorpicker_G.TabIndex = 2;
            this.Label_Colorpicker_G.Text = "G:";
            // 
            // Label_ColorPicker_R
            // 
            this.Label_ColorPicker_R.AutoSize = true;
            this.Label_ColorPicker_R.Location = new System.Drawing.Point(21, 262);
            this.Label_ColorPicker_R.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_ColorPicker_R.Name = "Label_ColorPicker_R";
            this.Label_ColorPicker_R.Size = new System.Drawing.Size(22, 17);
            this.Label_ColorPicker_R.TabIndex = 1;
            this.Label_ColorPicker_R.Text = "R:";
            // 
            // PictureBox_ColorPicker
            // 
            this.PictureBox_ColorPicker.Image = global::GraphicalEditor.Properties.Resources.wheel;
            this.PictureBox_ColorPicker.Location = new System.Drawing.Point(188, 62);
            this.PictureBox_ColorPicker.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox_ColorPicker.Name = "PictureBox_ColorPicker";
            this.PictureBox_ColorPicker.Size = new System.Drawing.Size(173, 161);
            this.PictureBox_ColorPicker.TabIndex = 0;
            this.PictureBox_ColorPicker.TabStop = false;
            this.PictureBox_ColorPicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_ColorPicker_MouseDown);
            this.PictureBox_ColorPicker.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_ColorPicker_MouseMove);
            this.PictureBox_ColorPicker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_ColorPicker_MouseUp);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button_Rectangle,
            this.Button_Ellipse,
            this.Button_ColorPicker,
            this.Button_Line,
            this.Button_Brush,
            this.Button_Pencil,
            this.Button_Eraser});
            this.toolStrip4.Location = new System.Drawing.Point(0, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(25, 200);
            this.toolStrip4.TabIndex = 0;
            // 
            // Button_Rectangle
            // 
            this.Button_Rectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Rectangle.Image = global::GraphicalEditor.Properties.Resources.drawrect;
            this.Button_Rectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Rectangle.Name = "Button_Rectangle";
            this.Button_Rectangle.Size = new System.Drawing.Size(23, 24);
            this.Button_Rectangle.Text = "Draw rectangle";
            this.Button_Rectangle.Click += new System.EventHandler(this.Button_Rectangle_Click);
            // 
            // Button_Ellipse
            // 
            this.Button_Ellipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Ellipse.Image = global::GraphicalEditor.Properties.Resources.drawellip;
            this.Button_Ellipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Ellipse.Name = "Button_Ellipse";
            this.Button_Ellipse.Size = new System.Drawing.Size(23, 24);
            this.Button_Ellipse.Text = "Draw ellipse";
            this.Button_Ellipse.Click += new System.EventHandler(this.Button_Ellipse_Click);
            // 
            // Button_ColorPicker
            // 
            this.Button_ColorPicker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_ColorPicker.Enabled = false;
            this.Button_ColorPicker.Image = global::GraphicalEditor.Properties.Resources.colorp;
            this.Button_ColorPicker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_ColorPicker.Name = "Button_ColorPicker";
            this.Button_ColorPicker.Size = new System.Drawing.Size(23, 24);
            this.Button_ColorPicker.Text = "Color picker";
            this.Button_ColorPicker.Click += new System.EventHandler(this.Button_ColorPicker_Click);
            // 
            // Button_Line
            // 
            this.Button_Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Line.Enabled = false;
            this.Button_Line.Image = global::GraphicalEditor.Properties.Resources.line;
            this.Button_Line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Line.Name = "Button_Line";
            this.Button_Line.Size = new System.Drawing.Size(23, 24);
            this.Button_Line.Text = "Draw line";
            this.Button_Line.Click += new System.EventHandler(this.Button_line_Click);
            // 
            // Button_Brush
            // 
            this.Button_Brush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Brush.Enabled = false;
            this.Button_Brush.Image = global::GraphicalEditor.Properties.Resources.brush;
            this.Button_Brush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Brush.Name = "Button_Brush";
            this.Button_Brush.Size = new System.Drawing.Size(23, 24);
            this.Button_Brush.Text = "Brush";
            this.Button_Brush.Click += new System.EventHandler(this.Button_Brush_Click);
            // 
            // Button_Pencil
            // 
            this.Button_Pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Pencil.Enabled = false;
            this.Button_Pencil.Image = global::GraphicalEditor.Properties.Resources.pencil;
            this.Button_Pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Pencil.Name = "Button_Pencil";
            this.Button_Pencil.Size = new System.Drawing.Size(23, 24);
            this.Button_Pencil.Text = "Pencil";
            this.Button_Pencil.Click += new System.EventHandler(this.Button_Pencil_Click);
            // 
            // Button_Eraser
            // 
            this.Button_Eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Eraser.Enabled = false;
            this.Button_Eraser.Image = global::GraphicalEditor.Properties.Resources.pencil;
            this.Button_Eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Eraser.Name = "Button_Eraser";
            this.Button_Eraser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Button_Eraser.RightToLeftAutoMirrorImage = true;
            this.Button_Eraser.Size = new System.Drawing.Size(23, 24);
            this.Button_Eraser.Text = "Eraser";
            this.Button_Eraser.Click += new System.EventHandler(this.Button_Eraser_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button_New,
            this.Button_Load,
            this.Button_Save});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(84, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // Button_New
            // 
            this.Button_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_New.Image = global::GraphicalEditor.Properties.Resources.new_draw_area;
            this.Button_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_New.Name = "Button_New";
            this.Button_New.Size = new System.Drawing.Size(24, 24);
            this.Button_New.Text = "New";
            this.Button_New.Click += new System.EventHandler(this.Button_New_Click);
            // 
            // Button_Load
            // 
            this.Button_Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Load.Image = global::GraphicalEditor.Properties.Resources.open;
            this.Button_Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Load.Name = "Button_Load";
            this.Button_Load.Size = new System.Drawing.Size(24, 24);
            this.Button_Load.Text = "Open";
            this.Button_Load.Click += new System.EventHandler(this.Button_Load_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Save.Image = global::GraphicalEditor.Properties.Resources.save;
            this.Button_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(24, 24);
            this.Button_Save.Text = "Save";
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label_BrushSize,
            this.Textbox_BrushSize,
            this.Button_Apply_BrushSize,
            this.Button_Undo,
            this.Button_Redo});
            this.toolStrip2.Location = new System.Drawing.Point(87, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(302, 27);
            this.toolStrip2.TabIndex = 1;
            // 
            // Label_BrushSize
            // 
            this.Label_BrushSize.Enabled = false;
            this.Label_BrushSize.Name = "Label_BrushSize";
            this.Label_BrushSize.Size = new System.Drawing.Size(77, 24);
            this.Label_BrushSize.Text = "Brush size:";
            // 
            // Textbox_BrushSize
            // 
            this.Textbox_BrushSize.Enabled = false;
            this.Textbox_BrushSize.Name = "Textbox_BrushSize";
            this.Textbox_BrushSize.Size = new System.Drawing.Size(100, 27);
            // 
            // Button_Apply_BrushSize
            // 
            this.Button_Apply_BrushSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Apply_BrushSize.Enabled = false;
            this.Button_Apply_BrushSize.Image = global::GraphicalEditor.Properties.Resources.apply;
            this.Button_Apply_BrushSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Apply_BrushSize.Name = "Button_Apply_BrushSize";
            this.Button_Apply_BrushSize.Size = new System.Drawing.Size(24, 24);
            this.Button_Apply_BrushSize.Text = "Apply";
            // 
            // Button_Undo
            // 
            this.Button_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Undo.Image = global::GraphicalEditor.Properties.Resources.undo;
            this.Button_Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Undo.Name = "Button_Undo";
            this.Button_Undo.Size = new System.Drawing.Size(24, 24);
            this.Button_Undo.Text = "Undo";
            this.Button_Undo.Click += new System.EventHandler(this.Button_Undo_Click);
            // 
            // Button_Redo
            // 
            this.Button_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Redo.Image = global::GraphicalEditor.Properties.Resources.redo;
            this.Button_Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Redo.Name = "Button_Redo";
            this.Button_Redo.Size = new System.Drawing.Size(24, 24);
            this.Button_Redo.Text = "Redo";
            this.Button_Redo.Click += new System.EventHandler(this.Button_Redo_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 734);
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.Text = "GraphicalEditor";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_DrawArea)).EndInit();
            this.Panel_Colorpicker.ResumeLayout(false);
            this.Panel_Colorpicker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picturebox_CurrentColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trackbar_Colorpicker_Alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trackbar_Colorpicker_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trackbar_Colorpicker_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trackbar_ColorPicker_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_ColorPicker)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton Button_Rectangle;
        private System.Windows.Forms.ToolStripButton Button_Ellipse;
        private System.Windows.Forms.ToolStripButton Button_Line;
        private System.Windows.Forms.ToolStripButton Button_Brush;
        private System.Windows.Forms.ToolStripButton Button_Pencil;
        private System.Windows.Forms.ToolStripButton Button_ColorPicker;
        private System.Windows.Forms.ToolStripButton Button_Eraser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Button_New;
        private System.Windows.Forms.ToolStripButton Button_Load;
        private System.Windows.Forms.ToolStripButton Button_Save;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel Label_BrushSize;
        private System.Windows.Forms.ToolStripTextBox Textbox_BrushSize;
        private System.Windows.Forms.ToolStripButton Button_Apply_BrushSize;
        private System.Windows.Forms.PictureBox PictureBox_DrawArea;
        private System.Windows.Forms.Panel Panel_Colorpicker;
        private System.Windows.Forms.PictureBox Picturebox_CurrentColor;
        private System.Windows.Forms.TrackBar Trackbar_Colorpicker_Alpha;
        private System.Windows.Forms.TrackBar Trackbar_Colorpicker_Blue;
        private System.Windows.Forms.TrackBar Trackbar_Colorpicker_Green;
        private System.Windows.Forms.TrackBar Trackbar_ColorPicker_Red;
        private System.Windows.Forms.Label Label_Colorpicker_alphaval;
        private System.Windows.Forms.Label Label_Colorpicker_blueval;
        private System.Windows.Forms.Label Label_Colorpicker_greenval;
        private System.Windows.Forms.Label Label_Colorpicker_redval;
        private System.Windows.Forms.Label Label_Colorpicker_A;
        private System.Windows.Forms.Label Label_Colorpicker_B;
        private System.Windows.Forms.Label Label_Colorpicker_G;
        private System.Windows.Forms.Label Label_ColorPicker_R;
        private System.Windows.Forms.PictureBox PictureBox_ColorPicker;
        private System.Windows.Forms.Label label_SelectedTool;
        private System.Windows.Forms.ToolStripButton Button_Undo;
        private System.Windows.Forms.ToolStripButton Button_Redo;
    }
}

