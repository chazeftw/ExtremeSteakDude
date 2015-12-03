using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Serialization;
using System.IO;

using System.Windows.Media;
using System.Collections.ObjectModel;

namespace ExtremeSteakDude.Model
{
    public class HighScores : NotifyBase
    {

        public ObservableCollection<Player> players;
        private  String _Name1="Dankmeister";
        private  long _Score1; 
        private  String _Name2 = "Eirik";
        private  long _Score2;
        private TimeSpan defaultTS = new TimeSpan(1, 0, 0);
        
        public HighScores()
        {
            players = new ObservableCollection<Player>();
            players.Add(new Player());
        }


        public string Name
        {
            get {
                switch (players[0].level)
                {
                    case Player.levelenum.one:
                        {
                            return _Name1;
                        }
                    case Player.levelenum.two:
                        {
                            return _Name2;
                        }
                        
                }
                return "";
            }
            set
            {
                switch (players[0].level)
                {
                    case Player.levelenum.one:
                        {
                            Console.WriteLine(value);
                            _Name1 = value;
                            NotifyPropertyChanged(() => Name2);
                            break;
                        }
                    case Player.levelenum.two:
                        {
                            _Name2 = value;
                            NotifyPropertyChanged(() => Name2);
                            break;
                        }

                }
                NotifyPropertyChanged();
            }
        }
        public TimeSpan Score
        {
            get
            {
                switch (players[0].level)
                {
                    case Player.levelenum.one:
                        {
                            return new TimeSpan(_Score1);
                        }
                    case Player.levelenum.two:
                        {
                            return new TimeSpan(_Score2);
                        }
                    default:
                        return defaultTS;
                }
                
            }
            set
            {
                switch (players[0].level)
                {
                    case Player.levelenum.one:
                        {
                            _Score1 = value.Ticks;
                            NotifyPropertyChanged(() => Score1);
                            break;
                        }
                    case Player.levelenum.two:
                        {
                            _Score2 = value.Ticks;
                            NotifyPropertyChanged(() => Score2);
                            break;
                        }

                }
                NotifyPropertyChanged();
            }
        }
        public  String Name1 { get { return _Name1; } set { _Name1 = value; NotifyPropertyChanged(); } }
        public  String Name2 {get { return _Name2; }set { _Name2 = value; NotifyPropertyChanged(); } }
        public  TimeSpan Score1 { get { return new TimeSpan(_Score1); } set { _Score1 = value.Ticks; NotifyPropertyChanged();  } }
        public  TimeSpan Score2 { get { return new TimeSpan(_Score2); } set { _Score2 = value.Ticks; NotifyPropertyChanged(); } }
       
        public TimeSpan getCurrentLvlHs()
        {
            switch (players[0].level)
            {
                case Player.levelenum.one:
                    return Score1;
                case Player.levelenum.two:
                    return Score2;
                default:
                    return defaultTS;
            }
        }
    }
}