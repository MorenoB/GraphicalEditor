using GraphicalEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicalEditor
{
    public partial class Form1 : Form
    {

        List<Shape> shapeList = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            shapeList.Add(new Shape(100, 100, 100, 100));
        }

        private void button_Circle_Click(object sender, EventArgs e)
        {

        }

        private void panel_DrawArea_Paint(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < shapeList.Count; i++)
            {
                Shape shape = shapeList[i];
                if (shape == null) continue;

                if (!shape.IsDirty) continue;

                using (Graphics g = e.Graphics)
                {
                    var p = new Pen(Color.Black, 3);
                    var Rectangle = new Rectangle(shape.Location_X, shape.Location_Y, shape.Width, shape.Length);
                    g.DrawRectangle(p, Rectangle);
                }

            }
            base.OnPaint(e);

        
    }
    }
}
