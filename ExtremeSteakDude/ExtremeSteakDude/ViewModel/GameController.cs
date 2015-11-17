using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtremeSteakDude.ViewModel;
using ExtremeSteakDude.Model;
using ExtremeSteakDude.Constants;

namespace ExtremeSteakDude.ViewModel
{
    class GameController
    {
        public void InitializeMap(int mapIndex)
        {
            Player p1 = new Player();
            p1.vx = 0;
            p1.vy = 0;
            p1.x = Const.MAP[mapIndex].startX;
            p1.y = Const.MAP[mapIndex].startY;

        }
    }
}
