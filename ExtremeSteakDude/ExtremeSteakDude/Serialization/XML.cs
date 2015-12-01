using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExtremeSteakDude.Serialization
{
    class XML
    {
     private XmlSerializer serH = new XmlSerializer(typeof(HighScores));
     private XmlSerializer serP = new XmlSerializer(typeof(Player));


        public HighScores HighScores {
         get { return DeserializeH(); }
         set { SerializeH(value); }
     }

        public Player Player {
            get { return DeserializeP(); }
            set { SerializeP(value); } }

        private void SerializeH(HighScores value)
     {
         TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory().ToString() + "\\Highscores.xml");
         serH.Serialize(writer, value);
         writer.Close();
     }

        private void SerializeP(Player value)
        {
            TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory().ToString() + "\\Player.xml");
            serP.Serialize(writer, value);
            writer.Close();
        }

        private HighScores DeserializeH()
     {
         // Construct an instance of the XmlSerializer with the type
         // of object that is being deserialized.
         XmlSerializer mySerializer = new XmlSerializer(typeof(HighScores));
            // To read the file, create a FileStream.
            try {
                FileStream myFileStream =
                new FileStream(Directory.GetCurrentDirectory().ToString() + "\\Highscores.xml", FileMode.Open);

                HighScores hs = (HighScores)mySerializer.Deserialize(myFileStream);

                myFileStream.Close();
                // Call the Deserialize method and cast to the object type.
                return hs;
            }
            catch(FileNotFoundException)
            {   
                var myFile = File.Create(Directory.GetCurrentDirectory().ToString() + "\\Highscores.xml");
                myFile.Close();
                SerializeH(new HighScores());
                return new HighScores();
            }

     }

        private Player DeserializeP()
        {
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(Player));
            // To read the file, create a FileStream.
            try
            {
                FileStream myFileStream =
                new FileStream(Directory.GetCurrentDirectory().ToString() + "\\Player.xml", FileMode.Open);
                Player p;
                 p = (Player)mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
                // Call the Deserialize method and cast to the object type.
                return p;
            }
            catch (FileNotFoundException)
            {
                var myFile = File.Create(Directory.GetCurrentDirectory().ToString() + "\\Player.xml");
                myFile.Close();
                SerializeP(new Player());
                return new Player();
            }

        }

    }
}
