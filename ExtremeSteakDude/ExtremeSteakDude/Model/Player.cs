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


        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        // position
        public int x
        {
            get { return x; }
            set
            {
                if (value != x)
                {
                    x = value;
                    OnPropertyChanged("x");
                }
            }
        }
        public int y
        {
            get { return y; }
            set
            {
                if (value != y)
                {
                    y = value;
                    OnPropertyChanged("y");
                }
            }
        }


        // vectors
        public int vx { get; set; } = 0;
        public int vy { get; set; } = 0;

        public bool inAir { get; set; } = false;
        public bool onWallRight { get; set; } = false;
        public bool onWallLeft { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
