using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    public class Map
    {
        // Path of map image
        String path;
        // Start coordinates for player on this map
        public int startX {get;}
        public int startY { get; }

        public Map(String path, int startX, int startY)
        {
            this.path = path;
            this.startX = startX;
            this.startY = startY;
        }
    }
}
