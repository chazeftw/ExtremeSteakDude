using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using ExtremeSteakDude.Constants;

namespace ExtremeSteakDude.Levels
{
    class lvl1:Model.MapNew
    {
        int startX;
        int startY;
        
        List<Rectangle> mapObjects = new List<Rectangle>();

        public lvl1()
        {
            this.startX = 50;
            this.startY = 200;
            Rectangle backGround = new Rectangle(0,0,Const.MAPWIDTH,Const.MAPHEIGHT);
            SolidBrush bgBrush = new SolidBrush(Color.AliceBlue);


            Rectangle ground = new Rectangle(0, Const.MAPHEIGHT - 100, Const.MAPWIDTH, 100);
            SolidBrush groundBrush = new SolidBrush(Color.DarkSeaGreen);
            mapObjects.Add(ground);
            Rectangle obstacle1 = new Rectangle(Const.MAPWIDTH / 2, Const.MAPHEIGHT - 150, 25, 50);
            SolidBrush obstacleBrush = new SolidBrush(Color.IndianRed);
            mapObjects.Add(obstacle1);
            
        }

        

    }
}
