using ExtremeSteakDude.Model;
using ExtremeSteakDude.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class LoadPlayerCommand : IUndoRedoCommand
    {
        private XML xML;
        private ObservableCollection<Player> players;


        public LoadPlayerCommand(ObservableCollection<Player> players, XML xML)
        {
            this.players = players;
            this.xML = xML;
        }

        public void Execute()
        {
            players[0] = xML.Player;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
