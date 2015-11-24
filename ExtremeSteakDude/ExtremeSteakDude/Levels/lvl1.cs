using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ExtremeSteakDude.Constants;

namespace ExtremeSteakDude.Levels
{
    class lvl1
    {
        int startX;
        int startY;
        List<Rectangle> mapObjects = new List<Rectangle>();

        public lvl1()
        {
            this.startX = 50;
            this.startY = 200;
            Rectangle ground = new Rectangle(0, Const.MAPHEIGHT - 100, Const.MAPWIDTH, 100);
            
            mapObjects.Add(ground);
            Rectangle obstacle1 = new Rectangle(Const.MAPWIDTH / 2, Const.MAPHEIGHT - 150, 25, 50);
            mapObjects.Add(obstacle1);
            
        }

        

    }
}
