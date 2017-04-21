using GraphicalEditor.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using GraphicalEditor.Shapes;
using static GraphicalEditor.DrawHandler;
using GraphicalEditor.Util;
using System;

namespace GraphicalEditor.Composite
{
    public class ShapeComposite : IShapeComponent
    {
        private List<IShapeComponent> shapes = new List<IShapeComponent>();

        private Rectangle bounds;
        public Rectangle Bounds {
            get
            {
                return GetChildBounds();
            }
            set
            {
                SetChildBounds(value);

                bounds = value;

                UpdateSelectionBounds();
            }
        }

        private GrabHandles grabHandles;
        public GrabHandles GrabHandles
        {
            get
            {
                if (grabHandles == null) grabHandles = new GrabHandles(this);
                return grabHandles;
            }
        }

        public virtual Point Location
        {
            get
            {
                return Bounds.Location;
            }
            set
            {
                if (Bounds.Location == value) return;
                Rectangle rect = Bounds;
                rect.Location = value;
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

                UpdateSelectionBounds();
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
                return shapes.Count > 0;
            }
        }

        public bool IsRoot
        {
            get
            {
                return Parent == null;
            }
        }

        private IShapeComponent parent;
        public IShapeComponent Parent
        {
            get
            {
                return parent;
            }

            set
            {
                if (parent != value)
                    parent = value;
            }
        }

        public virtual void Draw(Graphics g)
        {
            foreach(IShapeComponent shape in shapes)
            {
                shape.Draw(g);
            }

            if (IsSelected)
            {
                GrabHandles.Draw(g, true);
            }
        }

        public void Add(IShapeComponent shape)
        {
            shapes.Add(shape);
            shape.Parent = this;
        }

        public void Delete(IShapeComponent shape)
        {
            shapes.Remove(shape);

            shape.Parent = null;
        }

        public bool WasClicked(Point p)
        {
            return p.X >= Bounds.Location.X && p.X < Bounds.Location.X + Bounds.Size.Width
                && p.Y >= Bounds.Location.Y && p.Y < Bounds.Location.Y + Bounds.Size.Height;
        }

        private void SetChildBounds(Rectangle newBounds)
        {
            Rectangle oldParentBounds = Bounds;
            int deltaWidth = newBounds.Width - oldParentBounds.Width;
            int deltaHeight = newBounds.Height - oldParentBounds.Height;
            int deltaX = newBounds.X - oldParentBounds.X;
            int deltaY = newBounds.Y - oldParentBounds.Y;


            foreach (IShapeComponent child in shapes)
            {
                int newWidth = child.Bounds.Width + deltaWidth;
                int newHeight = child.Bounds.Height + deltaHeight;
                int newX = child.Bounds.X + deltaX;
                int newY = child.Bounds.Y + deltaY;

                child.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
            }
        }

        private Rectangle GetChildBounds()
        {
            Rectangle combinedBounds = shapes.Count < 1 ? bounds : shapes.Find(o => o != null).Bounds;

            foreach(IShapeComponent shape in shapes)
            {
                combinedBounds = Rectangle.Union(combinedBounds, shape.Bounds);
            }

            return combinedBounds;
        }

        public HitStatus GetHitStatus(Point p)
        {
            return GrabHandles.GetHitTest(p);
        }

        public void UpdateSelectionBounds()
        {
            Rectangle combinedBounds = Bounds;

            GrabHandles.SetBounds(combinedBounds);
        }

        public virtual List<string> GetNameListByDepth(int depth)
        {
            List<string> nameList = new List<string>();
            string name = new string(' ', depth) + "group " + shapes.Count;

            nameList.Add(name);

            foreach(IShapeComponent shape in shapes)
            {
                nameList.AddRange(shape.GetNameListByDepth(depth + 1));
            }

            return nameList;
        }
    }
}
