using GraphicalEditor.Shapes;
using System.Collections.Generic;
using System.Drawing;
using static GraphicalEditor.DrawHandler;

namespace GraphicalEditor.Interfaces
{
    public interface IShapeComponent
    {
        GrabHandles GrabHandles { get; }
        Point Location { set; get; }
        Size MinimumSize { get ;}
        Rectangle Bounds { get; set; }
        Color Color { get; }
        IShapeComponent Parent { get; set; }

        bool IsSelected { get; set; }
        bool HasChildren { get; }
        bool IsRoot { get; }

        void Accept(IShapeElementVisitor visitor);
        void Draw(Graphics g);
        HitStatus GetHitStatus(Point p);
        bool WasClicked(Point p);
        List<string> GetNameListByDepth(int depth);
    }
}
