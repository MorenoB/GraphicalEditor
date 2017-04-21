using GraphicalEditor.Composite;
using GraphicalEditor.IO;
using GraphicalEditor.Util;
using System.Collections.Generic;
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

        public override List<string> GetNameListByDepth(int depth)
        {
            List<string> nameList = new List<string>();

            string name = new string(' ', depth);
            name += Parser.ParseShapeToText(this);

            nameList.Add(name);

            return nameList;
        }
    }
}
