using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using GraphicalEditor.Interfaces;
using static GraphicalEditor.DrawHandler;

namespace GraphicalEditor.Shapes
{
    public class GrabHandles
    {
        public const int BOX_SIZE = 3;

        public GrabHandles(IShape parentShape)
        {
            this.BorderWidth = 4;
            this.SetBounds(parentShape.Bounds);
        }

        public Rectangle BorderBounds { get; private set; }
        public int BorderWidth { get; set; }
        public bool Locked { get; set; }

        public Rectangle TotalBounds
        {
            get { return Rectangle.Union(this.TopLeft, this.BottomRight); }
        }

        internal Rectangle TopLeft
        {
            get
            {
                return new Rectangle(this.BorderBounds.X - BOX_SIZE,
                                     this.BorderBounds.Y - BOX_SIZE,
                                     2 * BOX_SIZE + 1, 2 * BOX_SIZE + 1);
            }
        }

        internal Rectangle TopRight
        {
            get
            {
                return new Rectangle(this.BorderBounds.Right - BOX_SIZE,
                                     this.BorderBounds.Y - BOX_SIZE,
                                     2 * BOX_SIZE + 1, 2 * BOX_SIZE + 1);
            }
        }

        internal Rectangle TopMiddle
        {
            get
            {
                return new Rectangle(this.BorderBounds.X + this.BorderBounds.Width / 2 - BOX_SIZE,
                                     this.BorderBounds.Y - BOX_SIZE,
                                     2 * BOX_SIZE + 1, 2 * BOX_SIZE + 1);
            }
        }

        internal Rectangle MiddleLeft
        {
            get
            {
                return new Rectangle(this.BorderBounds.X - BOX_SIZE,
                                     this.BorderBounds.Y + this.BorderBounds.Height / 2 - BOX_SIZE,
                                     2 * BOX_SIZE + 1, 2 * BOX_SIZE + 1);
            }
        }

        internal Rectangle MiddleRight
        {
            get
            {
                return new Rectangle(this.BorderBounds.Right - BOX_SIZE,
                                     this.BorderBounds.Y + this.BorderBounds.Height / 2 - BOX_SIZE,
                                     2 * BOX_SIZE + 1, 2 * BOX_SIZE + 1);
            }
        }

        internal Rectangle MiddleMiddle
        {
            get
            {
                return new Rectangle(this.BorderBounds.X + this.BorderBounds.Width / 2 - BOX_SIZE,
                                     this.BorderBounds.Y + this.BorderBounds.Height / 2 - BOX_SIZE,
                                     2 * BOX_SIZE + 1, 2 * BOX_SIZE + 1);
            }
        }

        internal Rectangle BottomLeft
        {
            get
            {
                return new Rectangle(this.BorderBounds.X - BOX_SIZE,
                                     this.BorderBounds.Bottom - BOX_SIZE,
                                     2 * BOX_SIZE + 1, 2 * BOX_SIZE + 1);
            }
        }

        internal Rectangle BottomRight
        {
            get
            {
                return new Rectangle(this.BorderBounds.Right - BOX_SIZE,
                                     this.BorderBounds.Bottom - BOX_SIZE,
                                     2 * BOX_SIZE + 1, 2 * BOX_SIZE + 1);
            }
        }

        internal Rectangle BottomMiddle
        {
            get
            {
                return new Rectangle(this.BorderBounds.X + this.BorderBounds.Width / 2 - BOX_SIZE,
                                     this.BorderBounds.Bottom - BOX_SIZE,
                                     2 * BOX_SIZE + 1, 2 * BOX_SIZE + 1);
            }
        }

        internal void SetBounds(Rectangle shapeBounds)
        {
            this.BorderBounds = new Rectangle(shapeBounds.X - this.BorderWidth,
                                              shapeBounds.Y - this.BorderWidth,
                                              shapeBounds.Width + 2 * this.BorderWidth,
                                              shapeBounds.Height + 2 * this.BorderWidth);
        }

