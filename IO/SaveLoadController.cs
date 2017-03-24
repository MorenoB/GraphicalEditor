using GraphicalEditor.Interfaces;
using System.Collections.Generic;

namespace GraphicalEditor.IO
{
    class SaveLoadController
    {

        public SaveLoadController()
        {

        }

        public void SaveShapes(List<IShape> shapesList, string filePath)
        {
            string fileContents = Parser.ParseShapeList(shapesList);

            Filehandler.SaveToFile(fileContents, filePath);
        }

        public List<IShape> LoadShapes(string filePath)
        {
            string fileContents = Filehandler.ProcessFile(filePath);
            List<IShape> shapeList = new List<IShape>();

            shapeList = Parser.ParseFileContents(fileContents);

            return shapeList;
        }
    }
}
