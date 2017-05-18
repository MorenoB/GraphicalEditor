using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;
using GraphicalEditor.Visitor;
using System.Drawing;

namespace GraphicalEditor.Commands
{
    class ResizeShapeCommand : ICommand
    {
        private ShapeObject shape;
        private Rectangle newBounds;
        private Rectangle previousBounds;

        public ResizeShapeCommand(ShapeObject shape, Rectangle previousBounds, Rectangle newBounds)
        {
            this.shape = shape;
            this.previousBounds = previousBounds;
            this.newBounds = newBounds;
        }

        public void Execute()
        {
            ShapeElementResizeVisitor resizeVisitor = new ShapeElementResizeVisitor(newBounds);
            shape.Accept(resizeVisitor);
        }

        public void Undo()
        {
            ShapeElementResizeVisitor resizeVisitor = new ShapeElementResizeVisitor(previousBounds);
            shape.Accept(resizeVisitor);
        }
    }
}
