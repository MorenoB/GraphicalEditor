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
        private Color paintcolor;

        private bool isChoosingColor = false;
        private bool holdingMouseDown = false;
        private SelectedState selectedState;

        private int mouseLocationX, mouseLocationY = 0;
        private Item selectedItem;
        private Item SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value == selectedItem)
                    return;

                selectedItem = value;

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

            brush = new SolidBrush(paintcolor);
            SelectedItem = Item.None;
        }

        public enum Item
        {
            Rectangle, Ellipse, Line, Brush, Pencil, eraser, ColorPicker, None
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

                paintcolor = bmp.GetPixel(e.X, e.Y);
                Trackbar_ColorPicker_Red.Value = paintcolor.R;
                Trackbar_Colorpicker_Green.Value = paintcolor.G;
                Trackbar_Colorpicker_Blue.Value = paintcolor.B;
                Trackbar_Colorpicker_Alpha.Value = paintcolor.A;
                Label_Colorpicker_redval.Text = paintcolor.R.ToString();
                Label_Colorpicker_greenval.Text = paintcolor.G.ToString();
                Label_Colorpicker_blueval.Text = paintcolor.B.ToString();
                Label_Colorpicker_alphaval.Text = paintcolor.A.ToString();
                Picturebox_CurrentColor.BackColor = paintcolor;

                brush = new SolidBrush(paintcolor);
            }
        }

        private void Picturebox_DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            holdingMouseDown = true;

            switch (SelectedItem)
            {
                case Item.Rectangle:

                    Shapes.Rectangle rectangle = new Shapes.Rectangle(brush, e.Location, e.X - mouseLocationX, e.Y - mouseLocationY);
                    DrawHandlerInstance.AddNewShape(rectangle);

                    DrawHandlerInstance.SelectedShape = rectangle;

                    selectedState = SelectedState.Resizing;
                    break;

                case Item.Ellipse:

                    Ellipse ellipse = new Ellipse(brush, e.Location, e.X - mouseLocationX, e.Y - mouseLocationY);
                    DrawHandlerInstance.AddNewShape(ellipse);

                    DrawHandlerInstance.SelectedShape = ellipse;

                    selectedState = SelectedState.Resizing;
                    break;

                case Item.None:

                    selectedState = SelectedState.Moving;
                    DrawHandlerInstance.SelectedShape = null;
                    break;
            }

            SelectedItem = Item.None;

            DrawHandlerInstance.SelectShapeFromPoint(e.Location);


            mouseLocationX = e.X;
            mouseLocationY = e.Y;

            PictureBox_DrawArea.Invalidate();
        }

        private void PictureBox_DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            holdingMouseDown = false;
            mouseLocationX = e.X;
            mouseLocationY = e.Y;

            switch (SelectedItem)
            {
                case Item.Line:
                    Graphics g = PictureBox_DrawArea.CreateGraphics();
                    g.DrawLine(new Pen(new SolidBrush(paintcolor)), new Point(mouseLocationX, mouseLocationY), new Point(mouseLocationX, mouseLocationY));
                    g.Dispose();
                    break;
            }

            PictureBox_DrawArea.Invalidate();
        }

        private void PictureBox_DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (holdingMouseDown)
            {
                switch(selectedState)
                {
                    case SelectedState.Moving:
                        DrawHandlerInstance.MoveSelectedShape(e.Location);
                        break;

                    case SelectedState.Resizing:
                        DrawHandlerInstance.ResizeSelectedShape(e.X - mouseLocationX, e.Y - mouseLocationY);
                        break;
                }
                PictureBox_DrawArea.Invalidate();
            }
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

            switch(SelectedItem)
            {
                case Item.Brush:
                    Button_Brush.Checked = true;
                    break;

                case Item.Ellipse:
                    Button_Ellipse.Checked = true;
                    break;

                case Item.eraser:
                    Button_Eraser.Checked = true;
                    break;

                case Item.Line:
                    Button_Line.Checked = true;
                    break;

                case Item.Pencil:
                    Button_Pencil.Checked = true;
                    break;

                case Item.Rectangle:
                    Button_Rectangle.Checked = true;
                    break;

                case Item.ColorPicker:
                    Button_ColorPicker.Checked = true;
                    break;

            }
        }
        

        private void Button_Brush_Click(object sender, EventArgs e)
        {
            SelectedItem = Item.Brush;
        }

        private void Button_Rectangle_Click(object sender, EventArgs e)
        {
            SelectedItem = Item.Rectangle;
        }

        private void Button_Ellipse_Click(object sender, EventArgs e)
        {
            SelectedItem = Item.Ellipse;
        }

        private void Button_Pencil_Click(object sender, EventArgs e)
        {
            SelectedItem = Item.Pencil;
        }

        private void Button_Eraser_Click(object sender, EventArgs e)
        {
            SelectedItem = Item.eraser;
        }

        private void Button_line_Click(object sender, EventArgs e)
        {
            SelectedItem = Item.Line;
        }

        private void Button_ColorPicker_Click(object sender, EventArgs e)
        {
            SelectedItem = Item.ColorPicker;
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
            g.CopyFromScreen(rect.Location, Point.Empty, PictureBox_DrawArea.Size);
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
            paintcolor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = paintcolor;
            Label_Colorpicker_redval.Text = "R: " + paintcolor.R.ToString();
        }

        private void Trackbar_ColorPicker_Green_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = paintcolor;
            Label_Colorpicker_greenval.Text = "G: " + paintcolor.G.ToString();
        }

        private void Trackbar_ColorPicker_Blue_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = paintcolor;
            Label_Colorpicker_blueval.Text = "B: " + paintcolor.B.ToString();
        }

        private void PictureBox_DrawArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem == Item.ColorPicker)
            {
                Bitmap bmp = new Bitmap(PictureBox_DrawArea.Width, PictureBox_DrawArea.Height);
                Graphics g = Graphics.FromImage(bmp);
                System.Drawing.Rectangle rect = PictureBox_DrawArea.RectangleToScreen(PictureBox_DrawArea.ClientRectangle);
                g.CopyFromScreen(rect.Location, Point.Empty, PictureBox_DrawArea.Size);
                g.Dispose();
                paintcolor = bmp.GetPixel(e.X, e.Y);
                Picturebox_CurrentColor.BackColor = paintcolor;
                Trackbar_ColorPicker_Red.Value = paintcolor.R;
                Trackbar_Colorpicker_Green.Value = paintcolor.G;
                Trackbar_Colorpicker_Blue.Value = paintcolor.B;
                Trackbar_Colorpicker_Alpha.Value = paintcolor.A;
                Label_Colorpicker_redval.Text = paintcolor.R.ToString();
                Label_Colorpicker_greenval.Text = paintcolor.G.ToString();
                Label_Colorpicker_blueval.Text = paintcolor.B.ToString();
                Label_Colorpicker_alphaval.Text = paintcolor.A.ToString();
                bmp.Dispose();
            }
        }

        private void PictureBox_DrawArea_Paint(object sender, PaintEventArgs e)
        {
            DrawHandlerInstance.RedrawAllDirtyShapes(e.Graphics);
        }

        private void Trackbar_ColorPicker_Alpha_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = paintcolor;
            Label_Colorpicker_alphaval.Text = "A: " + paintcolor.A.ToString();
        }
    }
}
