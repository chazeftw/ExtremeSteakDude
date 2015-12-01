using System;
using GalaSoft.MvvmLight;
using ExtremeSteakDude.Serialization;
using System.Windows;

namespace ExtremeSteakDude.Commands
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class HighScoreCommand : IUndoRedoCommand
    {
        /// <summary>
        /// Initializes a new instance of the HighScoreCommand class.
        /// </summary>
        public HighScoreCommand()
        {
        }

        public void Execute()
        {
            // Show highscores
            var main = App.Current.MainWindow as MainWindow;
            View.HighScores hs = new View.HighScores();
            main.Content = hs;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}