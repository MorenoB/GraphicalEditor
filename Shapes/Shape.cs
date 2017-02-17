namespace GraphicalEditor.Shapes
{
    class Shape
    {
        public int Location_X
        {
            get { return location_x; }
            set
            {
                if (location_x == value) return;

                location_x = value;
                dirty = true;
            }
        }
        public int Location_Y
        {
            get { return location_y; }
            set
            {
                if (value == location_y) return;

                location_y = value;
                dirty = true;
            }
        }

        public int Width
        {
            get { return width; }
            set
            {
                if (value == width) return;

                width = value;
                dirty = true;
            }
        }
        public int Length
        {
            get { return length; }
            set
            {
                if (value == length) return;

                length = value;
                dirty = true;
            }
        }
        public ShapeTypeEnum ShapeType { get { return shapeType; } }

        public enum ShapeTypeEnum { RECTANGLE, CIRCLE };

        private ShapeTypeEnum shapeType;
        public bool IsDirty { get { return dirty; } set { dirty = value; } }

        private bool dirty;

        private int location_x;
        private int location_y;

        private int width;
        private int length;

        public Shape(ShapeTypeEnum shapeType, int location_x, int location_y, int width, int length)
        {
            this.location_x = location_x;
            this.location_y = location_y;
            this.width = width;
            this.length = length;
            this.shapeType = shapeType;
            this.dirty = true;
        }
    }
}
