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
using ExtremeSteakDude.Model;
using ExtremeSteakDude.Serialization;
using ExtremeSteakDude.ViewModel;

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
        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            //Show main menu screen
            this.Content = new MainMenu();
            e.Handled = true;
            //
        }
    }
}
