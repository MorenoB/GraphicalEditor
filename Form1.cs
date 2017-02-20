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

        private int mouseLocationX, mouseLocationY = 0;
        private Item selectedItem;
        private SolidBrush brush;

        private DrawHandler DrawHandlerInstance { get { return DrawHandler.Instance; } }


        public Form()
        {
            InitializeComponent();

            brush = new SolidBrush(paintcolor);
            selectedItem = Item.None;
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

            switch (selectedItem)
            {
                case Item.Rectangle:

                    Shape rectangle = new Shape(Shape.ShapeTypeEnum.RECTANGLE, brush, e.Location, e.X - mouseLocationX, e.Y - mouseLocationY);
                    DrawHandlerInstance.AddNewShape(rectangle);

                    DrawHandlerInstance.SelectedShape = rectangle;
                    break;

                case Item.Ellipse:

                    Shape ellipse = new Shape(Shape.ShapeTypeEnum.CIRCLE, brush, e.Location, e.X - mouseLocationX, e.Y - mouseLocationY);
                    DrawHandlerInstance.AddNewShape(ellipse);

                    DrawHandlerInstance.SelectedShape = ellipse;
                    break;

                case Item.None:

                    DrawHandlerInstance.SelectedShape = null;
                    break;
            }


            mouseLocationX = e.X;
            mouseLocationY = e.Y;
        }

        private void PictureBox_DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            holdingMouseDown = false;
            mouseLocationX = e.X;
            mouseLocationY = e.Y;

            //DrawHandlerInstance.ShapeList.Add(new Shape(Shape.ShapeTypeEnum.RECTANGLE, brush.Color , mouseLocationX, mouseLocationY, e.X - mouseLocationX, e.Y - mouseLocationY));

            switch (selectedItem)
            {
                case Item.Line:
                    Graphics g = PictureBox_DrawArea.CreateGraphics();
                    g.DrawLine(new Pen(new SolidBrush(paintcolor)), new Point(mouseLocationX, mouseLocationY), new Point(mouseLocationX, mouseLocationY));
                    g.Dispose();
                    break;
            }
        }

        private void PictureBox_DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (holdingMouseDown)
            {
                Graphics g = PictureBox_DrawArea.CreateGraphics();


                DrawHandlerInstance.ResizeSelectedShape(e.X - mouseLocationX, e.Y - mouseLocationY);

                DrawHandlerInstance.RedrawAllDirtyShapes(g);
                
                switch (selectedItem)
                {
                   /* case Item.Rectangle:
                        g.FillRectangle(brush, mouseLocationX, mouseLocationY, e.X - mouseLocationX, e.Y - mouseLocationY);
                        
                        break;
                    case Item.Ellipse:
                        g.FillEllipse(brush, mouseLocationX, mouseLocationY, e.X - mouseLocationX, e.Y - mouseLocationY);
                        break;*/
                    case Item.Brush:
                        g.FillEllipse(brush, e.X - mouseLocationX + mouseLocationX, e.Y - mouseLocationY + mouseLocationY, Convert.ToInt32(Textbox_BrushSize.Text), Convert.ToInt32(Textbox_BrushSize.Text));
                        break;
                    case Item.Pencil:
                        g.FillEllipse(brush, e.X - mouseLocationX + mouseLocationX, e.Y - mouseLocationY + mouseLocationY, 5, 5);
                        break;
                    case Item.eraser:
                        g.FillEllipse(new SolidBrush(PictureBox_DrawArea.BackColor), e.X - mouseLocationX + mouseLocationX, e.Y - mouseLocationY + mouseLocationY, Convert.ToInt32(Textbox_BrushSize.Text), Convert.ToInt32(Textbox_BrushSize.Text));
                        
                        break;
                }
                g.Dispose();
            }
        }
        

        private void Button_Brush_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Brush;
        }

        private void Button_Rectangle_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Rectangle;
        }

        private void Button_Circle_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Ellipse;
        }

        private void Button_Pencil_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Pencil;
        }

        private void Button_Eraser_Click(object sender, EventArgs e)
        {
            selectedItem = Item.eraser;
        }

        private void Button_line_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Line;
        }

        private void Button_ColorPicker_Click(object sender, EventArgs e)
        {
            selectedItem = Item.ColorPicker;
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
            Rectangle rect = PictureBox_DrawArea.RectangleToScreen(PictureBox_DrawArea.ClientRectangle);
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
            if (selectedItem == Item.ColorPicker)
            {
                Bitmap bmp = new Bitmap(PictureBox_DrawArea.Width, PictureBox_DrawArea.Height);
                Graphics g = Graphics.FromImage(bmp);
                Rectangle rect = PictureBox_DrawArea.RectangleToScreen(PictureBox_DrawArea.ClientRectangle);
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

        private void Trackbar_ColorPicker_Alpha_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = paintcolor;
            Label_Colorpicker_alphaval.Text = "A: " + paintcolor.A.ToString();
        }
    }
}
