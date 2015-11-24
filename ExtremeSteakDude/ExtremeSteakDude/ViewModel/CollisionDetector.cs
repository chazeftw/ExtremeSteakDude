using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtremeSteakDude.Model;
using System.Drawing;


namespace ExtremeSteakDude.ViewModel
{

    class CollisionDetector
    {
        MovementController mc;
        MapNew map;
        Rectangle playerRec = new Rectangle(0, 0, Constants.Const.PLAYERHEIGHT, Constants.Const.PLAYERWIDTH);

    public CollisionDetector(MovementController mc,MapNew map)
        {
            this.map = map;
            this.mc = mc;
            playerRec.X = mc.p.x ;
            playerRec.Y = mc.p.y;
        }

    public void CheckForCollision()
        {
            bool topleft = false;
            bool topright = false;
            bool botleft = false;
            bool botright = false;
            playerRec.X = mc.p.x;
            playerRec.Y = mc.p.y;
            playerRec.Height = Constants.Const.PLAYERHEIGHT;
            playerRec.Width = Constants.Const.PLAYERWIDTH;
            foreach (Rectangle r in map.objectorinos)
            {
                // checking if players corners are in objects
                if (r.Contains(playerRec.Left, playerRec.Top))
                    topleft = true;
                if (r.Contains(playerRec.Right, playerRec.Top))
                    topright = true;
                if (r.Contains(playerRec.Left, playerRec.Bottom))
                    botleft = true;
                if (r.Contains(playerRec.Right, playerRec.Bottom))
                    botright = true;
            }
            //Setting players parameters accordingly
            if (botright && botleft)
                mc.p.inAir = false;

            if (botright && topright)
                mc.p.onWallRight = true;

            if (botleft && topleft)
                mc.p.onWallLeft = true;

            if (topright && botright)
                mc.p.hitRoof = true;

            GC.Collect();
        }


    }
}
