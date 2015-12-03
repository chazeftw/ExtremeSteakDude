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
        private  long _Score1 = long.MaxValue; 
        private  String _Name2 = "Eirik";
        private  long _Score2 = long.MaxValue;
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
        public long Score
        {
            get
            {
                switch (players[0].level)
                {
                    case Player.levelenum.one:
                        {
                            return _Score1;
                        }
                    case Player.levelenum.two:
                        {
                            return _Score2;
                        }
                    default:
                        return long.MaxValue;
                }
                
            }
            set
            {
                switch (players[0].level)
                {
                    case Player.levelenum.one:
                        {
                            _Score1 = value;
                            NotifyPropertyChanged(() => Score1);
                            break;
                        }
                    case Player.levelenum.two:
                        {
                            _Score2 = value;
                            NotifyPropertyChanged(() => Score2);
                            break;
                        }

                }
                NotifyPropertyChanged();
            }
        }
        public  String Name1 { get { return _Name1; } set { _Name1 = value; NotifyPropertyChanged(); } }
        public  String Name2 {get { return _Name2; }set { _Name2 = value; NotifyPropertyChanged(); } }
        public  long Score1 { get { return _Score1; } set { _Score1 = value; NotifyPropertyChanged();  } }
        public long Score2 { get { return _Score2; } set { _Score2 = value; NotifyPropertyChanged(); } }

        public String nice1 { get { return ("" + (new TimeSpan(_Score1)).Duration().ToString(@"mm\:ss\:ff")); } }
        public String nice2 { get { return ("" + (new TimeSpan(_Score2)).Duration().ToString(@"mm\:ss\:ff")); } }

        public long getCurrentLvlHs()
        {
            switch (players[0].level)
            {
                case Player.levelenum.one:
                    return Score1;
                case Player.levelenum.two:
                    return Score2;
                default:
                    return long.MaxValue;
            }
        }
        
        
        
        /*
        private XmlSerializer ser = new XmlSerializer(typeof(DataSet));
        
        public HighScoreController()
        {
            // Creates a DataSet; adds a table, two columns, and two rows.

            TextWriter writer = new StreamWriter("Highscores");
           // ser.Serialize(writer, ds);
            writer.Close();
        }

        public DataSet lv1 {
            get { return Deserialize(); }
            set { Serialize(value); }
        }
        private void Serialize(DataSet value)
        {
            TextWriter writer = new StreamWriter("Highscores.xml");
            ser.Serialize(writer, value);
            writer.Close();
        }

        private DataSet Deserialize()
        {
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer =
            new XmlSerializer(typeof(DataSet));
            // To read the file, create a FileStream.
            FileStream myFileStream =
            new FileStream("Highscores.xml", FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            return (DataSet)mySerializer.Deserialize(myFileStream);
        }
        */
    }
}