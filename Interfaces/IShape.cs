using System.Drawing;

namespace GraphicalEditor.Interfaces
{
    public interface IShape
    {
        string ToString();

        void Draw(Graphics g, Brush brush, Point Location, Size Size);
    }
}
