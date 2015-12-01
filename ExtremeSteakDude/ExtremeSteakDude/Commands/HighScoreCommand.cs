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

            XML xML = new XML();
            foreach (Window window in Application.Current.Windows)
            {
                window.Content = new View.HighScores();
            }
            
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}