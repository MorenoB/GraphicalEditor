using GraphicalEditor.Shapes;
using System.Drawing;

namespace GraphicalEditor.Decorator
{
    class Decorator : ShapeObject
    {
        protected ShapeObject shape;
        protected string text;

        protected const int C_HEIGHT_OFFSET = 1;
        protected const int C_WIDTH_OFFSET = 1;

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
