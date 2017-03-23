using GraphicalEditor.IO;
using GraphicalEditor.Util;
using System;
using System.Windows.Forms;

namespace GraphicalEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Parser.TestParserAndOutputDisplayToConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = new Form();

            Application.Run(form);

            Logger.CloseLogger();
        }
    }
}
