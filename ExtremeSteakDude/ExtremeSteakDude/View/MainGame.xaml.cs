﻿using System.Windows.Controls;
using System.Windows.Input;
using ExtremeSteakDude.Model;
using ExtremeSteakDude.ViewModel;
using System;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace ExtremeSteakDude.View
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : UserControl
    {


        private MovementController mc;
        private Player p;
        public MainGame()
        {
            DataContext = p = new Player();
            mc = new MovementController(p);
            
            InitializeComponent();
        }

        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this);
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            System.Console.WriteLine("Hello");
            switch (e.Key)
            {
                case Key.Enter:
                    System.Console.WriteLine("dasdsdfgh"); p.x = 200;
                    break;
                case Key.Left:
                    mc.moveLeft = true;
                    break;
                case Key.Right:
                    mc.moveRight = true;
                    break;
                case Key.Space:
                    mc.jump = true;
                    BitmapImage bm = new BitmapImage(new Uri("/ExtremeSteakDude;component/Levels/meatboyjump.jpg", UriKind.RelativeOrAbsolute));
                    player.Source = bm;
                    break;
                case Key.Z:
                    mc.isUndoMode = !mc.isUndoMode;
                    break;
            }
        }

        private void Window_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
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
                    BitmapImage bm = new BitmapImage(new Uri("/ExtremeSteakDude;component/Levels/meatboy.jpg", UriKind.RelativeOrAbsolute));
                    player.Source = bm;
                    break;
            }
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }


    }
