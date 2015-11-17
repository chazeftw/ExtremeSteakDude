﻿using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Constants
{
    static class Const
    {
        public static readonly int HEIGHT = 720;
        public static readonly int WIDTH = 1280;
        public static readonly int[] DEF_STARTPOS = { 100, 400 };
        public static readonly Map[] MAP =
            {
            new Map("Levels/level_1_1.bmp", 0,0)
            };
    }
}