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

        public void Visit(ShapeObject shapeObj)
        {
            shapeObj.Location = newLocation;
        }
    }
}
