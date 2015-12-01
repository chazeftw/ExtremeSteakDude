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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExtremeSteakDude.Serialization;
using ExtremeSteakDude.Model;

namespace ExtremeSteakDude.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        /*private void HighScore_Click(object sender, RoutedEventArgs e)
        {
            // Show highscores
            XML xML = new XML();
            this.Content = new View.HighScores();
            e.Handled = true;
        }*/

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Command.Execute(btn.CommandParameter);
            
            this.Content = new LevelSelect();
            e.Handled = true;
            
        }
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            //Show Enter highscore screen
            this.Content = new NewHighscore();
            e.Handled = true;
            //
        }
    }
}