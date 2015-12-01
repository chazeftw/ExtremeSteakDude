using System;
using GalaSoft.MvvmLight;

namespace ExtremeSteakDude.Commands
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class NewGameCommand : IUndoRedoCommand
    {
        /// <summary>
        /// Initializes a new instance of the NewGameCommand class.
        /// </summary>
        public NewGameCommand()
        {
        }

        public void Execute()
        {
            var main = App.Current.MainWindow as MainWindow;
            View.LevelSelect ls = new View.LevelSelect();
            main.Content = ls;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}