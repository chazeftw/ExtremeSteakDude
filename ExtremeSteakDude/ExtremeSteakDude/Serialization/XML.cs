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
     private XmlSerializer ser = new XmlSerializer(typeof(HighScores));


     public HighScores HighScores {
         get { return Deserialize(); }
         set { Serialize(value); }
     }
     private void Serialize(HighScores value)
     {
         TextWriter writer = new StreamWriter("Highscores.xml");
         ser.Serialize(writer, value);
         writer.Close();
     }

     private HighScores Deserialize()
     {
         // Construct an instance of the XmlSerializer with the type
         // of object that is being deserialized.
         XmlSerializer mySerializer =
         new XmlSerializer(typeof(HighScores));
            // To read the file, create a FileStream.
            try {
                System.Console.WriteLine(Directory.GetCurrentDirectory().ToString());
                FileStream myFileStream =
                new FileStream(Directory.GetCurrentDirectory().ToString() + "\\Highscores.xml", FileMode.Open);

                HighScores hs = (HighScores)mySerializer.Deserialize(myFileStream);

                myFileStream.Close();
                // Call the Deserialize method and cast to the object type.
                return hs;
            }
            catch(FileNotFoundException)
            {   
                var myFile = File.Create(Directory.GetCurrentDirectory().ToString() + "Highscores.xml");
                myFile.Close();
                Serialize(new HighScores());
                return new HighScores();
            }

     }
     
    }
}
