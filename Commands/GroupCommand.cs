using GraphicalEditor.Interfaces;
using System.Collections.Generic;

namespace GraphicalEditor.Shapes
{
    class GroupCommand : ICommand
    {
        private List<ShapeObject> shapeCollection = new List<ShapeObject>();
        private ShapeObject parentShape;
        public GroupCommand(List<ShapeObject> shapeCollection)
        {
            this.shapeCollection = shapeCollection;

            if (shapeCollection.Count > 0)
            {
                parentShape = shapeCollection[0];
                shapeCollection.Remove(parentShape);
            }
        }

        public void Execute()
        {
            if (shapeCollection.Count < 1)
                return;

            foreach(ShapeObject shape in shapeCollection)
            {
                parentShape.AddChild(shape);
            }
        }

        public void Undo()
        {
            if (shapeCollection.Count < 1)
                return;

            foreach (ShapeObject shape in shapeCollection)
            {
                parentShape.RemoveChild(shape);
            }
        }
    }
}
