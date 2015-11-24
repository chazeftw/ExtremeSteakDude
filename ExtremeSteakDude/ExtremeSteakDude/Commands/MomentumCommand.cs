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
        int x; int y; Player p; TimeSpan time;

        public MomentumCommand(Player p, int x,int y,TimeSpan time)
        {
            this.time = time;
            this.y = y;
            this.x = x;
            this.p = p;
        }

        public void Execute()
        {
            p.x = p.x + x;
            p.y = p.y + y;
            p.elapsedTime = time;
        }

        public void Undo()
        {
            p.x = p.x - x;
            p.y = p.y - y;
            p.elapsedTime = time;
        }
    }
}
