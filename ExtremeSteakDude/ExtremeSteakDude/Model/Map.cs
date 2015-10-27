using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    class Map
    {
        // Path of map image
        String path;
        // Start coordinates for player on this map
        int startX, startY;

        public Map(String path, int startX, int startY)
        {
            this.path = path;
            this.startX = startX;
            this.startY = startY;
        }
    }
}
