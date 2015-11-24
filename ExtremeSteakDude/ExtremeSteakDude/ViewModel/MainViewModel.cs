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
        public ObservableObject player { get; set; }
        private BitmapImage map;

        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }
        public ICommand JumpCommand { get; }
        public ICommand RedoModeCommand { get; }

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




            player = new Player();
            mc = new MovementController((Player) player);
            KeyDownCommand = new RelayCommand<KeyEventArgs>(KeyDown);
            KeyUpCommand = new RelayCommand<KeyEventArgs>(KeyUp);

            XML xml = new XML();
            highScores = xml.HighScores;
        }

        private void KeyDown(KeyEventArgs e)
        {

            System.Console.WriteLine("sdgfjgjhgf");
            switch (e.Key)
            {
                case Key.Enter:
                    System.Console.WriteLine("dasdsdfgh");
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
                    BitmapImage bm = new BitmapImage(new Uri("/ExtremeSteakDude;component/Levels/meatboyjump.jpg", UriKind.RelativeOrAbsolute));
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
                    BitmapImage bm = new BitmapImage(new Uri("/ExtremeSteakDude;component/Levels/meatboy.jpg", UriKind.RelativeOrAbsolute));
                   // player.Source = bm;
                    break;
            }
        }
        



    }
}