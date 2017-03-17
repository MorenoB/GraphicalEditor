using GraphicalEditor.Shapes;
using System.Drawing;
using static GraphicalEditor.DrawHandler;

namespace GraphicalEditor.Interfaces
{
    public interface IShape
    {
        void Draw(Graphics g);
        bool WasClicked(Point p);
        HitStatus GetHitStatus(Point p);

        bool IsSelected { get; set; }
        Point Location { get; set; }
        Size Size { get; set; }
        Size MinimumSize { get; set; }
        Rectangle Bounds  { get; set; }
        GrabHandles GrabHandles { get; }
    }
}
