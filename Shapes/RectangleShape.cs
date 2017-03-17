using GraphicalEditor.Interfaces;
using System;
using System.Drawing;

namespace GraphicalEditor.Shapes
{
    public class RectangleShape : IShape
    {
        public Size Size
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

        public Size MinimumSize
        {
            get { return minimumSize; }
            set
            {
                if (value.Width < 0 || value.Height < 0)
                    throw new ArgumentOutOfRangeException("MinimumSize Width or Height must be at least zero.");
                minimumSize = value;
            }
        }

        public Brush Brush
        {
            get { return brush; }
            set
            {
                if (value == brush) return;

                brush = value;
            }
        }

        public Point Location
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

        public bool IsSelected
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

        public GrabHandles GrabHandles
        {
            get
            {
                if (grabHandles == null) grabHandles = new GrabHandles(this);
                return grabHandles;
            }
        }

        public Rectangle Bounds
        {
            get { return bounds; }
            set
            {
                bounds = value;
                this.GrabHandles.SetBounds(value);
            }
        }

        private bool isSelected;

        private GrabHandles grabHandles;
        private Rectangle bounds;
        private Brush brush;
        private Size minimumSize;

        public RectangleShape(Brush brush, Point location, int width, int height)
        {
            this.Size = new Size(width, height);
            this.brush = brush;
            this.Location = location;
            this.MinimumSize = new Size(10, 10);
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(brush, Location.X, Location.Y, Size.Width, Size.Height);

            if (IsSelected)
            {
                GrabHandles.Draw(g, true);
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
    }
}
