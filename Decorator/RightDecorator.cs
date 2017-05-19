using System.Drawing;

namespace GraphicalEditor.Decorator
{
    class RightDecorator : Decorator
    {
        public RightDecorator(string text) : base(text)
        {
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, ShapeRight + C_WIDTH_OFFSET, ShapeLocationY);
        }
    }
}
