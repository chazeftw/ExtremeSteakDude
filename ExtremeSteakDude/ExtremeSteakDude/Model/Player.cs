using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    public class Player : INotifyPropertyChanged
    {
        private int _x = 500;
        private int _y = 300;
        private string _meatboyImage = "pack://application:,,,/Images/meatboy.jpg";
        public enum levelenum { one, two };
        public static levelenum level { get; set; }


        public string meatboyImage
        {
            get { return _meatboyImage; }
            set
            {
                if (value != _meatboyImage)
                {
                    _meatboyImage = value;
                    OnPropertyChanged("meatboyImage");
                }
            }
        }







        public string MeatboyImage
        {
            get { return "pack://application:,,,/Images/meatboy.jpg"; }
        }

        public string MeatboyImageJump
        {
            get { return "pack://application:,,,/Images/meatboyjump.jpg"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
            get { return _x; }
            set
            {
                if (value != _x)
                {
                    _x = value;
                    OnPropertyChanged("x");
                }
            }
        }
        public int y
        {
            get { return _y; }
            set
            {
                if (value != _y)
                {
                    _y = value;
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
        public bool hitRoof { get; set; } = false;


    }
}
