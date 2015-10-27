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

        private void HighScore_Click(object sender, RoutedEventArgs e)
        {
            // Hide the main menu buttons
            NewGame.Visibility = Visibility.Hidden;
            Continue.Visibility = Visibility.Hidden;
            HighScore.Visibility = Visibility.Hidden;
            Exit.Visibility = Visibility.Hidden;

            // Show highscores

        }
    }
}