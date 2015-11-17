using System.Windows.Controls;
using System.Windows.Input;
using ExtremeSteakDude.Model;
using ExtremeSteakDude.ViewModel;

namespace ExtremeSteakDude.View
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : UserControl
    {

        public Player p { get; set; }
        private MovementController mc;

        public MainGame()
        {

            DataContext = p = new Player();
            mc = new MovementController(p);

            InitializeComponent();
            
            
            
        }

       

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
