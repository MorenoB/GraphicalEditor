using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;
using System.Drawing;

namespace GraphicalEditor.Visitor
{
    class ShapeElementMoveVisitor : IShapeElementVisitor
    {
        private Point newLocation;

        public ShapeElementMoveVisitor(Point newLocation)
        {
            this.newLocation = newLocation;
        }

        public void Visit(EllipseShape ellipseShape)
        {
            ellipseShape.Location = newLocation;
        }

        public void Visit(RectangleShape rectangleShape)
        {
            rectangleShape.Location = newLocation;
        }
    }
}
