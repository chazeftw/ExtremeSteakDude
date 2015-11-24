using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExtremeSteakDude.Model;
using ExtremeSteakDude.Serialization;

namespace ExtremeSteakDude.Commands
{
    class SaveHighScoreCommand
    {
        private HighScores highScores;
        private XML xML;
        private String name;
        private int score;



        public SaveHighScoreCommand(HighScores highScores, XML xML, String name, int score)
        {
            this.highScores = highScores;
            this.xML = xML;
            this.name = name;
            this.score = score;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute()
        {
            highScores.Name = name;
            highScores.Score = score;
            xML.HighScores = highScores;
        }
    }
}
