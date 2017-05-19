using GraphicalEditor.Shapes;
using System.Drawing;

namespace GraphicalEditor.Decorator
{
    public class Decorator : ShapeObject
    {
        protected ShapeObject shape;
        protected string text;

        protected const int C_HEIGHT_OFFSET = 5;
        protected const int C_WIDTH_OFFSET = 5;

        #region Properties
        protected int ShapeLeft
        {
            get
            {
                return shape.Bounds.Left;
            }
        }

        protected int ShapeRight
        {
            get
            {
                return shape.Bounds.Right;
            }
        }

        protected int ShapeTop
        {
            get
            {
                return shape.Bounds.Top;
            }
        }

        protected int ShapeBottom
        {
            get
            {
                return shape.Bounds.Bottom;
            }
        }

        protected int ShapeLocationX
        {
            get
            {
                return shape.Location.X;
            }
        }

        protected int ShapeLocationY
        {
            get
            {
                return shape.Location.Y;
            }
        }

        public override Size Size
        {
            get { return shape.Size; }
            set
            {
                shape.Size = value;
            }
        }

        public override Rectangle Bounds
        {
            get
            {
                return shape.Bounds;
            }
            set
            {
                shape.Bounds = value;
            }
        }

        public new GrabHandles GrabHandles
        {
            get
            {
                return shape.GrabHandles;
            }
        }

        public override Point Location
        {
            get
            {
                return shape.Location;
            }
            set
            {
                shape.Location = value;
            }
        }

        public override Size MinimumSize
        {
            get { return shape.MinimumSize; }
            set
            {
                shape.MinimumSize = value;
            }
        }

        public override bool IsSelected
        {
            get
            {
                return shape.IsSelected;
            }
            set
            {
                shape.IsSelected = value;
            }
        }

        public override Color Color
        {
            get
            {
                return shape.Color;
            }
            set
            {
                shape.Color = value;
            }
        }

        public override bool HasChildren
        {
            get
            {
                return shape.HasChildren;
            }
        }

        public new bool IsRoot
        {
            get
            {
                return shape.IsRoot;
            }
        }

        public new ShapeObject Parent
        {
            get
            {
                return shape.Parent;
            }

            set
            {
                shape.Parent = value;
            }
        }

        #endregion

        public Decorator(string text)
        {
            this.text = text;
        }

        public void SetShape( ShapeObject shape)
        {
            this.shape = shape;
        }

        public override void Draw(Graphics g)
        {
            if (shape != null)
                shape.Draw(g);
        }
    }
}
