using Diplom.Data;
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
    /// Логика взаимодействия для AccountantWindow.xaml
    /// </summary>
    public partial class AccountantWindow : Window
    {
        private AccountantViewModel _accountantViewModel;
        public static AccountantWindow Window;
        public bool MainWindowState=false;

        public AccountantWindow(ApplicationDbContext ctx, User user, UserService userService)
        {
            InitializeComponent();

            DataContext = _accountantViewModel = new AccountantViewModel(ctx, user);
            Window = this;
        }

        private void PracticesListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            _accountantViewModel.OpenAccountantWindow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _accountantViewModel.ExitAccountantWindow();
        }
        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

            private void windowFrame_MouseDown(object sender, MouseButtonEventArgs e)
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    AccountantWindow.Window.DragMove();
                }
            }

        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindowState)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                MainWindowState = true;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
                MainWindowState = false;
            }
        }
    }
}

