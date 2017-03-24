using GraphicalEditor.Interfaces;
using System.Drawing;
using System;

namespace GraphicalEditor.Shapes
{
    public class EllipseShape : IShape
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

        public int ID
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
        public Color Color
        {
            get
            {
                return color;
            }
        }

        private bool isSelected;
        private int id;

        private GrabHandles grabHandles;
        private Rectangle bounds;
        private Size minimumSize;

        public EllipseShape(Color color, Point location, int width, int height)
        {
            this.Size = new Size(width, height);
            this.color = color;
            this.Location = location;
            this.MinimumSize = new Size(Constants.SHAPE_MINIMUM_WIDTH, Constants.SHAPE_MINIMUM_HEIGHT);
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, Location.X, Location.Y, Size.Width, Size.Height);

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
