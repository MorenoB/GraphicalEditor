using GraphicalEditor.Interfaces;
using System.Drawing;

namespace GraphicalEditor.Shapes
{
    public class RectangleShape : IShape
    {
        public int Width
        {
            get { return width; }
            set
            {
                if (value == width) return;

                width = value;
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if (value == height) return;

                height = value;
            }
        }

        public Brush Brush
        {
            get { return brush; }
            set
            {
                if (value == brush) return;

                brush = value;
            }
        }

        public Point TopLeftPoint
        {
            get
            {
                return topLeft;
            }
            set
            {
                if (value == topLeft)
                    return;

                topLeft = value;
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
            }
        }

        private bool isSelected;
 
        private int width;
        private int height;

        private Point topLeft;
        private Brush brush;

        public RectangleShape(Brush brush, Point topLeft, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.brush = brush;
            this.topLeft = topLeft;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(brush, topLeft.X, topLeft.Y, width, height);

            if (IsSelected)
            {
                g.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(TopLeftPoint, new Size(Width, Height)));
            }
        }

        public bool WasClicked(Point p)
        {
            return p.X >= topLeft.X && p.X < topLeft.X + width
                && p.Y >= topLeft.Y && p.Y < topLeft.Y + height;
        }
    }
}
