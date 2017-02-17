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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = new Form();

            DrawHandler drawHandler = DrawHandler.Instance;

            drawHandler.Initialize(form);

            Application.Run(form);

        }
    }
}
