namespace GraphicalEditor.Util
{
    public class Singleton
    {
        private static volatile Singleton instance;
        private static object syncRoot = new object();

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Singleton();
                    }
                }

                return instance;
            }
        }
    }
}
