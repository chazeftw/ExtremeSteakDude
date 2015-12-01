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
    public class ExitCommand : IUndoRedoCommand
    {
        /// <summary>
        /// Initializes a new instance of the ExitCommand class.
        /// </summary>
        public ExitCommand()
        {
        }

        public void Execute()
        {
            System.Environment.Exit(0);
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}