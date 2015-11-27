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

        
        


        public ICommand SaveHighscoreCommand { get; }
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
            System.Console.WriteLine("HEY");
            name = "Erir";
            players = new ObservableCollection<Player>();
            player = new Player();
            players.Add(player);
            mc = new MovementController(player);
            
            KeyDownCommand = new RelayCommand<KeyEventArgs>(KeyDown);
            KeyUpCommand = new RelayCommand<KeyEventArgs>(KeyUp);

            XML xml = new XML();
            highScores = new ObservableCollection<Model.HighScores>();
            highScores.Add(xml.HighScores);


            SaveHighscoreCommand = new RelayCommand(SaveHighScore);

            

        }

        private void SaveHighScore()
        {
            Console.WriteLine("HEYsa");
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