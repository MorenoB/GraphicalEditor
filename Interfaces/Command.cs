namespace GraphicalEditor.Interfaces
{
    interface Command
    {
        void Execute();
        void Undo();
    }
}
