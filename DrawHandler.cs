namespace GraphicalEditor
{
    public sealed class DrawHandler
    {
        private Form form;

        private static readonly DrawHandler instance = new DrawHandler();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DrawHandler()
        {
            
        }

        private DrawHandler()
        {
        }

        public static DrawHandler Instance
        {
            get
            {
                return instance;
            }
        }

        public void Initialize(Form form)
        {
            this.form = form;
        }

    }
}
