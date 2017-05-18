using GraphicalEditor.Interfaces;
using System.Drawing;

namespace GraphicalEditor.Strategy
{
    class EllipseShape : IShape
    {
        public void Draw(Graphics g, Brush brush, Point Location, Size Size)
        {
            g.FillEllipse(brush, Location.X, Location.Y, Size.Width, Size.Height);
        }

        public override string ToString()
        {
            return "ellipse";
        }
    }
}
