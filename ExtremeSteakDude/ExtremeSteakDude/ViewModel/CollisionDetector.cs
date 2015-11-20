using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtremeSteakDude.Model;
using System.Drawing;
using ExtremeSteakDude.Model;

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

    private void CheckForCollision()
        {
            playerRec.X = mc.p.x;
            playerRec.Y = mc.p.y;
            foreach (Rectangle r in map.objects())
            {
                if (!playerRec.IntersectsWith(r))
                    continue;
                else
                {
                    if (r.Contains(playerRec.Right, playerRec.Bottom)&& r.Contains(playerRec.Left,playerRec.Bottom))
                        mc.p.inAir = false;

                    if (r.Contains(playerRec.Right, playerRec.Bottom) && r.Contains(playerRec.Right, playerRec.Top))
                        mc.p.onWallRight = true;

                    if (r.Contains(playerRec.Left, playerRec.Bottom) && r.Contains(playerRec.Left, playerRec.Top))
                        mc.p.onWallLeft = true;

                    if (r.Contains(playerRec.Right, playerRec.Top) && r.Contains(playerRec.Right, playerRec.Bottom))
                        mc.p.onWallRight = true;

                }
            }
        }


    }
}
