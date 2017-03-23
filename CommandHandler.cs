using GraphicalEditor.Interfaces;
using System;
using System.Collections.Generic;
namespace GraphicalEditor
{
    class CommandHandler
    {


        private Stack<Command> executeStack = new Stack<Command>();
        private Stack<Command> undoStack = new Stack<Command>();

        public event OnExecuteDel OnExecute;
        public delegate void OnExecuteDel(Command command);

        public event OnRedoDel OnUndo;
        public delegate void OnRedoDel(Command command);

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

            if(OnUndo != null)
                OnUndo(cmd);


            executeStack.Push(cmd);

           
        }

        public void Redo()
        {
            if (executeStack.Count == 0)
                return;

            Command cmd = executeStack.Pop();
            cmd.Execute();

            if(OnExecute != null)
                OnExecute(cmd);

            undoStack.Push(cmd);
        }
    }
}
