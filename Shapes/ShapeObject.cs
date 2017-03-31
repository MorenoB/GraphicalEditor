using GraphicalEditor.Util;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalEditor.Shapes
{
    public abstract class ShapeObject
    {
        public virtual Size Size
        {
            get { return Bounds.Size; }
            set
            {
                if (Bounds.Size == value) return;
                Rectangle rect = Bounds;

                value.Width.Clamp(MinimumSize.Width, int.MaxValue);
                value.Height.Clamp(MinimumSize.Height, int.MaxValue);

                rect.Size = value;

                Bounds = rect;
            }
        }

        private Size minimumSize;
        public virtual Size MinimumSize
        {
            get { return minimumSize; }
            set
            {
                value.Width.Clamp(0, int.MaxValue);
                value.Height.Clamp(0, int.MaxValue);

                minimumSize = value;
            }
        }

        public virtual Point Location
        {
            get
            {
                return Bounds.Location; ;
            }
            set
            {
                if (Bounds.Location == value) return;
                Rectangle rect = Bounds;
                rect.Location = value;
                Bounds = rect;
            }
        }

        private bool isSelected;
        public virtual bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
            }
        }

        private GrabHandles grabHandles;
        public virtual GrabHandles GrabHandles
        {
            get
            {
                if (grabHandles == null) grabHandles = new GrabHandles(this);
                return grabHandles;
            }
        }

        private Rectangle bounds;
        public virtual Rectangle Bounds
        {
            get { return bounds; }
            set
            {
                SetChildBounds(value);

                bounds = value;
                SetSelectionBounds(value);
            }
        }

        private int id;
        public virtual int ID
        {
            get
            {
                return id;
            }

            set
            {
                if (value == id)
                    return;

                id = value;
            }
        }

        private Color color;
        public virtual Color Color
        {
            get
            {
                return color;
            }
            protected set
            {
                if (color == value)
                    return;

                color = value;
            }
        }

        public bool HasChildren
        {
            get
            {
                return childShapes.Count > 0;
            }
        }

        private ShapeObject parentShape;
        public ShapeObject ParentShape
        {
            get
            {
                return parentShape;
            }
            private set
            {
                if (value == parentShape)
                    return;

                parentShape = value;
            }
        }

        private readonly List<ShapeObject> childShapes = new List<ShapeObject>();

        public bool WasClicked(Point p)
        {
            return p.X >= Location.X && p.X < Location.X + Size.Width
                && p.Y >= Location.Y && p.Y < Location.Y + Size.Height;
        }

        public DrawHandler.HitStatus GetHitStatus(Point p)
        {
            return GrabHandles.GetHitTest(p);
        }

        public void AddChild(ShapeObject child)
        {
            if (childShapes.Contains(child))
                return;

            childShapes.Add(child);
            child.ParentShape = this;
        }

        public void RemoveChild(ShapeObject child)
        {
            childShapes.Remove(child);
            child.ParentShape = null;
        }

        public virtual void Draw(Graphics g)
        {
            foreach (ShapeObject childGraphic in childShapes)
            {
                childGraphic.Draw(g);
            }
        }

        private void SetSelectionBounds(Rectangle newBounds)
        {
            if (!HasChildren)
            {
                GrabHandles.SetBounds(newBounds);
                return;
            }

            Rectangle combinedBounds = newBounds;
            foreach( ShapeObject child in childShapes)
            {
                combinedBounds = Rectangle.Union(combinedBounds, child.bounds);
            }

            GrabHandles.SetBounds(combinedBounds);
        }

        private void SetChildBounds(Rectangle newBounds)
        {
            Rectangle oldParentBounds = Bounds;
            int deltaWidth = newBounds.Width - oldParentBounds.Width;
            int deltaHeight = newBounds.Height - oldParentBounds.Height;
            int deltaX = newBounds.X - oldParentBounds.X;
            int deltaY = newBounds.Y - oldParentBounds.Y;


            foreach ( ShapeObject child in childShapes)
            {
                int newWidth = child.Bounds.Width + deltaWidth;
                int newHeight = child.Bounds.Height + deltaHeight;
                int newX = child.Bounds.X + deltaX;
                int newY = child.Bounds.Y + deltaY;

                child.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
            }
        }
    }
}
