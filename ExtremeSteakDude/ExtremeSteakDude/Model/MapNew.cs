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
        


        public Bitmap image { get; set; }

        public List<Rectangle> objectorinos = new List<Rectangle>();

        public List<Rectangle> lethalObjects = new List<Rectangle>();

        public Rectangle goal;
    }
}
