using System.Windows.Controls;
using System.Windows.Input;
using ExtremeSteakDude.Model;
using ExtremeSteakDude.ViewModel;
using System;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using ExtremeSteakDude.Levels;
using ExtremeSteakDude.HelperClasses;

namespace ExtremeSteakDude.View
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : UserControl
    {
        MapNew currentlvl;

        public MainGame()
        {
            InitializeComponent();
        }
        public MainGame(Player.levelenum level)
        {
            if(level == Player.levelenum.one)
            {
                currentlvl = new lvl1();
                Player.level = Player.levelenum.one;
            }

            if(level == Player.levelenum.two)
            {
                currentlvl = new lvl2();
                Player.level = Player.levelenum.two;
            }
            BitmapImage bmi = new BitmapImage();
            bmi = HelperClasses.BitmapConverter.BitmapToImageSource(currentlvl.image);
            this.Background = new ImageBrush(bmi);
            InitializeComponent();



        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this);
        }



    }


}
