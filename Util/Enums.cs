namespace GraphicalEditor.Util
{
    public class Enums
    {

        public enum HitStatus
        {
            None,
            Drag,
            ResizeTopLeft,
            ResizeTopRight,
            ResizeBottomLeft,
            ResizeBottomRight,
            ResizeLeft,
            ResizeTop,
            ResizeRight,
            ResizeBottom
        }

        public enum ToolItem
        {
            Rectangle, Ellipse, Line, Brush, Pencil, ColorPicker, Selecter, None
        }
    }
}
