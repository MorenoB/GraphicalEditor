using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using GraphicalEditor.Shapes;

namespace GraphicalEditor
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Color paintColor;
        private Color PaintColor
        {
            get
            {
                return paintColor;
            }
            set
            {
                if (value == paintColor)
                    return;

                paintColor = value;

                brush = new SolidBrush(paintColor);
            }
        }

        private bool isChoosingColor = false;
        private bool holdingMouseDown = false;
        private SelectedState selectedState;

        private int mouseLocationX, mouseLocationY = 0;
        private ToolItem currentTool;
        private ToolItem CurrentTool
        {
            get
            {
                return currentTool;
            }
            set
            {
                if (value == currentTool)
                    return;

                currentTool = value;

                label_SelectedTool.Text = "Selected Tool: " + currentTool.ToString();

                UpdateToolButtonsCheckedState();
            }
        }
        private SolidBrush brush;

        private DrawHandler DrawHandlerInstance { get { return DrawHandler.Instance; } }

        public enum SelectedState
        {
            Resizing, Moving
        }


        public Form()
        {
            InitializeComponent();

            brush = new SolidBrush(PaintColor);
            CurrentTool = ToolItem.None;
        }

        public enum ToolItem
        {
            Rectangle, Ellipse, Line, Brush, Pencil, Eraser, ColorPicker, None
        }

        private void PictureBox_ColorPicker_MouseDown(object sender, MouseEventArgs e)
        {
            isChoosingColor = true;
        }

        private void PictureBox_ColorPicker_MouseUp(object sender, MouseEventArgs e)
        {
            isChoosingColor = false;
        }

        private void PictureBox_ColorPicker_MouseMove(object sender, MouseEventArgs e)
        {
            if (isChoosingColor)
            {
                Bitmap bmp = (Bitmap)PictureBox_ColorPicker.Image.Clone();

                if (e.X < 0 || e.Y < 0)
                    return;

                if (e.X >= bmp.Width)
                    return;

                if (e.Y >= bmp.Height)
                    return;

                PaintColor = bmp.GetPixel(e.X, e.Y);
                Trackbar_ColorPicker_Red.Value = PaintColor.R;
                Trackbar_Colorpicker_Green.Value = PaintColor.G;
                Trackbar_Colorpicker_Blue.Value = PaintColor.B;
                Trackbar_Colorpicker_Alpha.Value = PaintColor.A;
                Label_Colorpicker_redval.Text = PaintColor.R.ToString();
                Label_Colorpicker_greenval.Text = PaintColor.G.ToString();
                Label_Colorpicker_blueval.Text = PaintColor.B.ToString();
                Label_Colorpicker_alphaval.Text = PaintColor.A.ToString();
                Picturebox_CurrentColor.BackColor = PaintColor;
            }
        }

        private void Picturebox_DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            holdingMouseDown = true;

            switch (CurrentTool)
            {
                case ToolItem.Rectangle:

                    Shapes.Rectangle rectangle = new Shapes.Rectangle(brush, e.Location, e.X - mouseLocationX, e.Y - mouseLocationY);
                    DrawHandlerInstance.AddNewShape(rectangle);

                    selectedState = SelectedState.Resizing;
                    CurrentTool = ToolItem.None;
                    break;

                case ToolItem.Ellipse:

                    Ellipse ellipse = new Ellipse(brush, e.Location, e.X - mouseLocationX, e.Y - mouseLocationY);
                    DrawHandlerInstance.AddNewShape(ellipse);

                    selectedState = SelectedState.Resizing;
                    CurrentTool = ToolItem.None;
                    break;

                case ToolItem.None:

                    DrawHandlerInstance.SelectShapeFromPoint(e.Location);
                    selectedState = SelectedState.Moving;
                    break;
            }

            mouseLocationX = e.X;
            mouseLocationY = e.Y;

            PictureBox_DrawArea.Invalidate();
        }

        private void PictureBox_DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            holdingMouseDown = false;
            mouseLocationX = e.X;
            mouseLocationY = e.Y;

            switch (CurrentTool)
            {
                case ToolItem.Line:
                    Graphics g = PictureBox_DrawArea.CreateGraphics();
                    g.DrawLine(new Pen(new SolidBrush(PaintColor)), new Point(mouseLocationX, mouseLocationY), new Point(mouseLocationX, mouseLocationY));
                    g.Dispose();
                    break;
            }

            PictureBox_DrawArea.Invalidate();
        }

        private void PictureBox_DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (holdingMouseDown)
            {

                switch (CurrentTool)
                {
                    case ToolItem.None:

                        switch (selectedState)
                        {
                            case SelectedState.Moving:
                                DrawHandlerInstance.MoveSelectedShape(e.Location);
                                break;

                            case SelectedState.Resizing:
                                DrawHandlerInstance.ResizeSelectedShape(e.X - mouseLocationX, e.Y - mouseLocationY);
                                break;
                        }
                        break;
                }
            }
            PictureBox_DrawArea.Invalidate();
        }


        private void UpdateToolButtonsCheckedState()
        {

            Button_Brush.Checked = false;
            Button_Ellipse.Checked = false;
            Button_Eraser.Checked = false;
            Button_Line.Checked = false;
            Button_Pencil.Checked = false;
            Button_Rectangle.Checked = false;
            Button_ColorPicker.Checked = false;

            switch (CurrentTool)
            {
                case ToolItem.Brush:
                    Button_Brush.Checked = true;
                    break;

                case ToolItem.Ellipse:
                    Button_Ellipse.Checked = true;
                    break;

                case ToolItem.Eraser:
                    Button_Eraser.Checked = true;
                    break;

                case ToolItem.Line:
                    Button_Line.Checked = true;
                    break;

                case ToolItem.Pencil:
                    Button_Pencil.Checked = true;
                    break;

                case ToolItem.Rectangle:
                    Button_Rectangle.Checked = true;
                    break;

                case ToolItem.ColorPicker:
                    Button_ColorPicker.Checked = true;
                    break;

            }
        }


        private void Button_Brush_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Brush;
        }

        private void Button_Rectangle_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Rectangle;
        }

        private void Button_Ellipse_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Ellipse;
        }

        private void Button_Pencil_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Pencil;
        }

        private void Button_Eraser_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Eraser;
        }

        private void Button_line_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.Line;
        }

        private void Button_ColorPicker_Click(object sender, EventArgs e)
        {
            CurrentTool = ToolItem.ColorPicker;
        }

        private void Button_New_Click(object sender, EventArgs e)
        {
            PictureBox_DrawArea.Refresh();
            PictureBox_DrawArea.Image = null;
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            PictureBox_DrawArea.Refresh();
            PictureBox_DrawArea.Image = null;
        }

        private void Button_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (o.ShowDialog() == DialogResult.OK)
            {
                PictureBox_DrawArea.Image = (Image)Image.FromFile(o.FileName).Clone();
            }
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(PictureBox_DrawArea.Width, PictureBox_DrawArea.Height);
            Graphics g = Graphics.FromImage(bmp);
            System.Drawing.Rectangle rect = PictureBox_DrawArea.RectangleToScreen(PictureBox_DrawArea.ClientRectangle);
            g.CopyFromScreen(PictureBox_DrawArea.Location, Point.Empty, PictureBox_DrawArea.Size);
            g.Dispose();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (s.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }
                if (s.FileName.Contains(".jpg"))
                {
                    bmp.Save(s.FileName, ImageFormat.Jpeg);
                }
                else if (s.FileName.Contains(".png"))
                {
                    bmp.Save(s.FileName, ImageFormat.Png);
                }
                else if (s.FileName.Contains(".bmp"))
                {
                    bmp.Save(s.FileName, ImageFormat.Bmp);
                }
            }
        }

        private void Trackbar_ColorPicker_Red_Scroll(object sender, EventArgs e)
        {
            PaintColor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = PaintColor;
            Label_Colorpicker_redval.Text = "R: " + PaintColor.R.ToString();
        }

        private void Trackbar_ColorPicker_Green_Scroll(object sender, EventArgs e)
        {
            PaintColor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = PaintColor;
            Label_Colorpicker_greenval.Text = "G: " + PaintColor.G.ToString();
        }

        private void Trackbar_ColorPicker_Blue_Scroll(object sender, EventArgs e)
        {
            PaintColor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = PaintColor;
            Label_Colorpicker_blueval.Text = "B: " + PaintColor.B.ToString();
        }

        private void PictureBox_DrawArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (CurrentTool == ToolItem.ColorPicker)
            {
                Bitmap bmp = new Bitmap(PictureBox_DrawArea.Width, PictureBox_DrawArea.Height);
                Graphics g = Graphics.FromImage(bmp);
                System.Drawing.Rectangle rect = PictureBox_DrawArea.RectangleToScreen(PictureBox_DrawArea.ClientRectangle);
                g.CopyFromScreen(rect.Location, Point.Empty, PictureBox_DrawArea.Size);
                g.Dispose();
                PaintColor = bmp.GetPixel(e.X, e.Y);
                Picturebox_CurrentColor.BackColor = PaintColor;
                Trackbar_ColorPicker_Red.Value = PaintColor.R;
                Trackbar_Colorpicker_Green.Value = PaintColor.G;
                Trackbar_Colorpicker_Blue.Value = PaintColor.B;
                Trackbar_Colorpicker_Alpha.Value = PaintColor.A;
                Label_Colorpicker_redval.Text = PaintColor.R.ToString();
                Label_Colorpicker_greenval.Text = PaintColor.G.ToString();
                Label_Colorpicker_blueval.Text = PaintColor.B.ToString();
                Label_Colorpicker_alphaval.Text = PaintColor.A.ToString();
                bmp.Dispose();
            }
        }

        private void PictureBox_DrawArea_Paint(object sender, PaintEventArgs e)
        {
            DrawHandlerInstance.RedrawAllDirtyShapes(e.Graphics);
        }

        private void Trackbar_ColorPicker_Alpha_Scroll(object sender, EventArgs e)
        {
            PaintColor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = PaintColor;
            Label_Colorpicker_alphaval.Text = "A: " + PaintColor.A.ToString();
        }
    }
}
