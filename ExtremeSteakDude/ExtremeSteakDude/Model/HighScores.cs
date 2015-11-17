using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Serialization;
using System.IO;

namespace ExtremeSteakDude.Model
{
    public class HighScores
    {


        private String _Name1="Dankmeister";
        private int _Score1=2; 
        private String _Name2;
        private int _Score2;
        public enum levelenum {one, two };
        private levelenum _level = levelenum.one;
        public levelenum level
        {
            get; set;
        }


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
                switch (_level)
                {
                    case levelenum.one:
                        {
                            _Name1 = value;
                            break;
                        }
                    case levelenum.two:
                        {
                            _Name2 = value;
                            break;
                        }

                }
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
                            break;
                        }
                    case Player.levelenum.two:
                        {
                            _Score2 = value;
                            break;
                        }

                }
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