using System.Windows;
using ExtremeSteakDude.ViewModel;

namespace ExtremeSteakDude
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(-1);
        }
    }
}