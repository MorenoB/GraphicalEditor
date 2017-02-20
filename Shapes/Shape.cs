using System.Drawing;

namespace GraphicalEditor.Shapes
{
    public class Shape
    {
        public int Width
        {
            get { return width; }
            set
            {
                if (value == width) return;

                width = value;
                dirty = true;
            }
        }
        public int Length
        {
            get { return length; }
            set
            {
                if (value == length) return;

                length = value;
                dirty = true;
            }
        }

        public Brush Brush
        {
            get { return brush; }
            set
            {
                if (value == brush) return;

                brush = value;
                dirty = true;
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
                dirty = true;
            }
        }


        public ShapeTypeEnum ShapeType { get { return shapeType; } }

        public enum ShapeTypeEnum { RECTANGLE, CIRCLE };

        private ShapeTypeEnum shapeType;
        public bool IsDirty { get { return dirty; } set { dirty = value; } }

        private bool dirty;

        private Brush brush;

        private int width;
        private int length;

        private Point topLeft;

        public Shape(ShapeTypeEnum shapeType, Brush brush, Point topLeft, int width, int length)
        {
            this.width = width;
            this.length = length;
            this.shapeType = shapeType;
            this.brush = brush;
            this.topLeft = topLeft;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(brush, topLeft.X, topLeft.Y, width, length);
        }

        public bool WasClicked(Point p)
        {
            return p.X >= topLeft.X && p.X < topLeft.X + width
                && p.Y >= topLeft.Y && p.Y < topLeft.Y + length;
        }
    }
}
