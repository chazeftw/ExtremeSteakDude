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
using System.Windows.Shapes;
using ExtremeSteakDude.Model;

namespace ExtremeSteakDude.ViewModel
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public Player Player { get; set; }

        public TestWindow()
        {
            InitializeComponent();

            DataContext = Player = new Player();
        }

        MovementController mc = new MovementController(new Player());

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: mc.moveLeft = true; break;
                case Key.Right: mc.moveRight = true; break;
                case Key.Space: mc.jump = true; break;
                case Key.Z: mc.isUndoMode = !mc.isUndoMode; break;
            }
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: mc.moveLeft = false; break;
                case Key.Right: mc.moveRight = false; break;
                case Key.Space: mc.jump = false; break;
            }
        }
    }
}
