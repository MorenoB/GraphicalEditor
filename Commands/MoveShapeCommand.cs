using GraphicalEditor.Interfaces;
using GraphicalEditor.Visitor;
using System.Drawing;

namespace GraphicalEditor.Commands
{
    class MoveShapeCommand : ICommand
    {
        private IShapeComponent shape;
        private Point previousLocation;
        private Point newLocation;

        public MoveShapeCommand(IShapeComponent shape, Point previousLocation, Point newLocation)
        {
            this.shape = shape;
            this.previousLocation = previousLocation;
            this.newLocation = newLocation;
        }
        public void Execute()
        {
            ShapeElementMoveVisitor moveVisitor = new ShapeElementMoveVisitor(newLocation);
            shape.Accept(moveVisitor);
        }

        public void Undo()
        {
            ShapeElementMoveVisitor moveVisitor = new ShapeElementMoveVisitor(previousLocation);
            shape.Accept(moveVisitor);
        }
    }
}
