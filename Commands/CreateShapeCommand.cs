using GraphicalEditor.Interfaces;

namespace GraphicalEditor.Commands
{
    class CreateShapeCommand : ICommand
    {
        IShapeComponent shapeToCreate;


        public CreateShapeCommand(IShapeComponent shapeToCreate)
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
