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
        public Player p;
        private Timer moveTimer;
        private UndoRedoController urc;
        

        public MovementController()
        {
            p = new Player();
            System.Console.WriteLine("lolol");
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
                if(moveLeft && !moveRight && !(p.onWallLeft || p.onWallRight))
                {
                    MoveLeft();
                }
                else if(moveRight && !moveLeft && !(p.onWallLeft || p.onWallRight))
                {
                    MoveRight();
                }
                else

                if (p.inAir)
                {
                    if(p.vx > -50)
                    {
                        if (50 + p.vy >= 10)
                        {
                            p.vy = p.vy - 10;
                        }
                        else
                        {
                            p.vx = -50;
                        }
                    }
                }

                if (jump)
                {
                    Jump();
                    jump = false;
                }

                

                urc.AddAndExecute(new MomentumCommand(p.vx,p.vy));

                
            }
          }

        private void Jump()
        {
            if (p.inAir)
            {
                // do nothing
            }
            else if (p.onWallRight)
            {
                p.vx = -50;
                p.vy = 50;
                p.onWallRight = false;
            }
            else if (p.onWallLeft)
            {
                p.vx = 50;
                p.vy = 50;
                p.onWallLeft = false;
            }
            else
            {
                p.vy = 50;
                p.inAir = true;
            }


        }

        private void MoveRight()
        {
             if(p.vx < 50)
            {
                if(50 - p.vx <= 10)
                {
                    p.vx = p.vx + 10;
                }else
                {
                    p.vx = 50;
                }
            }
        }

        private void MoveLeft()
        {
            if (p.vx > -50)
            {
                if (-50 - p.vx >= -10)
                {
                    p.vx = p.vx - 10;
                }
                else
                {
                    p.vx = -50;
                }
            }
        }


        private void WallSlide(bool orientation)
        {
            if (orientation)
            {
                p.onWallRight = true;
            }
            else
            {
                p.onWallLeft = true;
            }
            p.vx = 0;
        }

        private void Land()
        {
            p.inAir = false;
            p.onWallRight = false;
            p.onWallLeft = false;
            p.vy = 0;
        }

        public void Dispose()
        {
            moveTimer.Dispose();
        }
    }
}
