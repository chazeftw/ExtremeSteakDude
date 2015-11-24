using ExtremeSteakDude.Commands;
using ExtremeSteakDude.Model;
using ExtremeSteakDude.Serialization;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace ExtremeSteakDude.ViewModel
{

    public class MainViewModel
    {

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        public HighScores highScores { get; set; }
        public ICommand SaveHighscore { get; }
        private string _welcomeTitle = string.Empty;
        public string name {get; set;}

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                _welcomeTitle = value;
            }
        }

        public MainViewModel() {

            
            XML xml = new XML();
            highScores = xml.HighScores;


            SaveHighscore = new RelayCommand(SaveHighScore);
        }

        private void SaveHighScore()
        {
            SaveHighScoreCommand Command = new SaveHighScoreCommand(highScores, new XML(), name, 0);
            Command.Execute();
        }
    }
}