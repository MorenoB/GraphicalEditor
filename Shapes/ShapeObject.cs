using GraphicalEditor.Interfaces;
using GraphicalEditor.IO;
using GraphicalEditor.Util;
using System.Collections.Generic;
using System.Drawing;
using static GraphicalEditor.Util.Enums;

namespace GraphicalEditor.Shapes
{
    public class ShapeObject
    {

        #region Properties
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
            set
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

        private ShapeObject parent;
        public ShapeObject Parent
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

        #endregion

        public IShape ShapeType = null;
        public ShapeObject()
        {

        }

        public ShapeObject(IShape shapeType, int width, int height, Point location, Color color)
        {
            Size = new Size(width, height);
            Location = location;
            Color = color;

            MinimumSize = new Size(Constants.SHAPE_MINIMUM_WIDTH, Constants.SHAPE_MINIMUM_HEIGHT);
            this.ShapeType = shapeType;
        }

        public virtual void Draw(Graphics g)
        {
            //Draw the selection box if selected
            if (IsSelected)
            {
                GrabHandles.Draw(g, true);
            }

            if (ShapeType == null)
                return;

            ShapeType.Draw(g, new SolidBrush(Color), Location, Size);
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

        public override string ToString()
        {
            if (ShapeType == null)
                return "SOMETHING WENT HORRIBLY WRONG";
            else
                return ShapeType.ToString();
        }

        public virtual List<string> GetNameListByDepth(int depth)
        {
            List<string> nameList = new List<string>();

            string name = new string(' ', depth);
            name += Parser.ParseShapeToText(this);

            nameList.Add(name);

            return nameList;
        }

        public void AddDecorator(Decorator.Decorator decorator)
        {
            if (decorator == null)
                return;

            decorator.SetShape(this);
        }

        public void Accept(IShapeElementVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
