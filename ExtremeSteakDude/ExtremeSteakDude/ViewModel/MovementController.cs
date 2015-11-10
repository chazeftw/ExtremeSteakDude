using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtremeSteakDude.ViewModel
{
    class MovementController
    {
        public bool moveRight = false;
        public bool moveLeft = false;
        public bool jump = false;
        public Timer moveTimer;


        public MovementController()
        {
            moveTimer = new Timer(x => Move(), null, 0,50);
        }

        private void Move()
        {
            Player.x = Player.x + Player.vx;
            Player.y = Player.y + Player.vy;
        }

        public static void Jump()
        {
            if (Player.inAir)
            {
                // do nothing
            }
            else if (Player.onWallRight)
            {
                Player.vx = -50;
                Player.vy = 50;
                Player.onWallRight = false;
            }
            else if (Player.onWallLeft)
            {
                Player.vx = 50;
                Player.vy = 50;
                Player.onWallLeft = false;
            }
            else
            {
                Player.vy = 50;
                Player.inAir = true;
            }


        }

        public void MoveRight()
        {
             
        }


        public static void WallSlide(bool orientation)
        {
            if (orientation)
            {
                Player.onWallRight = true;
            }
            else
            {
                Player.onWallLeft = true;
            }
            Player.vx = 0;
        }

        public static void Land()
        {
            Player.inAir = false;
            Player.onWallRight = false;
            Player.onWallLeft = false;
            Player.vy = 0;
        }
    }
}
