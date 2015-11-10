using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class JumpCommand : IUndoRedoCommand
    {
        public void Execute()
        {
            Model.Player.Jump();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
