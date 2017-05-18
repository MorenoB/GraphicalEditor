using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;
using System.Collections.Generic;

namespace GraphicalEditor.IO
{
    class SaveLoadController
    {
        public void SaveShapes(List<ShapeObject> shapesList, string filePath)
        {
            string[] linesToWrite = Parser.ParseShapeList(shapesList);

            Filehandler.SaveToFile(linesToWrite, filePath);
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
