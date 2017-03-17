using GraphicalEditor.Interfaces;

namespace GraphicalEditor.Commands
{
    class CreateShapeCommand : Command
    {
        IShape shapeToCreate;


        public CreateShapeCommand(IShape shapeToCreate)
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
