using System.Drawing;
namespace GraphicalEditor.Decorator
{
    class LeftDecorator : Decorator
    {
        public LeftDecorator(string text) : base(text)
        {
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, ShapeLeft - C_WIDTH_OFFSET, ShapeLocationY);
        }
    }
}
