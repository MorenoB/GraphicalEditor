using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;
using System.Drawing;

namespace GraphicalEditor.Visitor
{
    class ShapeElementResizeVisitor : IShapeElementVisitor
    {
        private Rectangle newResizeSize;

        public ShapeElementResizeVisitor(Rectangle newResizeSize)
        {
            this.newResizeSize = newResizeSize;
        }

        public void Visit(ShapeObject shapeObj)
        {
            shapeObj.Bounds = newResizeSize;
        }
    }
}
