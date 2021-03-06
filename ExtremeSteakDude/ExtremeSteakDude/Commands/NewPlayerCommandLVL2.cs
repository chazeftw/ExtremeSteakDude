﻿using ExtremeSteakDude.Model;
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
            players[0].level = Player.levelenum.two;
        }

        public void Execute()
        {
            this.players[0] = new Player();
            this.players[0].x = 34;
            this.players[0].y = 590;
            this.players[0].startx = 34;
            this.players[0].starty = 590;
            players[0].level = Player.levelenum.two;

            var main = App.Current.MainWindow as MainWindow;
            View.MainGame mg = new View.MainGame(Player.levelenum.two);
            main.Content = mg;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
