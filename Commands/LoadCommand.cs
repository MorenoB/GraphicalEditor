using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;
using System.Collections.Generic;

namespace GraphicalEditor.Commands
{
    class LoadCommand : ICommand
    {
        List<ShapeObject> oldShapelist = new List<ShapeObject>();
        List<ShapeObject> newShapelist = new List<ShapeObject>();

        public LoadCommand(List<ShapeObject> oldShapelist, List<ShapeObject> newShapelist)
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
