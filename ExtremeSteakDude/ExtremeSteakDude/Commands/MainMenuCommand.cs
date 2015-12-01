using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class MainMenuCommand : IUndoRedoCommand
    {
        /// <summary>
        /// Initializes a new instance of the HighScoreCommand class.
        /// </summary>
        public MainMenuCommand()
        {
        }

        public void Execute()
        {
            // Show highscores
            var main = App.Current.MainWindow as MainWindow;
            View.MainMenu hs = new View.MainMenu();
            main.Content = hs;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
