using GraphicalEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalEditor
{
    class CommandHandler
    {


        private Stack<Command> executeStack = new Stack<Command>();
        private Stack<Command> undoStack = new Stack<Command>();



        public void AddCommand(Command commandToAdd)
        {
            executeStack.Push(commandToAdd);

            //Also execute the command when added.
            Redo();
        }

        public void Undo()
        {
            if (undoStack.Count == 0)
                return;

            Command cmd = undoStack.Pop();
            cmd.Undo();
            executeStack.Push(cmd);
        }

        public void Redo()
        {
            if (executeStack.Count == 0)
                return;

            Command cmd = executeStack.Pop();
            cmd.Execute();
            undoStack.Push(cmd);
        }
    }
}
