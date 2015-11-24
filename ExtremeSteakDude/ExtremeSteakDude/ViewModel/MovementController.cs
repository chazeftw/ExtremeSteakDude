﻿using ExtremeSteakDude.Commands;
using ExtremeSteakDude.Levels;
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
        private System.Diagnostics.Stopwatch timer;

        private int movespeed = 20;
        private int moveacc = 8;
        private int fallspeed = 20;
        private int gravity = 5;
        private int jumpheight = 35;
        private int tick = 25;
        private MapNew currentlvl;
        private CollisionDetector coll;

        public MovementController(Player p)
        {
            if (Player.level == Player.levelenum.one)
            {
                currentlvl = new lvl1();
            }

            if (Player.level == Player.levelenum.two)
            {

            }


            this.p = p;
            urc = new UndoRedoController();
            timer = new System.Diagnostics.Stopwatch();
            moveTimer = new Timer(x => Move(), null, 0, tick);
            coll = new CollisionDetector(this, currentlvl);

        }

        private void Move()
        {
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
                coll.CheckForCollision();

                if (timer.IsRunning == false) timer.Start();



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
                if (p.inAir)
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
                }else if (p.vy != 0)
                {
                        Land();
                }else if (jump)
                {
                    Jump();
                    jump = false;
                }
                urc.AddAndExecute(new MomentumCommand(p,p.vx,p.vy,timer.Elapsed));
                
            }
          }

        private void Jump()
        {
            if (p.inAir)
            {
                // do nothing
            }else if (p.onWallRight)
            {
                p.vx = -jumpheight;
                p.vy = -jumpheight;
                p.onWallRight = false;
            }else if (p.onWallLeft)
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
