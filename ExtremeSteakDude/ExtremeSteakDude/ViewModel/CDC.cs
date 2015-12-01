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
        private Color backGround;

        public CDC(MovementController mc, MapNew map)
        {
            image = map.image;
            this.mc = mc;
            backGround = image.GetPixel(200,200);

        }

        public void check()
        {
            rightFoot[0] = mc.p[0].x + 30 + mc.p[0].vx;
            rightFoot[1] = mc.p[0].y + 32 + mc.p[0].vy;
            leftFoot[0] = mc.p[0].x + 1 + mc.p[0].vx;
            leftFoot[1] = mc.p[0].y + 32 + mc.p[0].vy;

            leftSideTop[0] = mc.p[0].x - 1 + mc.p[0].vx;
            leftSideTop[1] = mc.p[0].y + 1 + mc.p[0].vy;
            leftSideBot[0] = mc.p[0].x - 1 + mc.p[0].vx;
            leftSideBot[1] = mc.p[0].y + 30 + mc.p[0].vy;

            rightSideTop[0] = mc.p[0].x + 32 + mc.p[0].vx;
            rightSideTop[1] = mc.p[0].y + 1 + mc.p[0].vy;
            rightSideBot[0] = mc.p[0].x + 32 + mc.p[0].vx;
            rightSideBot[1] = mc.p[0].y + 30 + mc.p[0].vy;

            if (image.GetPixel(rightFoot[0], rightFoot[1]) != backGround || image.GetPixel(leftFoot[0], leftFoot[1]) != backGround)
            {
                mc.p[0].inAir = false;
            }else
            {
                mc.p[0].inAir = true;
            }
            if (image.GetPixel(rightSideTop[0],rightSideTop[1]) != backGround || image.GetPixel(rightSideBot[0], rightSideBot[1]) != backGround)
            {
                mc.p[0].onWallRight = true;
            }else
            {
                mc.p[0].onWallRight = false;
            }
            if (image.GetPixel(leftSideTop[0], leftSideTop[1]) != backGround || image.GetPixel(leftSideBot[0], leftSideBot[1]) != backGround)
            {
                mc.p[0].onWallLeft = true;
            }else
            {
                mc.p[0].onWallLeft = false;
            }

            
            if(mc.p[0].onWallLeft && mc.p[0].onWallRight)
            {
                int i = 0;
                while(image.GetPixel(leftSideBot[0], leftSideBot[1]) != backGround && image.GetPixel(rightSideBot[0], rightSideBot[1]) != backGround)
                {
                    leftSideBot[1]--;
                    rightSideBot[1]--;
                    i++;
                }
                mc.p[0].vy = mc.p[0].vy - i;
            }
            

        }
    }
}
