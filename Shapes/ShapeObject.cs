using System;
using System.Drawing;

namespace GraphicalEditor.Shapes
{
    public abstract class ShapeObject
    {
        public virtual Size Size
        {
            get { return this.Bounds.Size; }
            set
            {
                if (this.Bounds.Size == value) return;
                Rectangle rect = this.Bounds;
                rect.Size = value;
                this.Bounds = rect;
            }
        }

        private Size minimumSize;
        public virtual Size MinimumSize
        {
            get { return minimumSize; }
            set
            {
                if (value.Width < 0 || value.Height < 0)
                    throw new ArgumentOutOfRangeException("MinimumSize Width or Height must be at least zero.");
                minimumSize = value;
            }
        }

        public virtual Point Location
        {
            get
            {
                return this.Bounds.Location; ;
            }
            set
            {
                if (this.Bounds.Location == value) return;
                Rectangle rect = this.Bounds;
                rect.Location = value;
                this.Bounds = rect;
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
                bounds = value;
                this.GrabHandles.SetBounds(value);
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

        public bool WasClicked(Point p)
        {
            return p.X >= Location.X && p.X < Location.X + Size.Width
                && p.Y >= Location.Y && p.Y < Location.Y + Size.Height;
        }

        public DrawHandler.HitStatus GetHitStatus(Point p)
        {
            return GrabHandles.GetHitTest(p);
        }

        public abstract void Draw(Graphics g);
    }
}
