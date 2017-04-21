using GraphicalEditor.Interfaces;
using GraphicalEditor.Shapes;
using System.Collections.Generic;

namespace GraphicalEditor.IO
{
    class SaveLoadController
    {
        public void SaveShapes(List<IShapeComponent> shapesList, string filePath)
        {
            string[] linesToWrite = Parser.ParseShapeList(shapesList);

            Filehandler.SaveToFile(linesToWrite, filePath);
        }

        public List<IShapeComponent> LoadShapes(string filePath)
        {
            string fileContents = Filehandler.ProcessFile(filePath);
            List<IShapeComponent> shapeList = new List<IShapeComponent>();

            shapeList = Parser.ParseFileContents(fileContents);

            return shapeList;
        }
    }
}
