using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class LevelSelectCommand : IUndoRedoCommand
    {
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
