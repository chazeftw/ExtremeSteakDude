using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Serialization;
using System.IO;

using System.Windows.Media;

namespace ExtremeSteakDude.Model
{
    public class HighScores : NotifyBase
    {


        private  String _Name1="Dankmeister";
        private  int _Score1 = 3; 
        private  String _Name2 = "Eirik";
        private  int _Score2 = 2;


        public string Name
        {
            get {
                switch (Player.level)
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
                switch (Player.level)
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
        public int Score
        {
            get
            {
                switch (Player.level)
                {
                    case Player.levelenum.one:
                        {
                            return _Score1;
                        }
                    case Player.levelenum.two:
                        {
                            return _Score2;
                        }

                }
                return 0;
            }
            set
            {
                switch (Player.level)
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
        public  int Score1 { get { return _Score2; } set { _Score1 = value; NotifyPropertyChanged(); } }
        public  int Score2 { get { return _Score2; } set { _Score2 = value; NotifyPropertyChanged(); } }
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