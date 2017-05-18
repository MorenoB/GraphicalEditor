using GraphicalEditor.Interfaces;
using System.Drawing;

namespace GraphicalEditor.Shapes
{
    public class RectangleShape : IShape
    {
        public void Draw(Graphics g, Brush brush, Point Location, Size Size)
        {
            g.FillRectangle(brush, Location.X, Location.Y, Size.Width, Size.Height);
        }

        public override string ToString()
        {
            return "rectangle";
        }
    }
}
