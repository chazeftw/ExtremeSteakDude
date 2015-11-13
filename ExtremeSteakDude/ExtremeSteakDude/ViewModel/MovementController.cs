using ExtremeSteakDude.Commands;
using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtremeSteakDude.ViewModel
{
    class MovementController : IDisposable
    { 
        public bool moveRight = false;
        public bool moveLeft = false;
        public bool jump = false;
        public bool isUndoMode = false;
        private Timer moveTimer;
        private UndoRedoController urc;
        

        public MovementController()
        {
            moveTimer = new Timer(x => Move(), null, 0, 50);
            
            urc = new UndoRedoController();
        }

        private void Move()
        {
            if (isUndoMode)
            {
                if(moveLeft)
                {
                    urc.Undo();  
                }
                else if(moveRight)
                {
                    urc.Redo();
                }
            }
            else
            {
                if(moveLeft && !moveRight)
                {
                    MoveLeft();
                }
                else if(moveRight && !moveLeft)
                {
                    MoveRight();
                }
                else

                if (Player.inAir)
                {
                    if(Player.vx > -50)
                    {
                        if (50 + Player.vy >= 10)
                        {
                            Player.vy = Player.vy - 10;
                        }
                        else
                        {
                            Player.vx = -50;
                        }
                    }
                }

                if (jump)
                {
                    Jump();
                    jump = false;
                }

                

                urc.AddAndExecute(new MomentumCommand(Player.vx,Player.vy));

                
            }
          }

        private void Jump()
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

        private void MoveRight()
        {
             if(Player.vx < 50)
            {
                if(50 - Player.vx <= 10)
                {
                    Player.vx = Player.vx + 10;
                }else
                {
                    Player.vx = 50;
                }
            }
        }

        private void MoveLeft()
        {
            if (Player.vx > -50)
            {
                if (-50 - Player.vx >= -10)
                {
                    Player.vx = Player.vx - 10;
                }
                else
                {
                    Player.vx = -50;
                }
            }
        }


        private static void WallSlide(bool orientation)
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

        private static void Land()
        {
            Player.inAir = false;
            Player.onWallRight = false;
            Player.onWallLeft = false;
            Player.vy = 0;
        }

        public void Dispose()
        {
            moveTimer.Dispose();
        }
    }
}
