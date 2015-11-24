using ExtremeSteakDude.Model;
using ExtremeSteakDude.Serialization;
using GalaSoft.MvvmLight;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;

namespace ExtremeSteakDude.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        public HighScores highScores { get; set; }

        private MovementController mc;
        public ObservableCollection<Player> players { get; set; }
        public Player player;
        private BitmapImage map;

        public ICommand KeyDownCommand { get; }
        public ICommand KeyUpCommand { get; }



        private string _welcomeTitle = string.Empty;   

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


            players = new ObservableCollection<Player>();
            player = new Player();
            players.Add(player);
            mc = new MovementController(player);
            
            KeyDownCommand = new RelayCommand<KeyEventArgs>(KeyDown);
            KeyUpCommand = new RelayCommand<KeyEventArgs>(KeyUp);

            XML xml = new XML();
            highScores = xml.HighScores;
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
                    break;
                case Key.Right:
                    mc.moveRight = true;
                    break;
                case Key.Space:
                    mc.jump = true;
                    // For jump animation
                    BitmapImage bm = new BitmapImage(new Uri(player.MeatboyImageJump, UriKind.RelativeOrAbsolute));
                    player.meatboyImage = player.MeatboyImageJump;
                    break;
                case Key.Z:
                    mc.isUndoMode = !mc.isUndoMode;
                    break;
            }
        }

        private void KeyUp(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    mc.moveLeft = false;
                    break;
                case Key.Right:
                    mc.moveRight = false;
                    break;
                case Key.Space:
                    mc.jump = false;
                    // For jump animation
                    BitmapImage bm = new BitmapImage(new Uri(player.MeatboyImageJump, UriKind.RelativeOrAbsolute));
                    player.meatboyImage = player.MeatboyImage;
                    break;
            }
        }
        



    }
}