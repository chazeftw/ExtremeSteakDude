using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.ViewModel
{
    class CDC
    {
        private Bitmap image;
        private MovementController mc;
        private int[] rightFoot = new int[2];
        private int[] leftFoot = new int[2];
        private int[] leftSideTop = new int[2];
        private int[] leftSideBot = new int[2];
        private int[] rightSideTop = new int[2];
        private int[] rightSideBot = new int[2];
        private int[] rightTop = new int[2];
        private int[] leftTop = new int[2];
        private Color backGround;
        private Color deathColor;
        private Color winColor;

        public CDC(MovementController mc, MapNew map)
        {
            image = map.image;
            this.mc = mc;

            // Maybe also give this overloaded constructor a variable that says what level we are in and then hardcore
            // the colors to the according level
            backGround = image.GetPixel(0, 0);
            deathColor = image.GetPixel(2, 0);
            winColor = image.GetPixel(3,0);

        }

        public void check()
        {
            try
            {
                InitializeBoundaries();
                CheckWinLossState();
                CheckInAir();
                CheckOnWallRight();
                CheckOnWallLeft();
                CheckOnTop();

                if (mc.p[0].onWallLeft && mc.p[0].onWallRight && !mc.p[0].inAir)
                {
                    int i = 0;
                    while (image.GetPixel(leftSideBot[0], leftSideBot[1]) != backGround && image.GetPixel(rightSideBot[0], rightSideBot[1]) != backGround)
                    {
                        leftSideBot[1]--;
                        rightSideBot[1]--;
                        i++;
                    }
                    mc.p[0].vy = mc.p[0].vy - i;
                    CheckOnWallLeft();
                    CheckOnWallRight();
                }
                else if (mc.p[0].top && !mc.p[0].inAir)
                {
                    if (mc.p[0].onWallLeft)
                    {
                        int i = 0;
                        while (image.GetPixel(leftTop[0], leftTop[1]) != backGround || image.GetPixel(leftFoot[0], leftFoot[1]) != backGround)
                        {
                            leftTop[0]++;
                            leftFoot[0]++;
                            i++;
                        }
                        mc.p[0].vx = mc.p[0].vx + i;
                        CheckInAir();
                        CheckOnTop();
                    }
                    else if (mc.p[0].onWallRight)
                    {
                        int i = 0;
                        while (image.GetPixel(rightTop[0], rightTop[1]) != backGround || image.GetPixel(rightFoot[0], rightFoot[1]) != backGround)
                        {
                            rightTop[0]--;
                            rightFoot[0]--;
                            i++;
                        }
                        mc.p[0].vx = mc.p[0].vx - i;
                        CheckInAir();
                        CheckOnTop();
                    }
                }
                else if (mc.p[0].top && (mc.p[0].onWallLeft || mc.p[0].onWallRight))
                {
                    int i = 0;
                    while (image.GetPixel(leftSideTop[0], leftSideTop[1]) != backGround || image.GetPixel(rightSideTop[0], rightSideTop[1]) != backGround)
                    {
                        leftSideTop[1]++;
                        rightSideTop[1]++;
                        i++;
                    }
                    mc.p[0].vy = mc.p[0].vy + i;
                    CheckOnWallLeft();
                    CheckOnWallRight();
                }
                else if (!mc.p[0].inAir && (mc.p[0].onWallRight || mc.p[0].onWallLeft))
                {
                    if(mc.p[0].vy >= 0)
                    {
                        if(mc.p[0].vx >= 0)
                        {
                            int i = 0;
                            int j;
                            if(mc.p[0].vx > mc.p[0].vy){ j = 0; } else { j = 1; }
                            while(image.GetPixel(rightSideBot[0],rightSideBot[1]) != backGround && image.GetPixel(rightFoot[0],rightFoot[1]) != backGround)
                            {
                                rightSideBot[j]--;
                                rightFoot[j]--;
                                i++;
                            }
                            if (j == 0)
                            {
                                mc.p[0].vx = mc.p[0].vx - i;
                            }else
                            {
                                mc.p[0].vy = mc.p[0].vy - i;
                            }
                            CheckInAir();
                            CheckOnWallLeft();
                            CheckOnTop();
                        }
                        else if(mc.p[0].vx < 0)
                        {
                            int i = 0;
                            int j;
                            if (-mc.p[0].vx > mc.p[0].vy) { j = 0; } else { j = 1; }
                            while (image.GetPixel(leftSideBot[0], leftSideBot[1]) != backGround && image.GetPixel(leftFoot[0], leftFoot[1]) != backGround)
                            {
                                leftSideBot[j] = leftSideBot[j] + ( -(j * 2) + 1);
                                leftFoot[j] = leftFoot[j] + ( -(j * 2) + 1);
                                i++;
                            }
                            if (j == 0)
                            {
                                mc.p[0].vx = mc.p[0].vx + i;
                            }
                            else
                            {
                                mc.p[0].vy = mc.p[0].vy - i;
                            }
                            CheckInAir();
                            CheckOnWallLeft();
                            CheckOnTop();
                        }
                    }
                    else if (mc.p[0].vy < 0)
                    {
                        if (mc.p[0].vx >= 0)
                        {
                            int i = 0;
                            int j;
                            if (mc.p[0].vx > -mc.p[0].vy) { j = 0; } else { j = 1; }
                            while (image.GetPixel(rightSideTop[0], rightSideTop[1]) != backGround && image.GetPixel(rightTop[0], rightTop[1]) != backGround)
                            {
                                rightSideTop[j] = rightSideTop[j] + (j * 2) -1;
                                rightTop[j] = rightTop[j] + (j * 2) - 1;
                                i++;
                            }
                            if (j == 0)
                            {
                                mc.p[0].vx = mc.p[0].vx - i;

                            }
                            else
                            {
                                mc.p[0].vy = mc.p[0].vy + i;
                            }
                            CheckOnTop();
                            CheckInAir();
                            CheckOnWallRight();
                        }
                        else if (mc.p[0].vx < 0)
                        {
                            int i = 0;
                            int j;
                            if (-mc.p[0].vx > -mc.p[0].vy) { j = 0; } else { j = 1; }
                            while (image.GetPixel(leftSideTop[0], leftSideTop[1]) != backGround && image.GetPixel(leftTop[0], leftTop[1]) != backGround)
                            {
                                leftSideTop[j]++;
                                leftTop[j]++;
                                i++;
                            }
                            if (j == 0)
                            {
                                mc.p[0].vx = mc.p[0].vx + i;
                            }
                            else
                            {
                                mc.p[0].vy = mc.p[0].vy + i;
                            }
                            CheckOnWallLeft();
                            CheckInAir();
                            CheckOnTop();
                        }

                    }
                }
            }
            catch (InvalidOperationException)
            {

            }catch(ArgumentOutOfRangeException)
            {
                mc.p[0].vy = 0;
                mc.p[0].vx = 0;
                // If meatboy jumps out of the screen the following will trigger
                // Commented the following so we can jump out of the screen without issues even though players then
                // can bug the shit out the game probably. To be considered
                //mc.p[0].alive = false;
            }
        }

        private void CheckWinLossState()
        {
            // If player is on the deathcolor (red)
            if (image.GetPixel(rightFoot[0], rightFoot[1]) == deathColor || image.GetPixel(leftFoot[0], leftFoot[1]) == deathColor)
            {
                mc.p[0].alive = false;
                mc.first = true;
            }

            // If player is on the winning color (yellow ish)
            if (image.GetPixel(rightFoot[0], rightFoot[1]) == winColor || image.GetPixel(leftFoot[0], leftFoot[1]) == winColor)
            {
                mc.p[0].won = true;
            }
        }

        private void InitializeBoundaries()
        {
            rightFoot[0] = mc.p[0].x + 31 + mc.p[0].vx;
            rightFoot[1] = mc.p[0].y + 32 + mc.p[0].vy;
            leftFoot[0] = mc.p[0].x + 0 + mc.p[0].vx;
            leftFoot[1] = mc.p[0].y + 32 + mc.p[0].vy;

            leftSideTop[0] = mc.p[0].x - 1 + mc.p[0].vx;
            leftSideTop[1] = mc.p[0].y + 0 + mc.p[0].vy;
            leftSideBot[0] = mc.p[0].x - 1 + mc.p[0].vx;
            leftSideBot[1] = mc.p[0].y + 31 + mc.p[0].vy;

            rightSideTop[0] = mc.p[0].x + 32 + mc.p[0].vx;
            rightSideTop[1] = mc.p[0].y + 0 + mc.p[0].vy;
            rightSideBot[0] = mc.p[0].x + 32 + mc.p[0].vx;
            rightSideBot[1] = mc.p[0].y + 31 + mc.p[0].vy;

            rightTop[0] = mc.p[0].x + mc.p[0].vx;
            rightTop[1] = mc.p[0].y - 1 + mc.p[0].vy;
            leftTop[0] = mc.p[0].x + 31 + mc.p[0].vx;
            leftTop[1] = mc.p[0].y - 1 + mc.p[0].vy;

        }

        private void CheckOnTop()
        {
            if (image.GetPixel(leftTop[0], leftTop[1]) != backGround || image.GetPixel(rightTop[0], rightTop[1]) != backGround)
            {
                mc.p[0].top = true;
            }
            else
            {
                mc.p[0].top = false;
            }
        }

        private void CheckOnWallLeft()
        {
            if (image.GetPixel(leftSideTop[0], leftSideTop[1]) != backGround || image.GetPixel(leftSideBot[0], leftSideBot[1]) != backGround)
            {
                mc.p[0].onWallLeft = true;
            }
            else
            {
                mc.p[0].onWallLeft = false;
            }
        }

        private void CheckOnWallRight()
        {
            if (image.GetPixel(rightSideTop[0], rightSideTop[1]) != backGround || image.GetPixel(rightSideBot[0], rightSideBot[1]) != backGround)
            {
                mc.p[0].onWallRight = true;
            }
            else
            {
                mc.p[0].onWallRight = false;
            }
        }

        private void CheckInAir()
        {
            if (image.GetPixel(rightFoot[0], rightFoot[1]) != backGround || image.GetPixel(leftFoot[0], leftFoot[1]) != backGround)
            {
                mc.p[0].inAir = false;
            }
            else
            {
                mc.p[0].inAir = true;
            }
        }
    }
}