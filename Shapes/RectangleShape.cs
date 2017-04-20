using System.Drawing;

namespace GraphicalEditor.Shapes
{
    public class RectangleShape : ShapeObject
    {
        public RectangleShape(Color color, Point location, int width, int height)
        {
            Size = new Size(width, height);
            Color = color;
            Location = location;
            MinimumSize = new Size(Constants.SHAPE_MINIMUM_WIDTH, Constants.SHAPE_MINIMUM_HEIGHT);
        }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillRectangle(brush, Location.X, Location.Y, Size.Width, Size.Height);

            if (IsSelected)
            {
                GrabHandles.Draw(g, true);
            }

            base.Draw(g);
        }
    }
}
