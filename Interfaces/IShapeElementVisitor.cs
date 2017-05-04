using GraphicalEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalEditor.Interfaces
{
    interface IShapeElementVisitor
    {
        void Visit(RectangleShape rectangleShape);

        void Visit(EllipseShape ellipseShape);
    }
}
