using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class MomentumCommand : IUndoRedoCommand
    {
        int x; int y;

        public MomentumCommand(int x,int y)
        {
            this.y = y;
            this.x = x;
        }

        public void Execute()
        {
            Player.x = Player.x + x;
            Player.y = Player.y + y;
        }

        public void Undo()
        {
            Player.x = Player.x - x;
            Player.y = Player.y - y;
        }
    }
}
