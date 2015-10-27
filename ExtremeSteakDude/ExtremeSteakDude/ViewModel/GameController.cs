using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtremeSteakDude.ViewModel;
using ExtremeSteakDude.Model;

namespace ExtremeSteakDude.ViewModel
{
    class GameController
    {
        public void InitializeMap(int mapIndex)
        {
            Player.vx = 0;
            Player.vy = 0;
            Player.x = Const.MAP[mapIndex].startX;
            Player.y = Const.MAP[mapIndex].startY;

        }
    }
}
