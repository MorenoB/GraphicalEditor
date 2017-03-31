using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;
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
            shape.Bounds = newBounds;
        }

        public void Undo()
        {
            shape.Bounds = previousBounds;
        }
    }
}
