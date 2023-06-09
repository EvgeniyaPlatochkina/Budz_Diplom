﻿using Diplom.Data;
using Diplom.Data.Entities;
using Diplom.Services;
using Diplom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        private DirectorViewModel _directorView;
        public static DirectorWindow Window;
        public bool MainWindowState = true;
        public DirectorWindow(ApplicationDbContext ctx, User user)
        {
            InitializeComponent();
            DataContext = _directorView = new DirectorViewModel(ctx,user);
            Window = this;
        }

       
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {

            this.WindowState = WindowState.Minimized;
        }

        private void windowFrame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DirectorWindow.Window.DragMove();
            }
        }

        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindowState)
            {
                Window.WindowState = WindowState.Maximized;
                MainWindowState = true;
            }
            else
            {
                Window.WindowState = WindowState.Normal;
                MainWindowState = false;
            }
        }



        //private void MinButton_Click(object sender, RoutedEventArgs e)
        //{
        //    
        //}

        //private void ExitButton_Click(object sender, RoutedEventArgs e)
        //{
        //    
        //}
    }
}
