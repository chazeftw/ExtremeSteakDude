using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    public class Player
    {
        public enum levelenum { one, two };
        private levelenum _level = levelenum.one;
        public levelenum level
        {
            get; set;
        }
        // position
        public int x { get; set; } = 596;
        public int y { get; set; } = 298;


        // vectors
        public int vx { get; set; } = 0;
        public int vy { get; set; } = 0;

        public bool inAir { get; set; } = false;
        public bool onWallRight { get; set; } = false;
        public bool onWallLeft { get; set; } = false;

        
    }
}
