using Diplom.Data;
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
    /// Логика взаимодействия для PdfReportServiceWindow.xaml
    /// </summary>
    public partial class PdfReportServiceWindow : Window
    {
        private PdfServiceViewModel _pdfViewModel;
        public PdfReportServiceWindow(ApplicationDbContext ctx)
        {
            InitializeComponent();
            DataContext = _pdfViewModel = new PdfServiceViewModel(ctx);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Grid_Name_Print, "Распечатываем элемент Canvas");
            }
        }
    }
}
