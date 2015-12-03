using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Model
{
    public class Player : INotifyPropertyChanged
    {
        private int _x = 0;
        private int _y = 0;
        public int startx;
        public int starty;
        public String stringTime { get; set; }
        private long _timeSpan;
        private string _meatboyImage = "pack://application:,,,/Images/meatboy_front.jpg";
        private levelenum _level = levelenum.one;
        private string _currentLevel;
        public String finalTime { get; set; } = "N/A";

        public enum levelenum { one, two };
        public levelenum level { get { return _level; } set { _level = value; OnPropertyChanged("currentLevel"); } }


        public string currentLevel
        {
            get
            {
                if (level == levelenum.one)
                {
                    return "pack://application:,,,/Levels/level_1_1.jpg";
                }
                else
                {
                    return "pack://application:,,,/Levels/level_1_2.jpg";
                }
            }
            set
            {
                _currentLevel = value;
            }
        }
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

        public string MeatboyImageFront
        {
            get { return "pack://application:,,,/Images/meatboy_front.jpg"; }
        }

        public string MeatboyImageRight
        {
            get { return "pack://application:,,,/Images/meatboy.jpg"; }
        }

        public string MeatboyImageLeft
        {
            get { return "pack://application:,,,/Images/meatboy_invert.jpg"; }
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

        public long timeSpan
        {
            get { return _timeSpan; }
            set
            {
                if(value !=  _timeSpan)
                {
                    _timeSpan = value;
                    stringTime = ("" + (new TimeSpan(_timeSpan)).Minutes + ":" + (new TimeSpan(_timeSpan)).Seconds + ":" + (new TimeSpan(_timeSpan)).Milliseconds);
                    OnPropertyChanged("stringTime");
                }
            }
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
        public void setTimeElapsed(long time)
        {
            _timeSpan = time;
           // stringTime = ("" + time.Minutes+":"+time.Seconds+":"+time.Milliseconds);
            stringTime = ("" + (new TimeSpan(time)).Duration().ToString(@"mm\:ss\:ff"));
            OnPropertyChanged("stringTime");
        }

        // vectors
        public int vx { get; set; } = 0;
        public int vy { get; set; } = 0;

        public bool inAir { get; set; } = false;
        public bool onWallRight { get; set; } = false;
        public bool onWallLeft { get; set; } = false; 
        public bool hitRoof { get; set; } = false;
        public bool alive { get; set; } = true;
        public bool won { get; set; } = false;
        public bool top { get; set; } = false;

       
    }
}
