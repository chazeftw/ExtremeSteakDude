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
        List<IUndoRedoCommand> undos;
        List<IUndoRedoCommand> redos;
        public bool isRedoable;

        public UndoRedoController()
        {
            undos = new List<IUndoRedoCommand>();
            redos = new List<IUndoRedoCommand>();
            isRedoable = false;
        }

        public void AddAndExecuteCommand(RelayCommand command)
        {
            
        }

    }
}
