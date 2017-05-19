using System.Drawing;

namespace GraphicalEditor.Decorator
{
    class BottomDecorator : Decorator
    {
        public BottomDecorator(string text) : base(text)
        {
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, ShapeLocationX, ShapeBottom - C_HEIGHT_OFFSET);
        }
    }
}
