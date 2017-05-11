using GraphicalEditor.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using GraphicalEditor.Shapes;
using static GraphicalEditor.DrawHandler;
using GraphicalEditor.Util;
using System;

namespace GraphicalEditor.Composite
{
    public class ShapeComposite : ShapeObject
    {
        private List<IShapeComponent> shapes = new List<IShapeComponent>();

        private Rectangle bounds;
        public override Rectangle Bounds {
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

        public override bool HasChildren
        {
            get
            {
                return shapes.Count > 0;
            }
        }

        public override void Draw(Graphics g)
        {
            foreach(IShapeComponent shape in shapes)
            {
                shape.Draw(g);
            }

            base.Draw(g);
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

        public override List<string> GetNameListByDepth(int depth)
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
