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

namespace ExtremeSteakDude.View
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : UserControl
    {

        public MainGame()
        {
            InitializeComponent();
            }
        public MainGame(Player.levelenum level)
            {
            InitializeComponent();
        }

        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this);
        }



    }


    }
