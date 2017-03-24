using GraphicalEditor.Interfaces;
using System.Collections.Generic;

namespace GraphicalEditor.Commands
{
    class LoadCommand : ICommand
    {
        List<IShape> oldShapelist = new List<IShape>();
        List<IShape> newShapelist = new List<IShape>();

        public LoadCommand(List<IShape> oldShapelist, List<IShape> newShapelist)
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
