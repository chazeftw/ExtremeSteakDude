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

namespace ExtremeSteakDude.View
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class NewHighscore : UserControl
    {
        public NewHighscore()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
           SubmitHighscoreButton.Visibility = Visibility.Hidden;
            HighscoreNameInput.Visibility = Visibility.Hidden;
            EnterName.Visibility = Visibility.Hidden;
            NewHighscoreText.Visibility = Visibility.Hidden;
            DisplayHighscore.Visibility = Visibility.Hidden;
            SkipButton.Visibility = Visibility.Hidden;

            //Show Enter highscore screen
            this.Content = new MainMenu();
            e.Handled = true;
            //
        }
    }
}
