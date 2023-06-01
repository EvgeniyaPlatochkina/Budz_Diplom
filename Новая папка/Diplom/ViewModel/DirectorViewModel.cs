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
using System.Windows.Input;

namespace Diplom.ViewModel
{
    public class DirectorViewModel : ViewModelBase
    {
        public DirectorViewModel(ApplicationDbContext ctx,User user)
        {
            _ctx = ctx;
            _userService = new(_ctx);
            _roleService = new(_ctx);
            _employeesService = new(_ctx);
            Role = _roleService.GetRole();
            User = user;
            UpdateLists();
        }
        private User _selectedUser;
        private ApplicationDbContext _ctx;
        private List<User> _users;
        private UserService _userService;
        private RoleService _roleService;
        private string _searchUserValue;
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private string _login;
        private string _password;
        private User _user;
        private Role _selectedRole;

        private List<Role> _role;
        public List<Role> Role { get => _role; set => Set(ref _role, value, nameof(Role)); }
        public Role SelectedRole { get => _selectedRole; set => Set(ref _selectedRole, value, nameof(SelectedRole)); }

        public string LastName { get => _lastName; set => Set(ref _lastName, FirstLetterToUpper(value), nameof(LastName)); }
        public string FirstName { get => _firstName; set => Set(ref _firstName, FirstLetterToUpper(value), nameof(FirstName)); }
        public string MiddleName { get => _middleName; set => Set(ref _middleName, FirstLetterToUpper(value), nameof(MiddleName)); }
        public User User { get => _user; set => Set(ref _user, value, nameof(User)); }
        public string Login { get => _login; set => Set(ref _login, FirstLetterToUpper(value), nameof(Login)); }
        public string Password { get => _password; set => Set(ref _password, FirstLetterToUpper(value), nameof(Password)); }



        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                Set(ref _selectedUser, value, nameof(SelectedUser));
                if (value != null)
                {
                    FirstName = value.FirstName;
                    LastName = value.LastName;
                    MiddleName = value.MiddleName;
                    Login = value.Login;
                    Password = value.Password;
                    SelectedRole = value.Role;
                }
            }
        }
        public List<User> Users { get => _users; set => Set(ref _users, value, nameof(Users)); } 
        public string SearchUserValue
        {
            get => _searchUserValue; set
            {
                if (Set(ref _searchUserValue, value, nameof(SearchUserValue)))
                    UpdateLists();
            }
        }

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
        private ICollection<User> GetUser() => _userService.GetUsers().ToList();

        public ICommand UpdateAccountButton => new Command(updateaccount => UpdateAccountData());
        public ICommand DeleteUserButton => new Command(delete => DeleteUser());

        public void DeleteUser()
        {
            if (!SelectedProductIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _userService.Delete(SelectedUser);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите пользователя", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private bool SelectedProductIsNull() => SelectedUser == null;
   
        private void UpdateLists()
        {
            Users = SearchUser(_userService.GetUsers().ToList());
            Еmployees = _employeesService.GetЕmployees().ToList();
        }
        private List<User> SearchUser(List<User> searchUser)
        {
            if (!string.IsNullOrEmpty(SearchUserValue))
                return searchUser.Where(p => p.LastName.ToLower().Contains(SearchUserValue.ToLower()) || p.FirstName.ToLower().Contains(SearchUserValue.ToLower())).ToList();
            else
                return searchUser;
        }
        

        private bool ClientIsExist() => _userService.GetUsers().Any(c => c.Password == Password && c.Login == Login);
        private bool PasswordAlredyInUse() => _userService.GetUsers().Any(c => c.Password == Password);
        private bool LoginAlredyInUse() => _userService.GetUsers().Any(c => c.Login == Login);
        private bool PropertiesIsNull() => (string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(MiddleName) || string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || SelectedRole == null!);

        private void Registration()
        {
            if (PropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (ClientIsExist())
                MessageBox.Show("Используйте другой логин и пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (PasswordAlredyInUse())
                MessageBox.Show("Используйте другой пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (LoginAlredyInUse())
                MessageBox.Show("Используйте другой логин!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _userService.Insert(new User { Login = Login, Password = Password, FirstName = FirstName, LastName = LastName, MiddleName = MiddleName, RoleId = SelectedRole.Id });
                MessageBox.Show("Учётная запись зарегистрирована!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        private bool FieldsIsNullOrEmpty() => string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName)
           || string.IsNullOrEmpty(MiddleName) || string.IsNullOrEmpty(Login)
           || string.IsNullOrEmpty(Password) ;
        public ICommand AddRegistrationbutton => new Command(Addregistration => Registration());
        private void UpdateAccountData()
        {
            if(SelectedProductIsNull())
                MessageBox.Show("Выберите пользователя!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (FieldsIsNullOrEmpty())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _selectedUser.FirstName = FirstName;
                _selectedUser.LastName = LastName;
                _selectedUser.MiddleName = MiddleName;
                _selectedUser.Password = Password;
                _selectedUser.Login = Login;
                _selectedUser.RoleId = SelectedRole.Id;
                _userService.Update(_selectedUser);
                MessageBox.Show("Данные учётной записи успешно обновлены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        public void ExitDirectorWindow()
        {
            new AuthorizationWindow().Show();
            var CurrentWindow = Application.Current.MainWindow;
            CurrentWindow.Close();
        }
        #region Сотрудники
        private EmployeesService _employeesService;
        private List<Еmployees> _еmployees;
        private string _firstNameEmp;
        private string _lastNameEmp;
        private string _middleNameEmp;
        private Еmployees _selectedEmpl;
        public Еmployees SelectedEmployees
        {
            get => _selectedEmpl;
            set
            {
                Set(ref _selectedEmpl, value, nameof(SelectedEmployees));
                if (value != null)
                {
                    FirstNameEmp = value.FirstName;
                    LastNameEmpoyees = value.LastName;
                    MiddleNameEmp = value.MiddleName;
                }
            }
        }
        public string FirstNameEmp { get => _firstNameEmp; set => Set(ref _firstNameEmp, FirstLetterToUpper(value), nameof(FirstNameEmp)); }
        public string LastNameEmpoyees { get => _lastNameEmp; set => Set(ref _lastNameEmp, FirstLetterToUpper(value), nameof(LastNameEmpoyees)); }
        public string MiddleNameEmp { get => _middleNameEmp; set => Set(ref _middleNameEmp, FirstLetterToUpper(value), nameof(MiddleNameEmp)); }
        public List<Еmployees> Еmployees { get => _еmployees; set => Set(ref _еmployees, value, nameof(Еmployees)); }
        private bool EmploeePropertiesIsNull() => (string.IsNullOrEmpty(FirstNameEmp) || string.IsNullOrEmpty(LastNameEmpoyees) || string.IsNullOrEmpty(MiddleNameEmp));
        private bool EmployeeIsExist() => _employeesService.GetЕmployees().Any(c => c.FirstName == FirstNameEmp && c.LastName == LastNameEmpoyees && c.MiddleName == MiddleNameEmp);
        private bool SelectedmployeesIsNull() => SelectedEmployees == null;

        public ICommand AddEmployeebutton => new Command(Addregistration => EmployeeRegistration());
        public ICommand UpdateEmployeeButton => new Command(updateaccount => UpdateEmployeeData());
        public ICommand DeleteEmployeeButton => new Command(delete => DeleteEmployee());
        private void EmployeeRegistration()
        {
            if (EmploeePropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (EmployeeIsExist())
                MessageBox.Show("Такой сотрудник есть!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _employeesService.Insert(new Еmployees {FirstName = FirstNameEmp, LastName = LastNameEmpoyees, MiddleName = MiddleNameEmp });
                MessageBox.Show("Сотрудник добавлен", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        private void UpdateEmployeeData()
        {
            if (EmploeePropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
          else if (EmployeeIsExist())
                MessageBox.Show("такой уже есть сотрудник!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _selectedEmpl.FirstName = FirstNameEmp;
                _selectedEmpl.LastName = LastNameEmpoyees;
                _selectedEmpl.MiddleName = MiddleNameEmp;
                _employeesService.Update(_selectedEmpl);
                MessageBox.Show("Данные сотрудника обновлены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        public void DeleteEmployee()
        {
            if (!SelectedmployeesIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _employeesService.Delete(SelectedEmployees);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите сотрудника", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
    }
}
