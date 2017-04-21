using GraphicalEditor.Interfaces;
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
            shape.Location = newLocation;
        }

        public void Undo()
        {
            shape.Location = previousLocation;
        }
    }
}
