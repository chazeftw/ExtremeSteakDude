using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class NewHighScoreCommand
    {
        /// <summary>
        /// Initializes a new instance of the HighScoreCommand class.
        /// </summary>
        public NewHighScoreCommand()
        {
        }

        public void Execute()
        {
            // Show highscores
            var main = App.Current.MainWindow as MainWindow;
            View.NewHighscore hs = new View.NewHighscore();
            main.Content = hs;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}