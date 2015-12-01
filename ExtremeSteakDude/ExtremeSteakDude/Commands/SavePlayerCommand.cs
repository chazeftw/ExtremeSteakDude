using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExtremeSteakDude.Model;
using ExtremeSteakDude.Serialization;

namespace ExtremeSteakDude.Commands
{
    class SavePlayerCommand : IUndoRedoCommand
    {
        private XML xML;
        private ObservableCollection<Player> players;


        public SavePlayerCommand(ObservableCollection<Player> players, XML xML)
        {
            this.players = players;
            this.xML = xML;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute()
        {
            xML.Player = players[0];
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
