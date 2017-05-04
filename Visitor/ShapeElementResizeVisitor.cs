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

        public void Visit(EllipseShape ellipseShape)
        {
            ellipseShape.Bounds = newResizeSize;
        }
      
        public void Visit(RectangleShape rectangleShape)
        {
            rectangleShape.Bounds = newResizeSize;
        }
    }
}
