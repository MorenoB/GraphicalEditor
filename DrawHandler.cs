using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;
using GraphicalEditor.Util;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalEditor
{
    public sealed class DrawHandler
    {
        private List<IShapeComponent> shapeList = new List<IShapeComponent>();
        public List<IShapeComponent> ShapeList
        {
            get
            {
                return shapeList;
            }
        }

        public enum HitStatus
        {
            None,
            Drag,
            ResizeTopLeft,
            ResizeTopRight,
            ResizeBottomLeft,
            ResizeBottomRight,
            ResizeLeft,
            ResizeTop,
            ResizeRight,
            ResizeBottom
        }

        private static readonly DrawHandler instance = new DrawHandler();

        private List<IShapeComponent> selectedShapes = new List<IShapeComponent>();
        public List<IShapeComponent> SelectedShapes
        {
            get
            {
                return selectedShapes;
            }
        }

        public IShapeComponent SelectedShape
        {
            get
            {
                if (selectedShapes.Count > 0)
                    return selectedShapes[0];
                else
                    return null;
            }
        }

        private HitStatus hitStatus = HitStatus.None;
        public HitStatus CurrentHitStatus
        {
            get
            {
                return hitStatus;
            }
            private set
            {
                if (value == hitStatus)
                    return;

                Logger.Log("Hitstatus changed to " + hitStatus);
                hitStatus = value;
            }
        }

        public bool HasSelectedAShape
        {
            get
            {
                return SelectedShape != null;
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

        public Rectangle ResizeSelectedShape(Point currentMousePosition)
        {
            if (SelectedShape == null)
                return new Rectangle();

            Resize(CurrentHitStatus, currentMousePosition.X, currentMousePosition.Y);

            return SelectedShape.Bounds;
        }

        public void UpdateHitstatusByCurrentPoint(Point currentPoint)
        {
            CurrentHitStatus = SelectedShape != null ? SelectedShape.GetHitStatus(currentPoint) : HitStatus.None;
        }

        public void MoveSelectedShape(Point newPoint)
        {
            if (SelectedShape == null)
                return;

            SelectedShape.Location = newPoint;
        }

        public void InsertNewShapeList(List<ShapeObject> newShapeList)
        {
            if (HasSelectedAShape)
                ClearSelection();

            shapeList.Clear();

            foreach(ShapeObject shape in newShapeList)
            {
                shapeList.Add(shape);
            }
        }

        public void AddNewShape(IShapeComponent newShape)
        {
            ShapeList.Add(newShape);
            AddToSelection(newShape);
        }

        public void DeleteShape(IShapeComponent shapeToDelete)
        {
            ShapeList.Remove(shapeToDelete);
        }

        public void ClearSelection()
        {
            foreach(IShapeComponent shape in SelectedShapes)
            {
                shape.IsSelected = false;
            }

            SelectedShapes.Clear();
        }

        private void AddToSelection(IShapeComponent shape)
        {
            if (SelectedShapes.Contains(shape))
                return;

            shape.IsSelected = true;

            selectedShapes.Add(shape);
        }

        public IShapeComponent SelectShapeFromPoint(Point clickedPoint)
        {
            List<IShapeComponent> clickedShapes = ShapeList.FindAll(o => o.WasClicked(clickedPoint));
            IShapeComponent groupShape = clickedShapes.Find(o => o.HasChildren);

            if (groupShape != null)
            {
                AddToSelection(groupShape);
                return groupShape;
            }

            for (int i = 0; i < clickedShapes.Count; i++)
            {
                IShapeComponent shape = clickedShapes[i];
                if (shape == null) continue;

                if (selectedShapes.Contains(shape))
                        continue;

                AddToSelection(shape);
                return shape;
                
            }

            //We haven't detected a click on any shape.
            ClearSelection();

            return null;
        }

        #region Resizing

        private void Resize(HitStatus hitStatus, int x, int y)
        {

            if (hitStatus == HitStatus.None || hitStatus == HitStatus.Drag)
                return;

            switch (hitStatus)
            {
                case HitStatus.ResizeBottomLeft:
                    ResizeBottomLeft(x, y);
                    break;

                case HitStatus.ResizeBottomRight:
                    ResizeBottomRight(x, y);
                    break;

                case HitStatus.ResizeTopLeft:
                    ResizeTopLeft(x, y);
                    break;

                case HitStatus.ResizeTopRight:
                    ResizeTopRight(x, y);
                    break;

                case HitStatus.ResizeLeft:
                    ResizeLeft(x, y);
                    break;

                case HitStatus.ResizeRight:
                    ResizeRight(x, y);
                    break;

                case HitStatus.ResizeTop:
                    ResizeTop(x, y);
                    break;

                case HitStatus.ResizeBottom:
                    ResizeBottom(x, y);
                    break;
            }
        }

        private void ResizeBottomLeft(int x, int y)
        {
            Rectangle oldBounds = SelectedShape.Bounds;
            int newTop = oldBounds.Top;
            int newLeft = x;
            int newWidth = oldBounds.Right - x;
            int newHeight = y - oldBounds.Top;

            if (newWidth < SelectedShape.MinimumSize.Width)
            {
                newWidth = SelectedShape.MinimumSize.Width;
                newLeft = oldBounds.Right - newWidth;
            }
            if (newHeight < SelectedShape.MinimumSize.Height)
            {
                newHeight = SelectedShape.MinimumSize.Height;
            }
            SelectedShape.Bounds = new Rectangle(newLeft, newTop, newWidth, newHeight);
        }

        private void ResizeBottomRight(int x, int y)
        {
            Rectangle oldBounds = SelectedShape.Bounds;
            int newTop = oldBounds.Top;
            int newLeft = oldBounds.Left;
            int newWidth = x - newLeft;
            int newHeight = y - oldBounds.Top;

            if (newWidth < SelectedShape.MinimumSize.Width)
            {
                newWidth = SelectedShape.MinimumSize.Width;
            }
            if (newHeight < SelectedShape.MinimumSize.Height)
            {
                newHeight = SelectedShape.MinimumSize.Height;
            }
            SelectedShape.Bounds = new Rectangle(newLeft, newTop, newWidth, newHeight);
        }

        private void ResizeTopLeft(int x, int y)
        {
            Rectangle oldBounds = SelectedShape.Bounds;
            int newTop = y;
            int newLeft = x;
            int newWidth = oldBounds.Right - x;
            int newHeight = oldBounds.Bottom - y;

            if (newWidth < SelectedShape.MinimumSize.Width)
            {
                newWidth = SelectedShape.MinimumSize.Width;
                newLeft = oldBounds.Right - newWidth;
            }
            if (newHeight < SelectedShape.MinimumSize.Height)
            {
                newHeight = SelectedShape.MinimumSize.Height;
                newTop = oldBounds.Bottom - newHeight;
            }
            SelectedShape.Bounds = new Rectangle(newLeft, newTop, newWidth, newHeight);
        }

        private void ResizeTopRight(int x, int y)
        {
            Rectangle oldBounds = SelectedShape.Bounds;
            int newTop = y;
            int newLeft = oldBounds.Left;
            int newWidth = x - newLeft;
            int newHeight = oldBounds.Bottom - y;

            if (newWidth < SelectedShape.MinimumSize.Width)
            {
                newWidth = SelectedShape.MinimumSize.Width;
            }
            if (newHeight < SelectedShape.MinimumSize.Height)
            {
                newHeight = SelectedShape.MinimumSize.Height;
                newTop = oldBounds.Bottom - newHeight;
            }
            SelectedShape.Bounds = new Rectangle(newLeft, newTop, newWidth, newHeight);
        }

        private void ResizeTop(int x, int y)
        {
            Rectangle oldBounds = SelectedShape.Bounds;
            int newTop = y;
            int newLeft = oldBounds.Left;
            int newWidth = oldBounds.Width;
            int newHeight = oldBounds.Bottom - y;

            if (newHeight < SelectedShape.MinimumSize.Height)
            {
                newHeight = SelectedShape.MinimumSize.Height;
                newTop = oldBounds.Bottom - newHeight;
            }
            SelectedShape.Bounds = new Rectangle(newLeft, newTop, newWidth, newHeight);
        }

        private void ResizeLeft(int x, int y)
        {
            Rectangle oldBounds = SelectedShape.Bounds;
            int newTop = oldBounds.Top;
            int newLeft = x;
            int newWidth = oldBounds.Right - x;
            int newHeight = oldBounds.Height;

            if (newWidth < SelectedShape.MinimumSize.Width)
            {
                newWidth = SelectedShape.MinimumSize.Width;
                newLeft = oldBounds.Right - newWidth;
            }
            SelectedShape.Bounds = new Rectangle(newLeft, newTop, newWidth, newHeight);
        }

        private void ResizeRight(int x, int y)
        {
            Rectangle oldBounds = SelectedShape.Bounds;
            int newTop = oldBounds.Top;
            int newLeft = oldBounds.Left;
            int newWidth = x - newLeft;
            int newHeight = oldBounds.Height;

            if (newWidth < SelectedShape.MinimumSize.Width)
            {
                newWidth = SelectedShape.MinimumSize.Width;
            }
            SelectedShape.Bounds = new Rectangle(newLeft, newTop, newWidth, newHeight);
        }

        private void ResizeBottom(int x, int y)
        {
            Rectangle oldBounds = SelectedShape.Bounds;
            int newTop = oldBounds.Top;
            int newLeft = oldBounds.Left;
            int newWidth = oldBounds.Width;
            int newHeight = y - oldBounds.Top;

            if (newHeight < SelectedShape.MinimumSize.Height)
            {
                newHeight = SelectedShape.MinimumSize.Height;
            }
            SelectedShape.Bounds = new Rectangle(newLeft, newTop, newWidth, newHeight);
        }

#endregion

        public void RedrawShapes(Graphics g)
        {
            for (int i = 0; i < shapeList.Count; i++)
            {
                IShapeComponent shape = shapeList[i];

                if (shape == null) continue;

                shape.Draw(g);
            }
        }
    }
}