        internal void Draw(Graphics g, bool firstSelection)
        {
            ControlPaint.DrawBorder(g, this.BorderBounds, ControlPaint.ContrastControlDark, ButtonBorderStyle.Dotted);

            if (this.Locked)
            {
                this.DrawLock(g);
            }
            else
            {
                this.DrawGrabHandle(g, this.TopLeft, firstSelection);
                this.DrawGrabHandle(g, this.TopMiddle, firstSelection);
                this.DrawGrabHandle(g, this.TopRight, firstSelection);
                this.DrawGrabHandle(g, this.MiddleLeft, firstSelection);
                this.DrawGrabHandle(g, this.MiddleRight, firstSelection);
                this.DrawGrabHandle(g, this.BottomLeft, firstSelection);
                this.DrawGrabHandle(g, this.BottomMiddle, firstSelection);
                this.DrawGrabHandle(g, this.BottomRight, firstSelection);
            }
        }

        private void DrawGrabHandle(Graphics g, Rectangle rect, bool firstSelection)
        {
            if (firstSelection)
            {
                var rect1 = rect;
                var rect2 = rect;
                var innerRect = rect;
                innerRect.Inflate(-1, -1);
                rect1.X += 1;
                rect1.Width -= 2;
                rect2.Y += 1;
                rect2.Height -= 2;

                g.FillRectangle(Brushes.Black, rect1);
                g.FillRectangle(Brushes.Black, rect2);
                g.FillRectangle(Brushes.White, innerRect);
            }
            else
            {
                g.FillRectangle(Brushes.Black, rect);
            }
        }

        private void DrawLock(Graphics g)
        {
            var rect = this.TopLeft;
            rect.X -= 1;
            rect.Width -= 1;
            rect.Height -= 2;

            var innerRect = rect;
            innerRect.Inflate(-1, -1);

            g.FillRectangle(Brushes.White, innerRect);
            g.DrawRectangle(Pens.Black, rect);

            var outerHandleRect1 = rect;
            outerHandleRect1.Y -= 2;
            outerHandleRect1.Height = 2;
            outerHandleRect1.Width = 5;
            outerHandleRect1.X += 1;

            var outerHandleRect2 = outerHandleRect1;
            outerHandleRect2.Y -= 1;
            outerHandleRect2.X += 1;
            outerHandleRect2.Width = 3;
            outerHandleRect2.Height = 1;

            var innerHandleRect = outerHandleRect1;
            innerHandleRect.X += 1;
            innerHandleRect.Width = 3;

            g.FillRectangle(Brushes.Black, outerHandleRect1);
            g.FillRectangle(Brushes.Black, outerHandleRect2);
            g.FillRectangle(Brushes.White, innerHandleRect);
        }

        public HitStatus GetHitTest(Point location)
        {
            if (TotalBounds.Contains(location))
            {
                // Diagonal resizing (has precedence over normal resizing)
                if (this.TopLeft.Contains(location))
                    return HitStatus.ResizeTopLeft;
                else if (TopRight.Contains(location))
                    return HitStatus.ResizeTopRight;
                else if (BottomLeft.Contains(location))
                    return HitStatus.ResizeBottomLeft;
                else if (BottomRight.Contains(location))
                    return HitStatus.ResizeBottomRight;

                // Horizontal/Vertical resizing (has precedence over dragging)
                if (Rectangle.Union(TopLeft, TopRight).Contains(location))
                    return HitStatus.ResizeTop;
                else if (Rectangle.Union(TopRight, BottomRight).Contains(location))
                    return HitStatus.ResizeRight;
                else if (Rectangle.Union(BottomRight, BottomLeft).Contains(location))
                    return HitStatus.ResizeBottom;
                else if (Rectangle.Union(BottomLeft, TopLeft).Contains(location))
                    return HitStatus.ResizeLeft;

                // If all else fails: drag
                return HitStatus.Drag;
            }
            else
            {
                return HitStatus.None;
            }
        }
    }
}
