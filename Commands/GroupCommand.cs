using GraphicalEditor.Composite;
using GraphicalEditor.Interfaces;
using System.Collections.Generic;

namespace GraphicalEditor.Shapes
{
    class GroupCommand : ICommand
    {
        private List<IShapeComponent> shapeCollection = new List<IShapeComponent>();
        private ShapeComposite parentShape;
        public GroupCommand(List<IShapeComponent> shapeCollection)
        {
            this.shapeCollection = shapeCollection;

            parentShape = new ShapeComposite();
        }

        public void Execute()
        {
            if (shapeCollection.Count < 1)
                return;

            foreach(IShapeComponent shape in shapeCollection)
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

            foreach (IShapeComponent shape in shapeCollection)
            {
                parentShape.Delete(shape);
            }

            DrawHandler.Instance.ClearSelection();
            
            DrawHandler.Instance.DeleteShape(parentShape);
        }
    }
}
