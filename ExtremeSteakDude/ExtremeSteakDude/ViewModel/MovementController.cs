using ExtremeSteakDude.Commands;
using ExtremeSteakDude.Levels;
using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
        private bool first = true;

        public Player p;
        private Timer moveTimer;
        private UndoRedoController urc;
        private System.Diagnostics.Stopwatch timer;

        private int movespeed = 7;
        private int moveacc = 3;
        private int fallspeed = 7;
        private int gravity = 3;
        private int jumpheight = 25;
        private int tick = 10;

        private MapNew currentlvl;
        private CollisionDetector coll;
        private TimeSpan offset;
        private CDC cdc;
        private SoundController sc;

        

        public MovementController(Player p)
        {
            if (Player.level == Player.levelenum.one)
            {
                currentlvl = new lvl2();
                Console.WriteLine("LEVEL ONE IN MC");
            }

            if (Player.level == Player.levelenum.two)
            {
                currentlvl = new lvl2();
                Console.WriteLine("LEVEL TWO IN MC");
            }


            this.p = p;
            urc = new UndoRedoController();
            timer = new System.Diagnostics.Stopwatch();
            moveTimer = new Timer(x => Move(), null, 0, tick);
            sc = new SoundController();
            //coll = new CollisionDetector(this, currentlvl);
            cdc = new CDC(this, currentlvl);

        }

        private void Move()
        {
            if (first && !jump && !moveRight && !moveLeft)
            {
                return;
            }
            first = false;

            if (isUndoMode)
            {
                timer.Stop();
                if(moveLeft)
                {
                    urc.Undo();  
                    
                }else if(moveRight)
                {
                    urc.Redo();
                }
            }else
            {
                

                if (timer.IsRunning == false)
                {
                    offset = p.timeSpan;
                    timer.Restart();
                }

                if(moveLeft && !moveRight && !p.onWallLeft)
                {
                    MoveLeft();
                    
                }
                else if(moveRight && !moveLeft && !p.onWallRight)
                {
                    MoveRight();
                }else
                {
                    if (p.vx > 0)
                    {
                        if (p.onWallRight) { p.vx = 0; }
                        else if (p.vx > moveacc + 1 && !p.onWallRight)
                        {
                            p.vx = p.vx - moveacc;
                        }
                        else
                        {
                            p.vx = 0;
                        }
                    }else if (p.vx < -moveacc)
                    {
                        if (p.onWallLeft) { p.vx = 0; }
                        else { p.vx = p.vx + moveacc; }
                    }else
                    {
                        p.vx = 0;
                    }
                }

                if(p.inAir && (p.onWallLeft || p.onWallRight ))
                {
                    if (p.vy < 2*fallspeed/3)
                    {
                        if (15 - p.vy >= 2*gravity/3)
                        {
                            p.vy = p.vy + 2*gravity/3;
                        }
                        else
                        {
                            p.vy = 2*fallspeed/3;
                        }
                    }
                }else if (p.inAir)
                {
                    if(p.vy < fallspeed)
                    {
                        if (15 - p.vy >= gravity)
                        {
                            p.vy = p.vy +gravity ;
                        }else
                        {
                            p.vy = fallspeed;
                        }
                    }
                }else if (jump)
                {
                    Jump();
                    jump = false;
                }else
                {
                    p.vy = 0;   
                }
                cdc.check();
                urc.AddAndExecute(new MomentumCommand(p,p.vx,p.vy,timer.Elapsed+offset));
               // coll.CheckForCollision();
            }
          }

        private void Jump()
        {
            sc.playJumpSound();
            if (p.onWallRight && p.inAir)
            {
                p.vx = -jumpheight;
                p.vy = -jumpheight;
                p.onWallRight = false;
            }else if (p.onWallLeft && p.inAir)
            {
                p.vx = jumpheight;
                p.vy = -jumpheight;
                p.onWallLeft = false;
            }else
            {
                p.vy = -jumpheight;
                p.inAir = true;
            }


        }

        private void MoveRight()
        {
            if (p.vx < movespeed)
            {
                if(10 - p.vx <= moveacc)
                {
                    p.vx = p.vx + moveacc;
                }else
                {
                    p.vx = movespeed;
                }
            }
        }private void MoveLeft()
        {
            if (p.vx > -movespeed)
            {
                if (-10 - p.vx >= -moveacc)
                {
                    p.vx = p.vx - moveacc;
                }
                else
                {
                    p.vx = -movespeed;
                }
            }
        }
        public void Dispose()
        {
            moveTimer.Dispose();
        }
        
    }
}
