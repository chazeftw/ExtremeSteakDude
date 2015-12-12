using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtremeSteakDude.Serialization;
using ExtremeSteakDude.Model;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHighScoreXML()
        {
            HighScores high = new HighScores();
            Player player = new Player();
            XML xml= new XML();

            high.Name1 = "PLayer 1";
            high.Name2 = "PLayer 2";

            high.Score1 = long.MaxValue;
            high.Score2 = long.MinValue;

            xml.HighScores = high;
            Assert.AreEqual(xml.HighScores.Name1, high.Name1);
            Assert.AreEqual(xml.HighScores.Name2, high.Name2);
            Assert.AreEqual(xml.HighScores.Score1, high.Score1);
            Assert.AreEqual(xml.HighScores.Score2, high.Score2);

            Assert.AreEqual(xml.HighScores.Name, high.Name);
            Assert.AreEqual(xml.HighScores.Score, high.Score);

            Assert.AreEqual(xml.HighScores.nice1, high.nice1);
            Assert.AreEqual(xml.HighScores.nice2, high.nice2);
        }
        public void TestPlayerXML()
        {
            HighScores high = new HighScores();
            Player player = new Player();
            XML xml = new XML();
            player.alive = false;
            player.onWallRight = true;
            xml.Player = player;

            Assert.Equals(xml.Player.alive, player.alive);
            Assert.Equals(xml.Player.onWallRight, player.onWallRight);
        }
    }
}
