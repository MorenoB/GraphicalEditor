using System;
namespace GraphicalEditor.IO
{
    public class BaseNode
    {
        public string Name { get; set; }
        public int Depth { get; set; }
        public BaseNode Parent { get; set; }

        public BaseNode(string elementName, int depth)
        {
            this.Name = elementName;
            this.Depth = depth;
        }

    }
}
