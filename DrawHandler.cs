using GraphicalEditor.Interfaces;
using GraphicalEditor.Util;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalEditor
{
    public sealed class DrawHandler
    {
        private List<IShape> shapeList = new List<IShape>();

        private static readonly DrawHandler instance = new DrawHandler();

        private IShape selectedShape;
        private IShape SelectedShape
        {
            get
            {
                return selectedShape;
            }
            set
            {
                if (selectedShape == value)
                    return;

                if (selectedShape != null)
                    selectedShape.IsSelected = false;
                
                selectedShape = value;

                if (selectedShape != null)
                    selectedShape.IsSelected = true;
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

        public void ResizeSelectedShape(int newWidth, int newHeight, Point currentMousePosition)
        {
            if (SelectedShape == null)
                return;

            if (newWidth < 0)
            {
                Point newTopleftPoint = new Point(currentMousePosition.X, SelectedShape.TopLeftPoint.Y);
                SelectedShape.TopLeftPoint = newTopleftPoint;
            }

            if (newHeight < 0)
            {
                Point newTopleftPoint = new Point(SelectedShape.TopLeftPoint.X, currentMousePosition.Y);
                SelectedShape.TopLeftPoint = newTopleftPoint;
            }

            SelectedShape.Width = Math.Abs(newWidth);
            SelectedShape.Height = Math.Abs(newHeight);
        }

        public void MoveSelectedShape(Point newPoint)
        {
            if (SelectedShape == null)
                return;

            SelectedShape.TopLeftPoint = newPoint;
        }

        public void AddNewShape(IShape newShape)
        {
            shapeList.Add(newShape);
            SelectedShape = newShape;
        }

        public void SelectShapeFromPoint(Point clickedPoint)
        {
            for (int i = 0; i < shapeList.Count; i++)
            {
                IShape shape = shapeList[i];
                if (shape == null) continue;

                if (shape.WasClicked(clickedPoint))
                {
                    SelectedShape = shape;
                    return;
                }
            }

            //We haven't detected a click on any shape.
            SelectedShape = null;
        }

        public void RedrawAllDirtyShapes(Graphics g)
        {
            for (int i = 0; i < shapeList.Count; i++)
            {
                IShape shape = shapeList[i];

                if (shape == null) continue;

                //if (!shape.IsDirty) continue;

                shape.Draw(g);
            }
        }
    }
}
