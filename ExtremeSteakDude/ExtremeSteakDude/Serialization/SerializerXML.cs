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
    public class SerializerXML
    {
        public static SerializerXML Instance { get; } = new SerializerXML();

        private SerializerXML() { }

        public async void AsyncSerializeToFile(HighScores highScores, string path)
        {
            await Task.Run(() => SerializeToFile(highScores, path));
        }

        private void SerializeToFile(HighScores highScores, string path)
        {
            using (FileStream stream = File.Create(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HighScores));
                serializer.Serialize(stream, highScores);
            }
        }

        public Task<HighScores> AsyncDeserializeFromFile(string path)
        {
            return Task.Run(() => DeserializeFromFile(path));
        }

        private HighScores DeserializeFromFile(string path)
        {
            using (FileStream stream = File.OpenRead(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HighScores));
                HighScores highScores = serializer.Deserialize(stream) as HighScores;

                return highScores;
            }
        }

        public Task<string> AsyncSerializeToString(HighScores highScores)
        {
            return Task.Run(() => SerializeToString(highScores));
        }

        private string SerializeToString(HighScores highScores)
        {
            var stringBuilder = new StringBuilder();

            using (TextWriter stream = new StringWriter(stringBuilder))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HighScores));
                serializer.Serialize(stream, highScores);
            }

            return stringBuilder.ToString();
        }

        public Task<HighScores> AsyncDeserializeFromString(string xml)
        {
            return Task.Run(() => DeserializeFromString(xml));
        }

        private HighScores DeserializeFromString(string xml)
        {
            using (TextReader stream = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HighScores));
                HighScores highScores = serializer.Deserialize(stream) as HighScores;

                return highScores;
            }
        }
    }
}
