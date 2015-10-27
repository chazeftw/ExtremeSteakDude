using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    class Player
    {
        int x { get; set; }
        int y { get; set; }
        int vx { get; set; }
        int vy { get; set; }

        public Player(int x, int y, int vx,int vy)
        {
            // position
            this.x = x;
            this.y = y;
            // vectors
            this.vx = vx;
            this.vy = vy;
        }
    }
}
