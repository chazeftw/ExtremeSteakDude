using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
   
    class UndoRedoController
    {
        Stack<IUndoRedoCommand> undos;
        Stack<IUndoRedoCommand> redos;


        public UndoRedoController()
        {
            undos = new Stack<IUndoRedoCommand>();
            redos = new Stack<IUndoRedoCommand>();
        }

        public bool CanUndo() => undos.Any();
        public bool CanRedo() => redos.Any();
        
        public void AddAndExecute(IUndoRedoCommand command)
        {
            undos.Push(command);
            redos.Clear();
            command.Execute();
        }

        public void Undo()
        {
            if (!undos.Any()) throw new InvalidOperationException();
            var command = undos.Pop();
            redos.Push(command);
            command.Undo();
        }

        public void Redo()
        {
            if (!redos.Any()) throw new InvalidOperationException();
            var command = redos.Pop();
            undos.Push(command);
            command.Execute();
        }
        

    }
}
