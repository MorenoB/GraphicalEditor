namespace GraphicalEditor
{
    partial class Form1
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
            this.button_Rectangle = new System.Windows.Forms.Button();
            this.groupBox_Shapes = new System.Windows.Forms.GroupBox();
            this.button_Circle = new System.Windows.Forms.Button();
            this.groupBox_Tools = new System.Windows.Forms.GroupBox();
            this.panel_DrawArea = new System.Windows.Forms.Panel();
            this.groupBox_Misc = new System.Windows.Forms.GroupBox();
            this.groupBox_Shapes.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Rectangle
            // 
            this.button_Rectangle.Location = new System.Drawing.Point(6, 21);
            this.button_Rectangle.Name = "button_Rectangle";
            this.button_Rectangle.Size = new System.Drawing.Size(112, 35);
            this.button_Rectangle.TabIndex = 0;
            this.button_Rectangle.Text = "Rectangle";
            this.button_Rectangle.UseVisualStyleBackColor = true;
            this.button_Rectangle.Click += new System.EventHandler(this.button_Rectangle_Click);
            // 
            // groupBox_Shapes
            // 
            this.groupBox_Shapes.Controls.Add(this.button_Circle);
            this.groupBox_Shapes.Controls.Add(this.button_Rectangle);
            this.groupBox_Shapes.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Shapes.Name = "groupBox_Shapes";
            this.groupBox_Shapes.Size = new System.Drawing.Size(245, 100);
            this.groupBox_Shapes.TabIndex = 1;
            this.groupBox_Shapes.TabStop = false;
            this.groupBox_Shapes.Text = "Shapes";
            // 
            // button_Circle
            // 
            this.button_Circle.Location = new System.Drawing.Point(124, 21);
            this.button_Circle.Name = "button_Circle";
            this.button_Circle.Size = new System.Drawing.Size(112, 35);
            this.button_Circle.TabIndex = 1;
            this.button_Circle.Text = "Circle";
            this.button_Circle.UseVisualStyleBackColor = true;
            this.button_Circle.Click += new System.EventHandler(this.button_Circle_Click);
            // 
            // groupBox_Tools
            // 
            this.groupBox_Tools.Location = new System.Drawing.Point(12, 119);
            this.groupBox_Tools.Name = "groupBox_Tools";
            this.groupBox_Tools.Size = new System.Drawing.Size(245, 135);
            this.groupBox_Tools.TabIndex = 2;
            this.groupBox_Tools.TabStop = false;
            this.groupBox_Tools.Text = "Tools";
            // 
            // panel_DrawArea
            // 
            this.panel_DrawArea.Location = new System.Drawing.Point(264, 13);
            this.panel_DrawArea.Name = "panel_DrawArea";
            this.panel_DrawArea.Size = new System.Drawing.Size(788, 519);
            this.panel_DrawArea.TabIndex = 3;
            this.panel_DrawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_DrawArea_Paint);
            // 
            // groupBox_Misc
            // 
            this.groupBox_Misc.Location = new System.Drawing.Point(12, 260);
            this.groupBox_Misc.Name = "groupBox_Misc";
            this.groupBox_Misc.Size = new System.Drawing.Size(245, 135);
            this.groupBox_Misc.TabIndex = 3;
            this.groupBox_Misc.TabStop = false;
            this.groupBox_Misc.Text = "Misc";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 544);
            this.Controls.Add(this.groupBox_Misc);
            this.Controls.Add(this.panel_DrawArea);
            this.Controls.Add(this.groupBox_Tools);
            this.Controls.Add(this.groupBox_Shapes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox_Shapes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Rectangle;
        private System.Windows.Forms.GroupBox groupBox_Shapes;
        private System.Windows.Forms.Button button_Circle;
        private System.Windows.Forms.GroupBox groupBox_Tools;
        private System.Windows.Forms.Panel panel_DrawArea;
        private System.Windows.Forms.GroupBox groupBox_Misc;
    }
}

