using GraphicalEditor.Interfaces;
using System.Drawing;

namespace GraphicalEditor.Commands
{
    class ResizeShapeCommand : Command
    {
        private IShape shape;
        private Rectangle newBounds;
        private Rectangle previousBounds;

        public ResizeShapeCommand(IShape shape, Rectangle previousBounds, Rectangle newBounds)
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
