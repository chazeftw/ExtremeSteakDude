using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        public CDC(MovementController mc, MapNew map)
        {
            image = map.image;
            this.mc = mc;
            backGround = image.GetPixel(200,200);

        }

        public void check()
        {
            rightFoot[0] = mc.p.x + 30 + mc.p.vx;
            rightFoot[1] = mc.p.y + 32 + mc.p.vy;
            leftFoot[0] = mc.p.x + 1 + mc.p.vx;
            leftFoot[1] = mc.p.y + 32 + mc.p.vy;

            leftSideTop[0] = mc.p.x - 1 + mc.p.vx;
            leftSideTop[1] = mc.p.y + 1 + mc.p.vy;
            leftSideBot[0] = mc.p.x - 1 + mc.p.vx;
            leftSideBot[1] = mc.p.y + 30 + mc.p.vy;

            rightSideTop[0] = mc.p.x + 32 + mc.p.vx;
            rightSideTop[1] = mc.p.y + 1 + mc.p.vy;
            rightSideBot[0] = mc.p.x + 32 + mc.p.vx;
            rightSideBot[1] = mc.p.y + 30 + mc.p.vy;

            rightTop[0] = mc.p.x + mc.p.vx;
            rightTop[1] = mc.p.y - 1 + mc.p.vy;
            leftTop[0] = mc.p.x + 32 + mc.p.vx;
            leftTop[1] = mc.p.y - 1 + mc.p.vy;


            if (image.GetPixel(rightFoot[0], rightFoot[1]) != backGround || image.GetPixel(leftFoot[0], leftFoot[1]) != backGround)
            {
                mc.p.inAir = false;
            }else
            {
                mc.p.inAir = true;
            }
            if (image.GetPixel(rightSideTop[0],rightSideTop[1]) != backGround || image.GetPixel(rightSideBot[0], rightSideBot[1]) != backGround)
            {
                mc.p.onWallRight = true;
            }else
            {
                mc.p.onWallRight = false;
            }
            if (image.GetPixel(leftSideTop[0], leftSideTop[1]) != backGround || image.GetPixel(leftSideBot[0], leftSideBot[1]) != backGround)
            {
                mc.p.onWallLeft = true;
            }else
            {
                mc.p.onWallLeft = false;
            }
            if(image.GetPixel(leftTop[0],leftTop[1]) != backGround || image.GetPixel(rightTop[0],rightTop[1]) != backGround)
            {
                mc.p.top = true;
            }else
            {
                mc.p.top = false;
            }

            if (mc.p.onWallLeft && mc.p.onWallRight)
            {
                int i = 0;
                while (image.GetPixel(leftSideBot[0], leftSideBot[1]) != backGround && image.GetPixel(rightSideBot[0], rightSideBot[1]) != backGround)
                {
                    leftSideBot[1]--;
                    rightSideBot[1]--;
                    i++;
                }
                mc.p.vy = mc.p.vy - i;
            } else if (mc.p.top && !mc.p.inAir)
            {
                if (mc.p.onWallLeft)
                {
                    int i = 0;
                    while (image.GetPixel(leftTop[0], leftTop[1]) != backGround && image.GetPixel(leftFoot[0], leftFoot[1]) != backGround)
                    {
                        leftTop[0]++;
                        leftFoot[0]++;
                        i++;
                    }
                    mc.p.vx = mc.p.vx + i;
                }
                else if (mc.p.onWallRight)
                {
                    int i = 0;
                    while (image.GetPixel(leftTop[0], leftTop[1]) != backGround && image.GetPixel(leftFoot[0], leftFoot[1]) != backGround)
                    {
                        rightTop[0]--;
                        rightFoot[0]--;
                        i--;
                    }
                    mc.p.vx = mc.p.vx - i;
                }

            } else if (image.GetPixel(leftSideTop[0], leftSideTop[1]) != backGround || image.GetPixel(rightSideTop[0], rightSideTop[1]) != backGround)
            {
                int i = 0;
                while (image.GetPixel(leftSideTop[0], leftSideTop[1]) != backGround && image.GetPixel(rightSideTop[0], rightSideTop[1]) != backGround)
                {
                    leftSideTop[1]++;
                    rightSideTop[1]++;
                    i++;
                }
                mc.p.vy = mc.p.vy + i;
            }
        }
    }
}
