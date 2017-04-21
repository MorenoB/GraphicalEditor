using System.IO;

namespace GraphicalEditor.IO
{
    class Filehandler
    {
        public static string ProcessFile(string filePath)
        {
            StreamReader reader = File.OpenText(filePath);
            string fileContents = reader.ReadToEnd();
            reader.Close();

            return fileContents;
        }

        public static void SaveToFile(string[] input, string filePath)
        {
            using (StreamWriter file = new StreamWriter(filePath))
            {
                foreach (string line in input)
                {
                   file.WriteLine(line);
                    
                }
            }
        }

    }
}
