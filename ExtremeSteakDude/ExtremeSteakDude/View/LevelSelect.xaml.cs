using ExtremeSteakDude.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace ExtremeSteakDude.View
{
    /// <summary>
    /// Interaction logic for LevelSelect.xaml
    /// </summary>
    public partial class LevelSelect : UserControl
    {
        public LevelSelect()
        {
            InitializeComponent();
        }

        private void level1_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MainGame(Player.levelenum.one);
        }

        private void level2_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MainGame(Player.levelenum.two);
        }
    }
}
