using GraphicalEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalEditor.Interfaces
{
    public interface IShapeElementVisitor
    {
        void Visit(ShapeObject shapeObj);
    }
}
