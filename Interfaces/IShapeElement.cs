using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalEditor.Interfaces
{
    interface IShapeElement
    {
        void Accept(IShapeElementVisitor shapeElementVisitor);
    }
}
