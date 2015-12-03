using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class MomentumCommand : IUndoRedoCommand
    {
        int x; int y; ObservableCollection<Player> p; TimeSpan time;

        public MomentumCommand(ObservableCollection<Player> p, int x,int y,TimeSpan time)
        {
            this.time = time;
            this.y = y;
            this.x = x;
            this.p = p;
        }

        public void Execute()
        {
            p[0].x = p[0].x + x;
            p[0].y = p[0].y + y;
            p[0].setTimeElapsed(time.Ticks);
        }

        public void Undo()
        {
            p[0].x = p[0].x - x;
            p[0].y = p[0].y - y;
            p[0].setTimeElapsed(time.Ticks);
        }
    }
}
