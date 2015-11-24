using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    abstract class MapNew
    {
        
        public int startX { get; set; }

        public int startY { get; set; }

        public Bitmap image { get; set; }

        public List<Rectangle> objects()
        {
            throw new NotImplementedException();
        }
    }
}
