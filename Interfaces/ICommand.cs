namespace GraphicalEditor.Interfaces
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
