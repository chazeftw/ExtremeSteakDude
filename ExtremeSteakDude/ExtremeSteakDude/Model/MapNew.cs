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
        
        public int startX { get; }

        public int startY { get; }

        public Bitmap image { get; }

        public List<Rectangle> objects()
        {
            throw new NotImplementedException();
        }
    }
}
