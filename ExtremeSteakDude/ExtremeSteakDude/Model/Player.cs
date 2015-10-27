using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    static class Player
    {
        // position
        public static int x { get; set; }
        public static int y { get; set; }

        // vectors
        public static int vx { get; set; }
        public static int vy { get; set; }

        public static bool inAir { get; set; }
        public static bool onWallRight { get; set; }
        public static bool onWallLeft { get; set; }

        public static void Jump()
        {
            if (inAir)
            {
                // do nothing
            }
            else if (onWallRight)
            {
                vx = -50;
                vy = 50;
                onWallRight = false;
            }
            else if (onWallLeft)
            {
                vx = 50;
                vy = 50;
                onWallLeft = false;
            }
            else
            {
                vy = 50;
                inAir = true;
            }
                

        }

        public static void WallSlide(bool orientation)
        {
            if(orientation)
            {
                onWallRight = true;
            }else
            {
                onWallLeft = true;
            }
            vx = 0;
        }

        public static void Land()
        {
            inAir = false;
            onWallRight = false;
            onWallLeft = false;
            vy = 0;
        }

    }
}
