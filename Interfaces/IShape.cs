using System.Drawing;

namespace GraphicalEditor.Interfaces
{
    public interface IShape
    {
        void Draw(Graphics g);
        bool WasClicked(Point p);

        bool IsSelected { get; set; }
        Point TopLeftPoint { get; set; }
        int Height { get; set; }
        int Width { get; set; }
    }
}
