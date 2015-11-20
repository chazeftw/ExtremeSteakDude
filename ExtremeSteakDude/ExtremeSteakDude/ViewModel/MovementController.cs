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
        

        public MovementController(Player p)
        {
            this.p = p;
            moveTimer = new Timer(x => Move(), null, 0, 25);
            
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
                {
                    if(Math.Abs(p.vx)>0)
                    {
                        if (p.vx < 4)
                        {
                            p.vx = p.vx - 3;   
                        }
                        else if(p.vx > -4)
                        {
                            p.vx = p.vx + 3;
                        }
                        else
                        {
                            p.vx = 0;
                        }
                    }
                }
                if (p.inAir)
                {
                    if(p.vx > -10)
                    {
                        if (10 + p.vy >= 3)
                        {
                            p.vy = p.vy - 3;
                        }
                        else
                        {
                            p.vx = -10;
                        }
                    }
                }

                if (jump)
                {
                    Jump();
                    jump = false;
                }

                

                urc.AddAndExecute(new MomentumCommand(p,p.vx,p.vy));

                
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
                p.vx = -10;
                p.vy = 10;
                p.onWallRight = false;
            }
            else if (p.onWallLeft)
            {
                p.vx = 10;
                p.vy = 10;
                p.onWallLeft = false;
            }
            else
            {
                p.vy = 10;
                p.inAir = true;
            }


        }

        private void MoveRight()
        {
             if(p.vx < 10)
            {
                if(10 - p.vx <= 3)
                {
                    p.vx = p.vx + 3;
                }else
                {
                    p.vx = 10;
                }
            }
        }

        private void MoveLeft()
        {
            if (p.vx > -10)
            {
                if (-10 - p.vx >= -3)
                {
                    p.vx = p.vx - 3;
                }
                else
                {
                    p.vx = -10;
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
