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
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    /// 
  
    public partial class ReportWindow : Window
    {
       
      private ReportViewModel _reportViewModel;
        public static ReportWindow Window;
       public ReportWindow(Report report, ApplicationDbContext ctx, UserService userService,CategorieService categorieService)
        {
            InitializeComponent();
            DataContext = _reportViewModel = new ReportViewModel(ctx, categorieService);
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
                ReportWindow.Window.DragMove();
            }
        }
    }
}
