using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;

namespace GraphicalEditor.Commands
{
    class CreateShapeCommand : ICommand
    {
        ShapeObject shapeToCreate;


        public CreateShapeCommand(ShapeObject shapeToCreate)
        {
            this.shapeToCreate = shapeToCreate;
        }

        public void Execute()
        {
            DrawHandler.Instance.AddNewShape(shapeToCreate);
        }

        public void Undo()
        {
            DrawHandler.Instance.DeleteShape(shapeToCreate);
        }
    }
}
