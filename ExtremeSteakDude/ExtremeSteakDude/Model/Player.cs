using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    public class Player
    {
        // position
        public static int x { get; set; } = 596;
        public static int y { get; set; } = 298;
        

        // vectors
        public static int vx { get; set; }
        public static int vy { get; set; }

        public static bool inAir { get; set; }
        public static bool onWallRight { get; set; }
        public static bool onWallLeft { get; set; }

        internal static void Jump()
        {
            throw new NotImplementedException();
        }

    }
}
