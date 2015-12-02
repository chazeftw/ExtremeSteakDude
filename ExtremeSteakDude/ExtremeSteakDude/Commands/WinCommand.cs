using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class WinCommand : IUndoRedoCommand
    {
        public void Execute()
        {
            var hswin = App.Current.MainWindow as MainWindow;
            View.NewHighscore newhs = new View.NewHighscore();
            hswin.Content = newhs;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
