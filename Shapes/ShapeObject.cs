using GraphicalEditor.Composite;
using GraphicalEditor.Interfaces;
using GraphicalEditor.IO;
using GraphicalEditor.Util;
using System.Collections.Generic;
using System.Drawing;
using static GraphicalEditor.DrawHandler;
using System;

namespace GraphicalEditor.Shapes
{
    public abstract class ShapeObject : IShapeComponent
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

        private Rectangle bounds;
        public virtual Rectangle Bounds
        {
            get
            {
                return bounds;
            }
            set
            {
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

        public virtual bool HasChildren
        {
            get
            {
                return false;
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
            if (IsSelected)
            {
                GrabHandles.Draw(g, true);
            }
        }

        public bool WasClicked(Point p)
        {
            return p.X >= Bounds.Location.X && p.X < Bounds.Location.X + Bounds.Size.Width
                && p.Y >= Bounds.Location.Y && p.Y < Bounds.Location.Y + Bounds.Size.Height;
        }

        public HitStatus GetHitStatus(Point p)
        {
            return GrabHandles.GetHitTest(p);
        }

        public void UpdateSelectionBounds()
        {
            GrabHandles.SetBounds(Bounds);
        }

        public virtual List<string> GetNameListByDepth(int depth)
        {
            List<string> nameList = new List<string>();

            string name = new string(' ', depth);
            name += Parser.ParseShapeToText(this);

            nameList.Add(name);

            return nameList;
        }

        public void Accept(IShapeElementVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
