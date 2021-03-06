﻿using System.Windows;
using ExtremeSteakDude.ViewModel;
using ExtremeSteakDude.View;
using System.Windows.Controls;
using System;
using System.Windows.Input;

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
        /// 
       
        public MainWindow()
        {

            InitializeComponent();
            this.Content = new MainMenu();
            this.AddHandler(Button.ClickEvent, new RoutedEventHandler(MenuController));

        }

        private void MenuController(object sender, RoutedEventArgs e)
        {
            var a = e.OriginalSource as Button;
          /*  if (a!=null && (a.Name=="Back"|| a.Name == "SkipButton"))
            {
                this.Content = new MainMenu();
                e.Handled = true;
            }
            */
        }

    }
}