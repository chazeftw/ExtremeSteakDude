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

            
            if(mc.p.onWallLeft && mc.p.onWallRight)
            {
                int i = 0;
                while(image.GetPixel(leftSideBot[0], leftSideBot[1]) != backGround && image.GetPixel(rightSideBot[0], rightSideBot[1]) != backGround)
                {
                    leftSideBot[1]--;
                    rightSideBot[1]--;
                    i++;
                }
                mc.p.vy = mc.p.vy - i;
            }
            

        }
    }
}
