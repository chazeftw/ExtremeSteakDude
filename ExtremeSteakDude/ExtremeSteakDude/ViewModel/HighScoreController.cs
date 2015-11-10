using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Serialization;
using System.IO;

namespace ExtremeSteakDude.ViewModel
{
    public class HighScoreController
    {
        private XmlSerializer ser = new XmlSerializer(typeof(DataSet));
        private DataSet _HighScores;

        public HighScoreController()
        {
            // Creates a DataSet; adds a table, two columns, and two rows.
            DataSet ds = new DataSet("Data");
            DataTable t = new DataTable("HighScores");
            DataColumn c0 = new DataColumn("Names");
            DataColumn c1 = new DataColumn("Scores");
            t.Columns.Add(c0);
            t.Columns.Add(c1);
            ds.Tables.Add(t);

            DataRow r;

            r = t.NewRow();
            r[0] = "Martin ";
            r[1] = 33;
            t.Rows.Add(r);

            r = t.NewRow();
            r[0] = "Rasmus ";
            r[1] = 300;
            t.Rows.Add(r);

            TextWriter writer = new StreamWriter("Highscores");
            ser.Serialize(writer, ds);
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
    }
}
