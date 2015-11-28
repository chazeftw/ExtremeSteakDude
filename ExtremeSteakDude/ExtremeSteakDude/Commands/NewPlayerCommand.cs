using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class NewPlayerCommand : IUndoRedoCommand
    { 
        private ObservableCollection<Player> players;


        public NewPlayerCommand(ObservableCollection<Player> players)
        {
            this.players = players;
        }

        public void Execute()
        {
            this.players[0] = new Player();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
