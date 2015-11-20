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
            this.Content = new MainGame();
            //this.Content = new LevelSelect();
        }
    }
}
