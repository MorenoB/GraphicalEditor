using GraphicalEditor.Composite;
using GraphicalEditor.Interfaces;
using System.Collections.Generic;

namespace GraphicalEditor.Shapes
{
    class GroupCommand : ICommand
    {
        private List<ShapeObject> shapeCollection = new List<ShapeObject>();
        private ShapeComposite parentShape;
        public GroupCommand(List<ShapeObject> shapeCollection)
        {
            this.shapeCollection = shapeCollection;

            parentShape = new ShapeComposite();
        }

        public void Execute()
        {
            if (shapeCollection.Count < 1)
                return;

            foreach(ShapeObject shape in shapeCollection)
            {
                parentShape.Add(shape);
            }

            DrawHandler.Instance.ClearSelection();

            parentShape.UpdateSelectionBounds();

            DrawHandler.Instance.AddNewShape(parentShape);
        }

        public void Undo()
        {
            if (shapeCollection.Count < 1)
                return;

            foreach (ShapeObject shape in shapeCollection)
            {
                parentShape.Delete(shape);
            }

            DrawHandler.Instance.ClearSelection();
            
            DrawHandler.Instance.DeleteShape(parentShape);
        }
    }
}
