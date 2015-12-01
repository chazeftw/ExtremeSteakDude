using ExtremeSteakDude.Commands;
using ExtremeSteakDude.Model;
using ExtremeSteakDude.Serialization;
using GalaSoft.MvvmLight;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;
using ExtremeSteakDude.Levels;
using ExtremeSteakDude.View;
using System.Media;
using System.Windows.Media;
using System.Collections;

namespace ExtremeSteakDude.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        public ObservableCollection<Model.HighScores> highScores { get; set; }

        private MovementController mc;
        public ObservableCollection<Player> players { get; set; }
        public Player player;
        private BitmapImage map;
        public ICommand KeyDownCommand { get; }
        public ICommand KeyUpCommand { get; }

        public ICommand ContinueCommand { get; }

        public ICommand HighScoreCommand { get; }
        public ICommand ExitCommand { get; }

        public ICommand SaveHighscoreCommand { get; }
        public ICommand SavePlayerCommand { get; }

        public ICommand NewPlayerCommand { get; }
        public ICommand LoadPlayerCommand { get; }

        private string _welcomeTitle = string.Empty;
        public string name {get; set;}

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        /// 

       


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
            name = "Erir";

            XML xml = new XML();
            players = new ObservableCollection<Player>();
            player = xml.Player;
            players.Add(player);
            mc = new MovementController(players);
            
            KeyDownCommand = new RelayCommand<KeyEventArgs>(KeyDown);
            KeyUpCommand = new RelayCommand<KeyEventArgs>(KeyUp);

            
            highScores = new ObservableCollection<Model.HighScores>();
            highScores.Add(xml.HighScores);

            ContinueCommand = new RelayCommand(Continue);
            HighScoreCommand = new RelayCommand(HighScore);
            ExitCommand = new RelayCommand(Exit);
            SaveHighscoreCommand = new RelayCommand(SaveHighScore);
            SavePlayerCommand = new RelayCommand(SavePlayer);
            NewPlayerCommand = new RelayCommand(NewPlayer);
            LoadPlayerCommand = new RelayCommand(LoadPlayer);
        }

        private void Continue()
        {
            ContinueCommand Command = new ContinueCommand(players, xML);
            Command.Execute();
        }

        private void HighScore()
        {
            HighScoreCommand Command = new HighScoreCommand();
            Command.Execute();
        }

        private void Exit()
        {
            ExitCommand Command = new ExitCommand();
            Command.Execute();
        }

        private void LoadPlayer()
        {
            ContinueCommand Command = new ContinueCommand(players, new XML());
            Command.Execute();
        }
        private void NewPlayer()
        {
            NewPlayerCommand Command = new NewPlayerCommand(players);
            Command.Execute();
        }
        private void SavePlayer()
        {
            SavePlayerCommand Command = new SavePlayerCommand(players, new XML());
            Command.Execute();
        }

        private void SaveHighScore()
        {
            SaveHighScoreCommand Command = new SaveHighScoreCommand(highScores, new XML(), name, 0);
            Command.Execute();
        }

        private void KeyDown(KeyEventArgs e)
        {
            
            switch (e.Key)
            {
                case Key.Enter:
                    player = new Player();
                    break;
                case Key.Left:
                    mc.moveLeft = true;
                    //BitmapImage bm1 = new BitmapImage(new Uri(player.MeatboyImageInvert, UriKind.RelativeOrAbsolute));
                    player.meatboyImage = player.MeatboyImageLeft;
                    break;
                case Key.Right:
                    mc.moveRight = true;
                    player.meatboyImage = player.MeatboyImageRight;
                    break;
                case Key.Space:
                    mc.jump = true;
                    // For jump animation
                    //BitmapImage bm = new BitmapImage(new Uri(player.MeatboyImageJump, UriKind.RelativeOrAbsolute));
                    player.meatboyImage = player.MeatboyImageJump;

                    break;
                case Key.Z:
                    mc.isUndoMode = !mc.isUndoMode;
                    break;
                case Key.Escape:
                    // Save the game
                    // Save player position, timer, level, momemtum
                    SavePlayer();

                    // Go to main menu
                    //mc.isUndoMode = true;
                    var main = App.Current.MainWindow as MainWindow;
                    MainMenu mm = new MainMenu();
                    main.Content = mm;
                    break;
            }
        }

        private void KeyUp(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    mc.moveLeft = false;
                    player.meatboyImage = player.MeatboyImageLeft;
                    break;
                case Key.Right:
                    mc.moveRight = false;
                    player.meatboyImage = player.MeatboyImageRight;
                    break;
                case Key.Space:
                    mc.jump = false;
                    // For jump animation
                    player.meatboyImage = player.MeatboyImageFront;
                    break;
            }
        }
        



    }
}