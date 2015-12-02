using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class DeathCommand : IUndoRedoCommand
    {
        public void Execute()
        {
            var gow = App.Current.MainWindow as MainWindow;
            View.GameOverScreen gameover = new View.GameOverScreen();
            gow.Content = gameover;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
