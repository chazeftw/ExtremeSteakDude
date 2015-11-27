using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using ExtremeSteakDude.Constants;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ExtremeSteakDude.Levels
{
    class lvl2 : Model.MapNew
    {
        Graphics gr;

        public lvl2()
        {
            // Getting the background image
            

            Bitmap image = new Bitmap(Const.MAPWIDTH, Const.MAPHEIGHT);
            this.startX = Const.BORDER_THICKNESS+100;
            this.startY = Const.MAPHEIGHT-Const.PLAYERHEIGHT-Const.BORDER_THICKNESS;
            gr = Graphics.FromImage(image);
            Rectangle backGround = new Rectangle(0, 0, Const.MAPWIDTH, Const.MAPHEIGHT);
            System.Drawing.Image bg = System.Drawing.Image.FromFile("ExtremeSteakDude.Images.backgroundjpeg.jpg");
            gr.DrawImage(bg, backGround);

            //SolidBrush backgroundColor = new SolidBrush(Color.LavenderBlush);
            //gr.FillRectangle(backgroundColor, backGround);


            Rectangle ground = new Rectangle(Const.BORDER_THICKNESS, Const.MAPHEIGHT - 50 - Const.BORDER_THICKNESS, 475, 50);
            SolidBrush crimsonSeaBrush = new SolidBrush(Color.Crimson);
            gr.FillRectangle(crimsonSeaBrush, ground);
            objectorinos.Add(ground);
            Rectangle obstacle1 = new Rectangle(250,450, 200, 50);
            SolidBrush chocolateBrush = new SolidBrush(Color.Chocolate);
            gr.FillRectangle(chocolateBrush, obstacle1);
            objectorinos.Add(obstacle1);
            Rectangle obstacle2 = new Rectangle(525, Const.MAPHEIGHT-100, 50, 100);
            gr.FillRectangle(chocolateBrush, obstacle2);
            objectorinos.Add(obstacle2);
            Rectangle obstacle3 = new Rectangle(525, Const.MAPHEIGHT-150, 150, 50);
            gr.FillRectangle(chocolateBrush, obstacle3);
            objectorinos.Add(obstacle3);
            Rectangle obstacle4 = new Rectangle(750, 250, 150, 50);
            gr.FillRectangle(chocolateBrush, obstacle4);
            objectorinos.Add(obstacle4);
            Rectangle obstacle5 = new Rectangle(400, 1000, 175, 50);
            gr.FillRectangle(chocolateBrush, obstacle5);
            objectorinos.Add(obstacle5);
            Rectangle obstacle6 = new Rectangle(1000, 50, 50, 125);
            gr.FillRectangle(chocolateBrush, obstacle6);
            objectorinos.Add(obstacle6);
            Rectangle obstacle7 = new Rectangle(1000, 125, 150, 50);
            gr.FillRectangle(chocolateBrush, obstacle7);
            objectorinos.Add(obstacle7);

            //borders
            Rectangle[] borders = new Rectangle[4];
            borders[0] = new Rectangle(0, 0, Const.BORDER_THICKNESS, Const.MAPHEIGHT);
            borders[1] = new Rectangle(Const.MAPWIDTH - Const.BORDER_THICKNESS, 0, Const.BORDER_THICKNESS, Const.MAPHEIGHT);
            borders[2] = new Rectangle(0, 0, Const.MAPWIDTH, Const.BORDER_THICKNESS);
            borders[3] = new Rectangle(0, Const.MAPHEIGHT - Const.BORDER_THICKNESS, Const.MAPWIDTH, Const.BORDER_THICKNESS);
            SolidBrush black = new SolidBrush(Color.Black);
            gr.FillRectangles(black, borders);
            objectorinos.Add(borders[0]);
            objectorinos.Add(borders[1]);
            objectorinos.Add(borders[2]);
            objectorinos.Add(borders[3]);

            // goal
            this.goal = new Rectangle(1075, 75, 50, 50);
            SolidBrush goalBrush = new SolidBrush(Color.DarkGoldenrod);
            gr.FillRectangle(goalBrush, this.goal);

            // lethal objects
            Rectangle poisonousFloor = new Rectangle(575, Const.MAPHEIGHT - 50 - Const.BORDER_THICKNESS, 600, 50);
            SolidBrush poison = new SolidBrush(Color.DarkViolet);
            lethalObjects.Add(poisonousFloor);
            gr.FillRectangle(poison, poisonousFloor);

            this.image = image;


        }




    }
}
