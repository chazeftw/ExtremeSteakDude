using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    class NewPlayerCommandLVL1 : IUndoRedoCommand
    { 
        private ObservableCollection<Player> players;


        public NewPlayerCommandLVL1(ObservableCollection<Player> players)
        {
            this.players = players;
            Player.level = Player.levelenum.one;
        }

        public void Execute()
        {
            this.players[0] = new Player();
            Console.WriteLine("NEW PLAYER");

            var main = App.Current.MainWindow as MainWindow;
            View.MainGame mg = new View.MainGame(Player.levelenum.one);
            main.Content = mg;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
