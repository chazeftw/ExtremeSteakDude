﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtremeSteakDude.Model;
using System.Drawing;
using ExtremeSteakDude.Constants;

namespace ExtremeSteakDude.ViewModel
{

    class CollisionDetector
    {
        MovementController mc;
        MapNew map;
        Rectangle playerRec = new Rectangle(0, 0, Constants.Const.PLAYERHEIGHT, Constants.Const.PLAYERWIDTH);

    public CollisionDetector(MovementController mc,MapNew map)
        {
            this.map = map;
            this.mc = mc;
            playerRec.X = mc.p[0].x ;
            playerRec.Y = mc.p[0].y;
        }

    
        //Checks for collision with normal objects, lethal objects and win object. Sets players own variables accordingly
    public void CheckForCollision()
        {
            //Check for win
            

            // Creating a rectangle representation of the player, to check for collision with other rectangle objects
            playerRec.X = mc.p[0].x;
            playerRec.Y = mc.p[0].y;
            playerRec.Height = Constants.Const.PLAYERHEIGHT;
            playerRec.Width = Constants.Const.PLAYERWIDTH;

            

            if (map.goal.IntersectsWith(playerRec))
            {
                mc.p[0].won = true;
                return;
            }

            bool topleft = false;
            bool topright = false;
            bool botleft = false;
            bool botright = false;

            foreach (Rectangle r in map.lethalObjects)
            {
                // checking if players corners are in lethal objects
                if (r.Contains(playerRec.Left, playerRec.Top))
                    topleft = true;
                if (r.Contains(playerRec.Right, playerRec.Top))
                    topright = true;
                if (r.Contains(playerRec.Left, playerRec.Bottom))
                    botleft = true;
                if (r.Contains(playerRec.Right, playerRec.Bottom))
                    botright = true;
                if(topleft || topright || botleft || botright)
                {
                    mc.p[0].alive = false;
                    topleft = false;
                    topright = false;
                    botleft = false;
                    botright = false;

                    return;
                }
                topleft = false;
                topright = false;
                botleft = false;
                botright = false;
            }

            // adding players vectors to squared coordinate, to check for the next frame, so that player doesn't end up stuck in an object
            playerRec.X += mc.p[0].vx;
            playerRec.Y += mc.p[0].vy;

            foreach (Rectangle r in map.objectorinos)
            {
                // checking if players corners are in objects
                if (r.Contains(playerRec.Left, playerRec.Top))
                    topleft = true;
                if (r.Contains(playerRec.Right, playerRec.Top))
                    topright = true;
                if (r.Contains(playerRec.Left, playerRec.Bottom))
                    botleft = true;
                if (r.Contains(playerRec.Right, playerRec.Bottom))
                    botright = true;
                
            }
            //Setting players parameters accordingly
            if (botright && botleft)
                mc.p[0].inAir = false;
            else
                mc.p[0].inAir = true;
            if (botright && topright)
                mc.p[0].onWallRight = true;
            else
                mc.p[0].onWallRight = false;
            if (botleft && topleft)
                mc.p[0].onWallLeft = true;
            else
                mc.p[0].onWallLeft = false;
            if (topright && botright)
                mc.p[0].hitRoof = true;
            else
                mc.p[0].hitRoof = false;

            GC.Collect();
        }

        
    }
}
