using GraphicalEditor.Interfaces;
using System.Collections.Generic;

namespace GraphicalEditor.Shapes
{
    class GroupCommand : ICommand
    {
        private List<ICommand> childCommands = new List<ICommand>();

        public void Execute()
        {
            foreach (ICommand command in childCommands)
                command.Execute();
        }

        public void Undo()
        {
            foreach (ICommand command in childCommands)
                command.Undo();
        }

        public void Add(ICommand command)
        {
            childCommands.Add(command);
        }

        public void Remove(ICommand command)
        {
            childCommands.Remove(command);
        }
    }
}
