using GraphicalEditor.Shapes;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalEditor
{
    public sealed class DrawHandler
    {
        private List<Shape> shapeList = new List<Shape>();

        private static readonly DrawHandler instance = new DrawHandler();

        private Shape selectedShape;
        public Shape SelectedShape
        {
            get
            {
                return selectedShape;
            }
            set
            {
                if (selectedShape == value)
                    return;

                selectedShape = value;
            }
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DrawHandler()
        {
            
        }

        private DrawHandler()
        {
        }

        public static DrawHandler Instance
        {
            get
            {
                return instance;
            }
        }

        public void ResizeSelectedShape(int newWidth, int newHeight)
        {
            if (SelectedShape == null)
                return;

            SelectedShape.Width = newWidth;
            SelectedShape.Length = newHeight;
        }

        public void MoveSelectedShape(Point newPoint)
        {
            if (SelectedShape == null)
                return;

            SelectedShape.TopLeftPoint = newPoint;
        }

        public void AddNewShape(Shape newShape)
        {
            shapeList.Add(newShape);
        }

        public void RedrawAllDirtyShapes(Graphics g)
        {

            g.Clear(Color.White);
            for (int i = 0; i < shapeList.Count; i++)
            {
                Shape shape = shapeList[i];

                if (shape == null) continue;

                //if (!shape.IsDirty) continue;

                shape.Draw(g);
            }
        }
    }
}
