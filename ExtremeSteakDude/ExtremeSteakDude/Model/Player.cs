using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    static class Player
    {
        // position
        public static int x { get; set; }
        public static int y { get; set; }

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
