using GraphicalEditor.Composite;
using GraphicalEditor.Util;
using System.Drawing;

namespace GraphicalEditor.Shapes
{
    public abstract class ShapeObject : ShapeComposite
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
    }
}
