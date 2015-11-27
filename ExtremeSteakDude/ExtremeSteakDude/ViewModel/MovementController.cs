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

        private int movespeed = 5;
        private int moveacc = 2;
        private int fallspeed = 5;
        private int gravity = 2;
        private int jumpheight = 20;
        private int tick = 5;

        private MapNew currentlvl;
        private CollisionDetector coll;
        private TimeSpan offset;
        private SoundController sc;

        

        public MovementController(Player p)
        {
            if (Player.level == Player.levelenum.one)
            {
                currentlvl = new lvl1();
            }

            if (Player.level == Player.levelenum.two)
            {
                currentlvl = new lvl2();
            }


            this.p = p;
            urc = new UndoRedoController();
            timer = new System.Diagnostics.Stopwatch();
            moveTimer = new Timer(x => Move(), null, 0, tick);
            coll = new CollisionDetector(this, currentlvl);
            sc = new SoundController();
        }

        private void Move()
        {if (first && !jump && !moveRight && !moveLeft)
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
                }else if(moveRight && !moveLeft && !p.onWallRight)
                {
                    MoveRight();
                }else
                {
                    if (p.vx > 0)
                    {
                        if (p.vx > moveacc+1 && !p.onWallRight)
                        {
                            p.vx = p.vx - moveacc;
                        }else
                        {
                            p.vx = 0;
                        }
                    }else if (p.vx < -moveacc && !p.onWallLeft)
                    {
                        p.vx = p.vx + moveacc;
                    }else
                    {
                        p.vx = 0;
                    }
                }
                if(p.inAir && (p.onWallLeft || p.onWallRight ))
                {
                    p.vx = 0;
                    if (p.vy < fallspeed/2)
                    {
                        if (15 - p.vy >= gravity/2)
                        {
                            p.vy = p.vy + gravity/2;
                        }
                        else
                        {
                            p.vy = fallspeed/2;
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
                urc.AddAndExecute(new MomentumCommand(p,p.vx,p.vy,timer.Elapsed+offset));
                coll.CheckForCollision();
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
             if(p.vx < movespeed)
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
