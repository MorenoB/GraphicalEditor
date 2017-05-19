using System.Drawing;

namespace GraphicalEditor.Decorator
{
    class TopDecorator : Decorator
    {
        public TopDecorator(string text) : base(text)
        {
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, ShapeLocationX, ShapeTop + C_HEIGHT_OFFSET);
        }
    }
}
