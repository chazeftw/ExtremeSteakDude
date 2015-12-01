using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class NewPlayerCommandLVL2 : IUndoRedoCommand
    {
        private ObservableCollection<Player> players;


        public NewPlayerCommandLVL2(ObservableCollection<Player> players)
        {
            this.players = players;
            Player.level = Player.levelenum.two;
        }

        public void Execute()
        {
            this.players[0] = new Player();
            Console.WriteLine("NEW PLAYER");
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
