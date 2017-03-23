using GraphicalEditor.Interfaces;
using System;
using System.Collections.Generic;
namespace GraphicalEditor
{
    class CommandHandler
    {


        private Stack<ICommand> executeStack = new Stack<ICommand>();
        private Stack<ICommand> undoStack = new Stack<ICommand>();

        public event OnExecuteDel OnExecute;
        public delegate void OnExecuteDel(ICommand command);

        public event OnRedoDel OnUndo;
        public delegate void OnRedoDel(ICommand command);

        public void AddCommand(ICommand commandToAdd)
        {
            executeStack.Push(commandToAdd);

            //Also execute the command when added.
            Redo();
        }

        public void Undo()
        {
            if (undoStack.Count == 0)
                return;

            ICommand cmd = undoStack.Pop();
            cmd.Undo();

            if(OnUndo != null)
                OnUndo(cmd);


            executeStack.Push(cmd);

           
        }

        public void Redo()
        {
            if (executeStack.Count == 0)
                return;

            ICommand cmd = executeStack.Pop();
            cmd.Execute();

            if(OnExecute != null)
                OnExecute(cmd);

            undoStack.Push(cmd);
        }
    }
}
