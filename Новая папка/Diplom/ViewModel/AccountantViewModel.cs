using Diplom.Data;
using Diplom.Data.Entities;
using Diplom.Services;
using Diplom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Diplom.ViewModel
{
    public  class AccountantViewModel : ViewModelBase
    {
        public AccountantViewModel(ApplicationDbContext ctx, User user)
        {
            _ctx = ctx;
            SelectedUsers = user;
            _reportService = new(_ctx);
            _userService = new(_ctx);
            _categorieService = new(_ctx);
            DateOfCreatingReport = DateTime.Now;
           
            UpdateLists();
        }
        private ApplicationDbContext _ctx;
        private string _titleReport;
        private DateTime _dateOfCreating;
        private User _selectedUser;
        private ReportService _reportService;
        private UserService _userService;
        private List<Report> _reports;
        private Report _selectedReport;
        private Report _report;
        private CategorieService _categorieService;
        private Window Window;

        public Report SelectedReport
        {
            get => _selectedReport;
            set
            {
                Set(ref _selectedReport, value, nameof(SelectedReport));
                if (value != null)
                {
                    TitleReport = value.Title;
                    DateOfCreatingReport = value.DateOfСreation;
                    SelectedUsers = value.User;
                }
            }
        }

        private List<User> _users;
        public List<User> Users { get => _users; set => Set(ref _users, value, nameof(Users)); }
        public List<Report> Reports { get => _reports; set => Set(ref _reports, value, nameof(Reports)); }
        public string TitleReport { get => _titleReport; set => Set(ref _titleReport, FirstLetterToUpper(value), nameof(TitleReport)); }
        public DateTime DateOfCreatingReport { get => _dateOfCreating; set => Set(ref _dateOfCreating, value, nameof(DateOfCreatingReport)); }
        public User SelectedUsers { get => _selectedUser; set => Set(ref _selectedUser, value, nameof(SelectedUsers)); }

        public Report Report { get => _report; set => Set(ref _report, value, nameof(Report)); }

        private bool ClientIsExist() => _reportService.GetReport().Any(c => c.Title == TitleReport);

        private bool PropertiesIsNull() => (string.IsNullOrEmpty(TitleReport));
        private string FirstLetterToUpper(string value)
        {
            var newString = new StringBuilder();
            if (!string.IsNullOrEmpty(value))
            {
                if (value[0] != value.ToUpper()[0])
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (i == 0)
                            newString.Append(value.ToUpper()[i]);
                        else
                            newString.Append(value[i]);
                    }
                    value = newString.ToString();
                }
            }
            return value;
        }
        private ICollection<Report> GetReport() => _reportService.GetReport().ToList();
        private ICollection<User> GetUsers() => _userService.GetUsers().ToList();
        private void Registration()
        {

            if (PropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (ClientIsExist())
                MessageBox.Show("Используйте другое название", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _reportService.Insert(new Report { Title = TitleReport, DateOfСreation = DateOfCreatingReport, UserId = SelectedUsers.Id });
                MessageBox.Show("Report add!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();

                
            }
        }
        private bool SelectedReportIsNull() => SelectedReport == null;
        public ICommand DeleteReportButton => new Command(delete => DeleteReport());
        public ICommand UpdateReportButton => new Command(updateaccount => UpdateReportData());
        public void DeleteReport()
        {
            if (!SelectedReportIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _reportService.Delete(SelectedReport);
                    UpdateLists();
                    SelectedReport = null!;
                }
                
            }
            else
                MessageBox.Show("Выберите пользователя", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void UpdateReportData()
        {
            if (PropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                SelectedReport.Title = TitleReport;
                SelectedReport.DateOfСreation = DateOfCreatingReport;
                SelectedReport.UserId = SelectedUsers.Id;
                _reportService.Update(SelectedReport);
                MessageBox.Show("Данные учётной записи успешно обновлены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
                TitleReport = string.Empty;
                SelectedReport = null!;
            }
        }
        public void OpenAccountantWindow()
        {
            if (!SelectedReportIsNull())
                new ReportWindow(SelectedReport, _ctx, _userService, _categorieService).ShowDialog();
            UpdateLists();
        }
        public void ExitAccountantWindow()
        {
                new AuthorizationWindow().Show();
                var CurrentWindow = Application.Current.MainWindow;
                CurrentWindow.Close();
        }
        public ICommand AddReportbutton => new Command(Addregistration => Registration());
        private void UpdateLists()
        {
            Reports = new List<Report>(GetReport());
            Users = new List<User>(GetUsers());
           
        }
    }
}
