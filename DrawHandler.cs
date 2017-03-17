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

        public void ResizeSelectedShape(Point currentMousePosition)
        {
            if (SelectedShape == null)
                return;

            Resize(CurrentHitStatus, currentMousePosition.X, currentMousePosition.Y);
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

        #region Resizing

        private void Resize(HitStatus hitStatus, int x, int y)
        {

            if (hitStatus == HitStatus.None || hitStatus == HitStatus.Drag)
                return;

            switch (hitStatus)
            {
                case HitStatus.ResizeBottomLeft:
                    this.ResizeBottomLeft(x, y);
                    break;

                case HitStatus.ResizeBottomRight:
                    this.ResizeBottomRight(x, y);
                    break;

                case HitStatus.ResizeTopLeft:
                    this.ResizeTopLeft(x, y);
                    break;

                case HitStatus.ResizeTopRight:
                    this.ResizeTopRight(x, y);
                    break;

                case HitStatus.ResizeLeft:
                    this.ResizeLeft(x, y);
                    break;

                case HitStatus.ResizeRight:
                    this.ResizeRight(x, y);
                    break;

                case HitStatus.ResizeTop:
                    this.ResizeTop(x, y);
                    break;

                case HitStatus.ResizeBottom:
                    this.ResizeBottom(x, y);
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
                IShape shape = shapeList[i];

                if (shape == null) continue;

                shape.Draw(g);
            }
        }
    }
}
