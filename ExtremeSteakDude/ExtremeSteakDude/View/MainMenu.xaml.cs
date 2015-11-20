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

        private void HighScore_Click(object sender, RoutedEventArgs e)
        {
            // Show highscores
            this.Content = new HighScores();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Exit the app
            System.Environment.Exit(0);
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            // Level select screen
            this.Content = new LevelSelect();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {

            //Show Enter highscore screen
            this.Content = new NewHighscore();
            e.Handled = true;
            //
        }
    }
}
