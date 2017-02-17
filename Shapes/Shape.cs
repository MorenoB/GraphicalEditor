namespace GraphicalEditor.Shapes
{
    class Shape
    {
        public int Location_X { get { return location_x; } }
        public int Location_Y { get { return location_y; } }

        public int Width { get { return width; } }
        public int Length { get { return length; } }

        public bool IsDirty { get { return dirty; } set { dirty = value; } }

        private bool dirty;

        private int location_x;
        private int location_y;

        private int width;
        private int length;

        public Shape(int location_x, int location_y, int width, int length)
        {
            this.location_x = location_x;
            this.location_y = location_y;
            this.width = width;
            this.length = length;
        }
    }
}
