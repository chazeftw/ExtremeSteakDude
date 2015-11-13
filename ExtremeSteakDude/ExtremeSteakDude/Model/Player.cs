using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    class Player
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

        public bool moveRight = false;
        public bool moveLeft = false;
        public bool jump = false;
        public Timer moveTimer;


        public Player()
        {
            moveTimer = new Timer(x => Move(), null, 0, 50);
        }

        private void Move()
        {
            x = x + vx;
            y = y + vy;
        }

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
            else if (Player.onWallLeft)
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

        public void MoveRight()
        {
            if (vx < 50)
            {
                if (50 - vx <= 10)
                {
                    vx = vx + 10;
                }
                else
                {
                    vx = 50;
                }
            }
        }

        public void MoveLeft()
        {
            if (vx > -50)
            {
                if (-50 - vx >= -10)
                {
                    vx = vx - 10;
                }
                else
                {
                    vx = -50;
                }
            }
        }


        public static void WallSlide(bool orientation)
        {
            if (orientation)
            {
                onWallRight = true;
            }
            else
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
