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
    class ContinueCommand : IUndoRedoCommand
    {
        private XML xML;
        private ObservableCollection<Player> players;


        public ContinueCommand(ObservableCollection<Player> players, XML xML)
        {
            this.players = players;
            this.xML = xML;
        }

        public ContinueCommand()
        {
        }

        public void Execute()
        {
            players[0] = xML.Player;

            var main = App.Current.MainWindow as MainWindow;
            View.MainGame mg = new View.MainGame(players[0].level);
            main.Content = mg;
            
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
