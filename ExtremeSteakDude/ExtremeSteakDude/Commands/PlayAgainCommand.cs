using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtremeSteakDude.Model;
using System.Collections.ObjectModel;

namespace ExtremeSteakDude.Commands
{
    class PlayAgainCommand
    {
        private ObservableCollection<Player> players;

        public PlayAgainCommand(ObservableCollection<Player> players)
        {
            this.players = players;
        }

        public void Execute()
        {
            if (players[0].level == Player.levelenum.one)
            {
                this.players[0].x = 50;
                this.players[0].y = 483;
                var main = App.Current.MainWindow as MainWindow;
                View.MainGame mg = new View.MainGame(Player.levelenum.one);
                main.Content = mg;
            }
            else if(players[0].level == Player.levelenum.two)
            {
                this.players[0].x = 34;
                this.players[0].y = 590;
                players[0].level = Player.levelenum.two;

                var main = App.Current.MainWindow as MainWindow;
                View.MainGame mg = new View.MainGame(Player.levelenum.two);
                main.Content = mg;
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
