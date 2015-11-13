using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace ExtremeSteakDude.Model
{
    interface IMapNew
    {
        int startX { get; set; }
        int startY { get; set;}
        List<Rectangle> objects();
    }
}
