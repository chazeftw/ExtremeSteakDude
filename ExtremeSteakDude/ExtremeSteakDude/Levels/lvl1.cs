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

namespace ExtremeSteakDude.Levels
{
    class lvl1:Model.MapNew
    {
        //Graphics gr;

        public lvl1()
        {
            image = new Bitmap(ExtremeSteakDude.Properties.Resources.level_1_1);

            /*gr = Graphics.FromImage(image);
            Rectangle backGround = new Rectangle(0,0,Const.MAPWIDTH,Const.MAPHEIGHT);
            SolidBrush aliceBrush = new SolidBrush(Color.AliceBlue);
            gr.FillRectangle(aliceBrush, backGround);


            Rectangle ground = new Rectangle(Const.BORDER_THICKNESS, Const.MAPHEIGHT - 100-Const.BORDER_THICKNESS, Const.MAPWIDTH-Const.BORDER_THICKNESS*2, 100);
            SolidBrush darkSeaBrush = new SolidBrush(Color.DarkSeaGreen);
            gr.FillRectangle(darkSeaBrush, ground);
            objectorinos.Add(ground);
            Rectangle obstacle1 = new Rectangle(Const.MAPWIDTH / 2, Const.MAPHEIGHT - 150-Const.BORDER_THICKNESS, 25, 50);
            SolidBrush indianRedBrush = new SolidBrush(Color.IndianRed);
            gr.FillRectangle(indianRedBrush, obstacle1);
            objectorinos.Add(obstacle1);

            //borders
            Rectangle[] borders = new Rectangle[4];
            borders[0]= new Rectangle(0, 0, Const.BORDER_THICKNESS, Const.MAPHEIGHT);
            borders[1] = new Rectangle(Const.MAPWIDTH - Const.BORDER_THICKNESS, 0, Const.BORDER_THICKNESS, Const.MAPHEIGHT);
            borders[2] = new Rectangle(0, 0, Const.MAPWIDTH, Const.BORDER_THICKNESS);
            borders[3] = new Rectangle(0, Const.MAPHEIGHT - Const.BORDER_THICKNESS, Const.MAPWIDTH, Const.BORDER_THICKNESS);
            SolidBrush black = new SolidBrush(Color.Black);
            gr.FillRectangles(black, borders);
            objectorinos.Add(borders[0]);
            objectorinos.Add(borders[1]);
            objectorinos.Add(borders[2]);
            objectorinos.Add(borders[3]);

            //Goal
            this.goal = new Rectangle(Const.MAPWIDTH - 300, Const.MAPHEIGHT - 300, 50, 50);
            SolidBrush goalBrush = new SolidBrush(Color.Chartreuse);
            gr.FillRectangle(goalBrush, goal);
            this.image = image;*/

           
        }
        



    }
}
