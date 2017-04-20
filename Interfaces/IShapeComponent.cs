using GraphicalEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GraphicalEditor.DrawHandler;

namespace GraphicalEditor.Interfaces
{
    public interface IShapeComponent
    {
        GrabHandles GrabHandles { get; }
        Point Location { set; }
        Size MinimumSize { get ;}
        Rectangle Bounds { get; set; }
        bool IsSelected { get; set; }
        bool HasChildren { get; }

        void Draw(Graphics g);
        HitStatus GetHitStatus(Point p);
        bool WasClicked(Point p);

    }
}
