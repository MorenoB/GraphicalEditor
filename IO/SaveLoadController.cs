using GraphicalEditor.Shapes;
using System.Collections.Generic;

namespace GraphicalEditor.IO
{
    class SaveLoadController
    {

        public SaveLoadController()
        {

        }

        public void SaveShapes(List<ShapeObject> shapesList, string filePath)
        {
            string fileContents = Parser.ParseShapeList(shapesList);

            Filehandler.SaveToFile(fileContents, filePath);
        }

        public List<ShapeObject> LoadShapes(string filePath)
        {
            string fileContents = Filehandler.ProcessFile(filePath);
            List<ShapeObject> shapeList = new List<ShapeObject>();

            shapeList = Parser.ParseFileContents(fileContents);

            return shapeList;
        }
    }
}
