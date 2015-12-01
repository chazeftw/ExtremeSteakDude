using ExtremeSteakDude.Commands;
using ExtremeSteakDude.Levels;
using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Player> p;
        private Timer moveTimer;
        private UndoRedoController urc;
        private System.Diagnostics.Stopwatch timer;

        private int movespeed = 7;
        private int moveacc = 1;
        private int fallspeed = 7;
        private int gravity = 1;
        private int jumpheight = 15;
        private int tick = 10;

        private MapNew currentlvl;
        private CollisionDetector coll;
        private TimeSpan offset;
        private CDC cdc;
        private SoundController sc;

        

        public MovementController(ObservableCollection<Player> p)
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
                    offset = p[0].timeSpan;
                    timer.Restart();
                }

                if(moveLeft && !moveRight && !p[0].onWallLeft)
                {
                    MoveLeft();
                    
                }
                else if(moveRight && !moveLeft && !p[0].onWallRight)
                {
                    MoveRight();
                }else
                {
                    if (p[0].vx > 0)
                    {
                        if (p[0].onWallRight) { p[0].vx = 0; }
                        else if (p[0].vx > moveacc + 1 && !p[0].onWallRight)
                        {
                            p[0].vx = p[0].vx - moveacc;
                        }
                        else
                        {
                            p[0].vx = 0;
                        }
                    }else if (p[0].vx < -moveacc)
                    {
                        if (p[0].onWallLeft) { p[0].vx = 0; }
                        else { p[0].vx = p[0].vx + moveacc; }
                    }else
                    {
                        p[0].vx = 0;
                    }
                }
                if(p[0].top)
                {
                    if (p[0].vy > 0)
                        p[0].vy = 0;
                }
                if(p[0].inAir && (p[0].onWallLeft || p[0].onWallRight) && !jump )
                {
                    
                        
                    if (p[0].vy < 2*fallspeed/3)
                    {
                        if (15 - p[0].vy >= 2*gravity/3)
                        {
                            p[0].vy = p[0].vy + 2*gravity/3;
                        }
                        else
                        {
                            p[0].vy = 2*fallspeed/3;
                        }
                    }
                }else if (p[0].inAir)
                {
                    if(p[0].vy < fallspeed)
                    {
                        if (15 - p[0].vy >= gravity)
                        {
                            p[0].vy = p[0].vy +gravity ;
                        }else
                        {
                            p[0].vy = fallspeed;
                        }
                    }
                }else if (jump)
                {
                    Jump();
                    jump = false;
                }else
                {
                    p[0].vy = 0;   
                }
                cdc.check();
                urc.AddAndExecute(new MomentumCommand(p,p[0].vx,p[0].vy,timer.Elapsed+offset));
               // coll.CheckForCollision();
            }
          }

        private void Jump()
        {
            sc.playJumpSound();
            if (p[0].onWallRight && p[0].inAir)
            {
                p[0].vx = -jumpheight;
                p[0].vy = -jumpheight;
                p[0].onWallRight = false;
            }else if (p[0].onWallLeft && p[0].inAir)
            {
                p[0].vx = jumpheight;
                p[0].vy = -jumpheight;
                p[0].onWallLeft = false;
            }else
            {
                p[0].vy = -jumpheight;
                p[0].inAir = true;
            }


        }

        private void MoveRight()
        {
            if (p[0].vx < movespeed)
            {
                if(10 - p[0].vx <= moveacc)
                {
                    p[0].vx = p[0].vx + moveacc;
                }else
                {
                    p[0].vx = movespeed;
                }
            }
        }private void MoveLeft()
        {
            if (p[0].vx > -movespeed)
            {
                if (-10 - p[0].vx >= -moveacc)
                {
                    p[0].vx = p[0].vx - moveacc;
                }
                else
                {
                    p[0].vx = -movespeed;
                }
            }
        }
        public void Dispose()
        {
            moveTimer.Dispose();
        }
        
    }
}
