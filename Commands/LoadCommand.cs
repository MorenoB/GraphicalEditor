using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;
using System.Collections.Generic;

namespace GraphicalEditor.Commands
{
    class LoadCommand : ICommand
    {
        List<IShapeComponent> oldShapelist = new List<IShapeComponent>();
        List<IShapeComponent> newShapelist = new List<IShapeComponent>();

        public LoadCommand(List<IShapeComponent> oldShapelist, List<IShapeComponent> newShapelist)
        {
            this.oldShapelist = oldShapelist;
            this.newShapelist = newShapelist;
        }

        public void Execute()
        {
            DrawHandler.Instance.InsertNewShapeList(newShapelist);
        }

        public void Undo()
        {
            DrawHandler.Instance.InsertNewShapeList(oldShapelist);
        }
    }
}
