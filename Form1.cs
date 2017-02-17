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
        private List<Shape> shapeList = new List<Shape>();
        private Color paintcolor;

        private bool isChoosingColor = false;
        private bool holdingMouseDown = false;

        private int mouseLocationX, mouseLocationY = 0;
        private Item selectedItem;


        public Form()
        {
            InitializeComponent();
        }

        public enum Item
        {
            Rectangle, Ellipse, Line, Text, Brush, Pencil, eraser, ColorPicker
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            isChoosingColor = true;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            isChoosingColor = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
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
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            holdingMouseDown = true;
            mouseLocationX = e.X;
            mouseLocationY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            holdingMouseDown = false;
            mouseLocationX = e.X;
            mouseLocationY = e.Y;
            
            if (selectedItem == Item.Line)
            {
                Graphics g = PictureBox_DrawArea.CreateGraphics();
                g.DrawLine(new Pen(new SolidBrush(paintcolor)), new Point(mouseLocationX, mouseLocationY), new Point(mouseLocationX, mouseLocationY));
                g.Dispose();

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (holdingMouseDown)
            {
                Graphics g = PictureBox_DrawArea.CreateGraphics();
                
                switch (selectedItem)
                {
                    case Item.Rectangle:
                        g.FillRectangle(new SolidBrush(paintcolor), mouseLocationX, mouseLocationY, e.X - mouseLocationX, e.Y - mouseLocationY);
                        break;
                    case Item.Ellipse:
                        g.FillEllipse(new SolidBrush(paintcolor), mouseLocationX, mouseLocationY, e.X - mouseLocationX, e.Y - mouseLocationY);
                        break;
                    case Item.Brush:
                        g.FillEllipse(new SolidBrush(paintcolor), e.X - mouseLocationX + mouseLocationX, e.Y - mouseLocationY + mouseLocationY, Convert.ToInt32(Textbox_BrushSize.Text), Convert.ToInt32(Textbox_BrushSize.Text));
                        break;
                    case Item.Pencil:
                        g.FillEllipse(new SolidBrush(paintcolor), e.X - mouseLocationX + mouseLocationX, e.Y - mouseLocationY + mouseLocationY, 5, 5);
                        break;
                    case Item.eraser:
                        g.FillEllipse(new SolidBrush(PictureBox_DrawArea.BackColor), e.X - mouseLocationX + mouseLocationX, e.Y - mouseLocationY + mouseLocationY, Convert.ToInt32(Textbox_BrushSize.Text), Convert.ToInt32(Textbox_BrushSize.Text));
                        break;
                }
                g.Dispose();
            }
        }
        

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Brush;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Rectangle;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Ellipse;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Pencil;
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            selectedItem = Item.eraser;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Line;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            selectedItem = Item.ColorPicker;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
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

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            selectedItem = Item.Text;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Graphics g = PictureBox_DrawArea.CreateGraphics();
            if (selectedItem == Item.Text)
            {
                if (Combobox_FontStyle.Text == "Regular")
                {
                    g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                }
                else if (Combobox_FontStyle.Text == "Bold")
                {
                    g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                }
                else if (Combobox_FontStyle.Text == "Underline")
                {
                    g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                }
                else if (Combobox_FontStyle.Text == "Strikeout")
                {
                    g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                }
                else if (Combobox_FontStyle.Text == "Italic")
                {
                    g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                }
                if(ComboBox_TextShadow.Text == "SE")
                {
                    if (Combobox_FontStyle.Text == "Regular")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Bold")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Underline")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Strikeout")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Italic")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                }
                else if (ComboBox_TextShadow.Text == "SW")
                {
                    if (Combobox_FontStyle.Text == "Regular")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Bold")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Underline")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Strikeout")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Italic")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                }
                else if (ComboBox_TextShadow.Text == "NE")
                {
                    if (Combobox_FontStyle.Text == "Regular")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Bold")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Underline")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Strikeout")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Italic")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                }
                else if (ComboBox_TextShadow.Text == "NW")
                {
                    if (Combobox_FontStyle.Text == "Regular")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Bold")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Underline")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Strikeout")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Italic")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                }
                 else if (ComboBox_TextShadow.Text == "S")
                {
                    if (Combobox_FontStyle.Text == "Regular")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Bold")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Underline")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Strikeout")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Italic")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY + 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                }
                else if (ComboBox_TextShadow.Text == "N")
                {
                    if (Combobox_FontStyle.Text == "Regular")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Bold")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Underline")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Strikeout")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Italic")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(mouseLocationX, mouseLocationY - 5));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                }
                else if (ComboBox_TextShadow.Text == "W")
                {
                    if (Combobox_FontStyle.Text == "Regular")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Bold")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Underline")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Strikeout")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Italic")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(mouseLocationX - 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                }
                else if (ComboBox_TextShadow.Text == "E")
                {
                    if (Combobox_FontStyle.Text == "Regular")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Bold")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Underline")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Strikeout")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                    else if (Combobox_FontStyle.Text == "Italic")
                    {
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(mouseLocationX + 5, mouseLocationY));
                        g.DrawString(Textbox_TextToDraw.Text, new Font(ComboBox_FontName.Text, Convert.ToInt32(Combobox_FontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(mouseLocationX, mouseLocationY));
                    }
                }
                g.Dispose();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PictureBox_DrawArea.Refresh();
            PictureBox_DrawArea.Image = null;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PictureBox_DrawArea.Refresh();
            PictureBox_DrawArea.Image = null;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (o.ShowDialog() == DialogResult.OK)
            {
                PictureBox_DrawArea.Image = (Image)Image.FromFile(o.FileName).Clone();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            FontFamily[] family = FontFamily.Families;
            foreach (FontFamily font in family)
            {
                ComboBox_FontName.Items.Add(font.GetName(1).ToString());
            }
        }

        private void red_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = paintcolor;
            Label_Colorpicker_redval.Text = "R: " + paintcolor.R.ToString();
        }

        private void green_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = paintcolor;
            Label_Colorpicker_greenval.Text = "G: " + paintcolor.G.ToString();
        }

        private void blue_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = paintcolor;
            Label_Colorpicker_blueval.Text = "B: " + paintcolor.B.ToString();
        }

        private void alpha_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(Trackbar_Colorpicker_Alpha.Value, Trackbar_ColorPicker_Red.Value, Trackbar_Colorpicker_Green.Value, Trackbar_Colorpicker_Blue.Value);
            Picturebox_CurrentColor.BackColor = paintcolor;
            Label_Colorpicker_alphaval.Text = "A: " + paintcolor.A.ToString();
        }
    }
}
