using Diplom.Controls;
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
    public class ReportViewModel : ViewModelBase
    {
        public ReportViewModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _organizationService = new(_ctx);
            _productService = new(_ctx);
            _categorieService = new(_ctx);
            _serviceService = new(_ctx);
            _pictureProductSevice = new(_ctx);
            _productSaleService = new(_ctx);
            _employeesProduct = new(_ctx);
            _saleServiceService = new(_ctx);
            _employeesService = new(_ctx);
            PictureProduct = _pictureProductSevice.GetCategories();
            
            DateOfSaleProduct = DateTime.Now;
            DateOfSaleService = DateTime.Now;
            ProductFilthers = new List<string> { "Не выбрана" };
            ProductFilthersTtile = new List<string> { "Не выбрана" };
            ProductFilthersDate = new List<string> { "Не выбрана", "за 1 год", "за 2 год", "за 3 год" };
            ProductSorts = new List<string> { "Не выбрана", "По стоимости(убыв.)", "По стоимости(возр.)",};
            ServiceSorts = new List<string> { "Не выбрана", "По стоимости(убыв.)", "По стоимости(возр.)",};
            ProductFilthers.AddRange(_categorieService.GetCategories().Select(c => c.Title));
            ProductFilthersTtile.AddRange(_productService.GetProducts().Select(c => c.Title));
            SelectedProductFilther = ProductFilthers[0];
            SelectedProductFiltherTitle = ProductFilthersTtile[0];
            SelectedProductFiltherDate = ProductFilthersDate[0];
            SelectedProductSort = ProductSorts[0];
            SelectedServiceSort = ServiceSorts[0];
      
          
            UpdateLists();
        }
        private void UpdateLists()
        {
            Organizations = _organizationService.GetOrganization().ToList();
            Products = _productService.GetProducts().ToList();
            Categorie = _categorieService.GetCategories();
            Services = _serviceService.GetServices();
            OrganizationsSaleProduct = _organizationService.GetOrganization().ToList();
            OrganizationsSaleService = _organizationService.GetOrganization().ToList();

            SaleProducts = new List<SaleProduct>(GetSaleProduct()).ToList();

            ProductsSaleProduct = _productService.GetProducts();
            EmployeesList = _employeesProduct.GetЕmployees();
            SaleService = new List<SaleService>(GetServices()).ToList();
            EmployeesListService = _employeesService.GetЕmployees();
            ServiceSaleService = _serviceService.GetServices();
        }
        private ApplicationDbContext _ctx;
        #region ToUpper
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
        #endregion
        #region Categorie

        private string _categorieTitle;
        private Categorie _selectedCategorieTitle;
        public string CategorieTitle { get => _categorieTitle; set => Set(ref _categorieTitle, FirstLetterToUpper(value), nameof(CategorieTitle)); }
        public Categorie SelectedCategorieTitle
        {
            get => _selectedCategorieTitle;
            set
            {
                Set(ref _selectedCategorieTitle, value, nameof(SelectedCategorieTitle));
                if (value != null)
                {
                    CategorieTitle = value.Title;
 
                }
            }
        }
        private bool SelectedCategorieTitleIsNull() => SelectedCategorieTitle == null;
        private bool CategorieTitleAlredyInUse() => _categorieService.GetCategories().Any(c => c.Title == CategorieTitle);
        private bool CategoriePropertiesIsNull() => string.IsNullOrEmpty(CategorieTitle);
        public ICommand AddCategoriebutton => new Command(Addregistration => AddCategorie());
        public ICommand UpdateCategorieButton => new Command(updateaccount => UpdateCategorieData());
        public ICommand DeleteCategorieButton => new Command(delete => DeleteCategorie());

        private void AddCategorie()
        {
            if (CategoriePropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (CategorieTitleAlredyInUse())
                MessageBox.Show("Используйте Введите другое название", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _categorieService.Insert(new Categorie { Title = CategorieTitle });
                MessageBox.Show("Категория Добавлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        private void UpdateCategorieData()
        {
            if (SelectedCategorieTitleIsNull())
                MessageBox.Show("Выберите категорию", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _selectedCategorieTitle.Title = CategorieTitle;
                _categorieService.Update(_selectedCategorieTitle);
                MessageBox.Show("Данные категории  успешно обновлены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        public void DeleteCategorie()
        {
            if (!SelectedCategorieTitleIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _categorieService.Delete(SelectedCategorieTitle);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите категорию", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
        #region Pdf
        public ICommand OpenPdfWindowButton => new Command(authorization => OpenPdfWindow());
        public ICommand OpenPdfServiceWindowButton => new Command(authorization => OpenPdfServiceWindow());
        private void OpenPdfWindow()
        {
           var DirectorWindow = new PdfReportWindow(_ctx);
           var CurrentWindow = Application.Current.MainWindow;
           DirectorWindow.ShowDialog();
           Application.Current.MainWindow = DirectorWindow;
        }
      
        private void OpenPdfServiceWindow()
        {
            var DirectorWindow = new PdfReportServiceWindow(_ctx);
            var CurrentWindow = Application.Current.MainWindow;
            DirectorWindow.ShowDialog();
            Application.Current.MainWindow = DirectorWindow;
        }
        #endregion
        #region Search Filter Sort
        private string _searchProductValue;
        private string _searchServiceValue;
        private string _selectedProductFilther;
        private string _selectedProductFiltherTitle;
        private string _selectedProductFiltherDate;
        private string _selectedProductSort;
        private string _selectedServiceSort;
        private string _productsCount;
        private string _servicesCount;


       
        private ICollection<SaleProduct> GetSaleProduct() => SortProducts(SearchSaleProduct(FiltherProducts(FiltherProductsTitle(_productSaleService.GetSaleProducts().ToList()))));

        private ICollection<SaleService> GetServices() => SearchSaleService(_saleServiceService.GetSaleService().ToList());
        public List<string> ProductFilthers { get; set; } = null!;
        public List<string> ProductFilthersTtile { get; set; } = null!;
        public List<string> ProductFilthersDate { get; set; } = null!;
        public List<string> ProductSortDate { get; set; } = null!;
        public List<string> ProductSorts { get; set; } = null!;
        public List<string> ServiceSorts { get; set; } = null!;
        public string ProductsCount { get => _productsCount; set => Set(ref _productsCount, value, nameof(ProductsCount)); }
        public string ServicesCount { get => _servicesCount; set => Set(ref _servicesCount, value, nameof(ServicesCount)); }
        public string SearchServiceValue
        {
            get => _searchServiceValue; set
            {
                if (Set(ref _searchServiceValue, value, nameof(SearchServiceValue)))
                    UpdateLists();
            }
        }
        public string SelectedProductFilther
        {
            get => _selectedProductFilther; set
            {
                if (Set(ref _selectedProductFilther, value, nameof(SelectedProductFilther)))
                    UpdateLists();
            }
        }
        public string SelectedProductFiltherTitle
        {
            get => _selectedProductFiltherTitle; set
            {
                if (Set(ref _selectedProductFiltherTitle, value, nameof(SelectedProductFiltherTitle)))
                    UpdateLists();
            }
        }
        public string SelectedProductFiltherDate
        {
            get => _selectedProductFiltherDate; set
            {
                if (Set(ref _selectedProductFiltherDate, value, nameof(SelectedProductFiltherDate)))
                    UpdateLists();
            }
        }
        public string SelectedProductSort
        {
            get => _selectedProductSort; set
            {
                if (Set(ref _selectedProductSort, value, nameof(SelectedProductSort)))
                    UpdateLists();
            }
        }
        public string SelectedServiceSort
        {
            get => _selectedServiceSort; set
            {
                if (Set(ref _selectedServiceSort, value, nameof(SelectedServiceSort)))
                    UpdateLists();
            }
        }

        private string _searchSaleProductValue;
        public string SearchSaleProductValue
        {
            get => _searchSaleProductValue; set
            {
                if (Set(ref _searchSaleProductValue, value, nameof(SearchSaleProductValue)))
                    UpdateLists();
            }
        }
        private List<SaleProduct> SearchSaleProduct(List<SaleProduct> saleProducts)
        {
            if (!string.IsNullOrEmpty(SearchSaleProductValue))
                return saleProducts.Where(p => p.Article.ToLower().Contains(SearchSaleProductValue.ToLower()) || p.Organization.Title.ToLower().Contains(SearchSaleProductValue.ToLower())
                    || p.Product.Title.ToLower().Contains(SearchSaleProductValue.ToLower())
                    || p.Еmployees.FullName.ToLower().Contains(SearchSaleProductValue.ToLower()
                    )).ToList();
            else
                return saleProducts;
        }
        private List<SaleProduct> FiltherProducts(List<SaleProduct> productOrders)
        {
            if (!(SelectedProductFilther == ProductFilthers[0]))
                return productOrders.Where(p => p.Product.Categorie.Title == SelectedProductFilther).ToList();
            else
                return productOrders;
        }
        private List<SaleProduct> FiltherProductsTitle(List<SaleProduct> productOrders)
        {
            if (!(SelectedProductFiltherTitle == ProductFilthersTtile[0]))
                return productOrders.Where(p => p.Product.Title == SelectedProductFiltherTitle).ToList();
            else
                return productOrders;
        }

        //private List<SaleProduct> FiltherProductsDate(List<SaleProduct> productOrders)
        //{
        //    if (!(SelectedProductFiltherDate == ProductFilthersDate[0]))
        //        return productOrders.Where(p => p.DateOfSale.Year == DateDate.Year).ToList();
        //    else
        //        return productOrders;
        //}
       
        private ICollection<SaleProduct> SortProducts(ICollection<SaleProduct> productOrders)
        {
            if (SelectedProductSort == ProductSorts[1])
                return productOrders.OrderByDescending(p => p.Income).ToList();
            else if (SelectedProductSort == ProductSorts[2])
                return productOrders.OrderBy(p => p.Income).ToList(); 
            else
                return productOrders;
        }
        private List<SaleService> SearchSaleService(List<SaleService> saleProducts)
        {
            if (!string.IsNullOrEmpty(SearchServiceValue))
                return saleProducts.Where(p => p.Article.ToLower().Contains(SearchServiceValue.ToLower()) || p.Organization.Title.ToLower().Contains(SearchServiceValue.ToLower())
                    || p.Service.Title.ToLower().Contains(SearchServiceValue.ToLower())
                    || p.Еmployees.FullName.ToLower().Contains(SearchServiceValue.ToLower()
                    )).ToList();
            else
                return saleProducts;
        }

        #endregion
        #region SaleService

        private string _articleService;
        private DateTime _dateOfSaleService;
        private decimal _profitService;

        private EmployeesService _employeesService;


        private List<Organization> _organizationsSaleService;
        private List<Service> _serviceSaleService;
        private List<Еmployees> _еmployeesListService;
        private List<SaleService> _saleService;

        private SaleService _selectedSaleService;
        private Organization _selectedorganizationSaleService;
        private Service _selectedProductSaleService;
        private Еmployees _selectedеmployeesService;
        private SaleServiceService _saleServiceService;

        public List<SaleService> SaleService { get => _saleService; set => Set(ref _saleService, value, nameof(SaleService)); }
        public List<Еmployees> EmployeesListService { get => _еmployeesListService; set => Set(ref _еmployeesListService, value, nameof(EmployeesListService)); }
        public Еmployees SelectedEmployeesService { get => _selectedеmployeesService; set => Set(ref _selectedеmployeesService, value, nameof(SelectedEmployeesService)); }
        public Organization SelectedorganizationSaleService { get => _selectedorganizationSaleService; set => Set(ref _selectedorganizationSaleService, value, nameof(SelectedorganizationSaleService)); }
        public Service SelectedServiceSale
        {
            get => _selectedProductSaleService;
            set
            {
                Set(ref _selectedProductSaleService, value, nameof(SelectedServiceSale));
                if (value != null)
                {
                    ProfitService = value.ProfitSale;
                }
            }
        }
        public string ArticleService { get => _articleService; set => Set(ref _articleService, FirstLetterToUpper(value), nameof(ArticleService)); }
        public DateTime DateOfSaleService { get => _dateOfSaleService; set => Set(ref _dateOfSaleService, value, nameof(DateOfSaleService)); }
        public List<Organization> OrganizationsSaleService { get => _organizationsSaleService; set => Set(ref _organizationsSaleService, value, nameof(OrganizationsSaleService)); }
        public List<Service> ServiceSaleService { get => _serviceSaleService; set => Set(ref _serviceSaleService, value, nameof(ServiceSaleService)); }

        public decimal ProfitService { get => _profitService; set => Set(ref _profitService, value, nameof(ProfitService)); }
        public SaleService SelectedSaleService
        {
            get => _selectedSaleService;
            set
            {
                Set(ref _selectedSaleService, value, nameof(SelectedSaleService));
                if (value != null)
                {
                    ArticleService = value.Article;
                    DateOfSaleService = value.DateOfSale;
                    SelectedorganizationSaleService = value.Organization;
                    SelectedServiceSale = value.Service;
                    SelectedServiceSale.CostPerHour = value.Income;
                    ProfitService = value.Profit;
                    SelectedEmployeesService = value.Еmployees;
                }
            }
        }
        private bool SaleServicePropertiesIsNull() => (string.IsNullOrEmpty(ArticleService) || DateOfSaleService == null! || SelectedorganizationSaleService == null || SelectedServiceSale == null || SelectedEmployeesService == null);
        private bool SelectedSaleServiceIsNull() => SelectedSaleService == null;
        public ICommand AddSaleServicebutton => new Command(Addregistration => AddSaleService());
        public ICommand UpdateSaleServiceButton => new Command(updateaccount => UpdateSaleServiceData());
        public ICommand DeleteSaleServiceButton => new Command(delete => DeleteSaleService());
        private bool SelectedEmployeesIsNull() => SelectedEmployeesService == null;
        private void AddSaleService()
        {
            //Owner.All(x => char.IsNumber(x));
            if (SaleServicePropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _saleServiceService.Insert(new SaleService { Article = ArticleService, DateOfSale = DateOfSaleService, OrganizationId = SelectedorganizationSaleService.Id, ServiceId = SelectedServiceSale.Id, Profit = ProfitService, ЕmployeesiD = SelectedEmployeesService.Id, Income = SelectedServiceSale.CostPerHour });
                MessageBox.Show("продажа Добавлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        private void UpdateSaleServiceData()
        {
            if (SelectedSaleServiceIsNull())
                MessageBox.Show("Выберите продажу услуги", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _selectedSaleService.Article = ArticleService;
                _selectedSaleService.DateOfSale = DateOfSaleService;
                _selectedSaleService.OrganizationId = SelectedorganizationSaleService.Id;
                _selectedSaleService.ServiceId = SelectedServiceSale.Id;
                _selectedSaleService.Profit = ProfitService;
                _selectedSaleService.ЕmployeesiD = SelectedEmployeesService.Id;
                _selectedSaleService.Income = SelectedServiceSale.CostPerHour;
                _saleServiceService.Update(_selectedSaleService);
                MessageBox.Show("Данные продажи  услуги успешно обновлены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        public void DeleteSaleService()
        {
            if (!SelectedSaleServiceIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _saleServiceService.Delete(SelectedSaleService);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите услуг", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
        #region SaleProduct

        private string _articleProduct;
        private DateTime _dateOfSaleProduct;
        private decimal _profit;

        private List<Organization> _organizationsSaleProduct;
        private List<Product> _productsSaleProduct;
        private List<Еmployees> _еmployeesList;
        private List<SaleProduct> _saleProducts;

        private SaleProduct _selectedSaleProduct;
        private Organization _selectedorganizationSaleProduct;
        private Product _selectedProductSaleProduct;
        private Еmployees _selectedеmployees;


        private EmployeesService _employeesProduct;
        private SaleProductService _productSaleService;


       
        public List<SaleProduct> SaleProducts { get => _saleProducts; set => Set(ref _saleProducts, value, nameof(SaleProducts)); }
        public List<Еmployees> EmployeesList { get => _еmployeesList; set => Set(ref _еmployeesList, value, nameof(EmployeesList)); }
        public Еmployees SelectedEmployees { get => _selectedеmployees; set => Set(ref _selectedеmployees, value, nameof(SelectedEmployees)); }
        public Organization SelectedorganizationSaleProduct { get => _selectedorganizationSaleProduct; set => Set(ref _selectedorganizationSaleProduct, value, nameof(SelectedorganizationSaleProduct)); }
        public Product SelectedProductSaleProduct
        {
            get => _selectedProductSaleProduct;
            set
            {
                Set(ref _selectedProductSaleProduct, value, nameof(SelectedProductSaleProduct));
                if (value != null)
                {
                    Profit = value.ProfitSale;
                }
            }
        }


        public string ArticleProduct { get => _articleProduct; set => Set(ref _articleProduct, FirstLetterToUpper(value), nameof(ArticleProduct)); }
        public DateTime DateOfSaleProduct { get => _dateOfSaleProduct; set => Set(ref _dateOfSaleProduct, value, nameof(DateOfSaleProduct)); }
        public List<Organization> OrganizationsSaleProduct { get => _organizationsSaleProduct; set => Set(ref _organizationsSaleProduct, value, nameof(OrganizationsSaleProduct)); }
        public List<Product> ProductsSaleProduct { get => _productsSaleProduct; set => Set(ref _productsSaleProduct, value, nameof(ProductsSaleProduct)); }

        public decimal Profit { get => _profit; set => Set(ref _profit, value, nameof(Profit)); }
        public SaleProduct SelectedSaleProduct
        {
            get => _selectedSaleProduct;
            set
            {
                Set(ref _selectedSaleProduct, value, nameof(SelectedSaleProduct));
                if (value != null)
                {
                    ArticleProduct = value.Article;
                    DateOfSaleProduct = value.DateOfSale;
                    SelectedorganizationSaleProduct = value.Organization;
                    SelectedProductSaleProduct = value.Product;
                    SelectedProductSaleProduct.Cost = value.Income;
                    Profit = value.Profit;
                    SelectedEmployees = value.Еmployees;
                }
            }
        }
        private bool SaleProductPropertiesIsNull() => (string.IsNullOrEmpty(ArticleProduct) || DateOfSaleProduct == null! || OrganizationsSaleProduct == null || ProductsSaleProduct == null || SelectedEmployees ==null);
        private bool SelectedSaleProductIsNull() => SelectedSaleProduct == null;
        public ICommand AddSaleProductbutton => new Command(Addregistration => AddSaleProduct());
        public ICommand UpdateSaleProductButton => new Command(updateaccount => UpdateSaleProductData());
        public ICommand DeleteSaleProductButton => new Command(delete => DeleteSaleProduct());
        private void AddSaleProduct()
        {
            //Owner.All(x => char.IsNumber(x));
            if (SaleProductPropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _productSaleService.Insert(new SaleProduct { Article = ArticleProduct, DateOfSale = DateOfSaleProduct, OrganizationId = SelectedorganizationSaleProduct.Id, ProductId = SelectedProductSaleProduct.Id,Profit= Profit, ЕmployeesId = SelectedEmployees.Id,Income= SelectedProductSaleProduct.Cost});
                MessageBox.Show("продажа Добавлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        private void UpdateSaleProductData()
        {
            if (SelectedSaleProductIsNull())
                MessageBox.Show("Выберите продажу товара", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _selectedSaleProduct.Article = ArticleProduct;
                _selectedSaleProduct.DateOfSale = DateOfSaleProduct;
                _selectedSaleProduct.OrganizationId = SelectedorganizationSaleProduct.Id;
                _selectedSaleProduct.ProductId = SelectedProductSaleProduct.Id;
                _selectedSaleProduct.Profit = Profit;
                _selectedSaleProduct.ЕmployeesId = SelectedEmployees.Id;
                _selectedSaleProduct.Income = SelectedProductSaleProduct.Cost;
                _productSaleService.Update(_selectedSaleProduct);
                MessageBox.Show("Данные продажи товара  успешно обновлены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        public void DeleteSaleProduct()
        {
            if (!SelectedSaleProductIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _productSaleService.Delete(SelectedSaleProduct);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите продажу", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
        #region Organization
        private Organization _selectedOrganization;
        private List<Organization> _organizations;

        private OrganizationService _organizationService;
        private string _titleOrganization;
        private string _legalAdress;
        private string _inn;
        private string _kpp;
        private string _owner;
        private string _mailAdress;
        private string _numberPhone;
        private string _bankAccountNumber;
        private string _ogrn;
        private string _okta;
        private string _okpo;

        public Organization SelectedOrganization
        {
            get => _selectedOrganization;
            set
            {
                Set(ref _selectedOrganization, value, nameof(SelectedOrganization));
                if (value != null)
                {
                    TitleOrganization = value.Title;
                    LegalAdress = value.LegalAddress;
                    Inn = value.INN;
                    Kpp = value.KPP;
                    Owner = value.Owner;
                    MailAdress = value.MailingAddress;
                    NumberPhone = value.NumberPhone;
                    BankAccountNumber = value.BankAccountNumber;
                    Ogrn = value.OGRN;
                    Okta = value.OKATO;
                    Okpo = value.OKPO;

                }
            }
        }
        public List<Organization> Organizations { get => _organizations; set => Set(ref _organizations, value, nameof(Organizations)); }
        public string TitleOrganization { get => _titleOrganization; set => Set(ref _titleOrganization, FirstLetterToUpper(value), nameof(TitleOrganization)); }
        public string LegalAdress { get => _legalAdress; set => Set(ref _legalAdress, FirstLetterToUpper(value), nameof(LegalAdress)); }
        public string Inn { get => _inn; set => Set(ref _inn, value, nameof(Inn)); }
        public string Kpp { get => _kpp; set => Set(ref _kpp, value, nameof(Kpp)); }
        public string Owner { get => _owner; set => Set(ref _owner, FirstLetterToUpper(value), nameof(Owner)); }
        public string MailAdress { get => _mailAdress; set => Set(ref _mailAdress, FirstLetterToUpper(value), nameof(MailAdress)); }
        public string NumberPhone { get => _numberPhone; set => Set(ref _numberPhone, value, nameof(NumberPhone)); }
        public string BankAccountNumber { get => _bankAccountNumber; set => Set(ref _bankAccountNumber, value, nameof(BankAccountNumber)); }
        public string Ogrn { get => _ogrn; set => Set(ref _ogrn, value, nameof(Ogrn)); }
        public string Okta { get => _okta; set => Set(ref _okta, value, nameof(Okta)); }
        public string Okpo { get => _okpo; set => Set(ref _okpo, value, nameof(Okpo)); }

        private bool OrganizationIsExist() => _organizationService.GetOrganization().Any(c => c.Title == TitleOrganization && c.INN == Inn && c.KPP == Kpp && c.OGRN == Ogrn && c.OKATO == Okta && c.OKPO== Okpo);
        private bool PropertiesIsNull() => (string.IsNullOrEmpty(TitleOrganization) || string.IsNullOrEmpty(LegalAdress) || string.IsNullOrEmpty(Owner) || string.IsNullOrEmpty(MailAdress) || string.IsNullOrEmpty(Okta) || Inn == null! || Kpp == null! || NumberPhone == null! || BankAccountNumber == null! || Ogrn ==null! || Okpo == null!);
        private bool INNAlredyInUse() => _organizationService.GetOrganization().Any(c => c.INN == Inn);
        private bool KPPAlredyInUse() => _organizationService.GetOrganization().Any(c => c.KPP == Kpp);
        private bool TitleAlredyInUse() => _organizationService.GetOrganization().Any(c => c.Title == TitleOrganization);
        private bool OGRNAlredyInUse() => _organizationService.GetOrganization().Any(c => c.OGRN == Ogrn);
        private bool OKATOAlredyInUse() => _organizationService.GetOrganization().Any(c => c.OKATO == Okta);
        private bool OKPOAlredyInUse() => _organizationService.GetOrganization().Any(c => c.OKPO == Okpo);

        private bool NumberPhoneAlredyInUse() => _organizationService.GetOrganization().Any(c => c.NumberPhone == NumberPhone);
        private bool BankAccountNumberAlredyInUse() => _organizationService.GetOrganization().Any(c => c.BankAccountNumber == BankAccountNumber);
        private bool SelectedOrganizationsIsNull() => SelectedOrganization == null;
        public ICommand AddOrganizationsbutton => new Command(Addregistration => AddOrganizations());
        public ICommand UpdateOrganizationsButton => new Command(updateaccount => UpdateOrganizationsData());
        public ICommand DeleteOrganizationsButton => new Command(delete => DeleteOrganizations());
       
        private void AddOrganizations()
        {
            //Owner.All(x => char.IsNumber(x));
            if (PropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (OrganizationIsExist())
                MessageBox.Show("Используйте Введите другие данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (TitleAlredyInUse())
                MessageBox.Show("Используйте Введите другое название", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (INNAlredyInUse())
                MessageBox.Show("Используйте Введите другой ИНН", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (KPPAlredyInUse())
                MessageBox.Show("Используйте Введите другой КПП", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (NumberPhoneAlredyInUse())
                MessageBox.Show("Используйте Введите другой номер", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (BankAccountNumberAlredyInUse())
                MessageBox.Show("Используйте Введите другой банковский счет", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (OGRNAlredyInUse())
                MessageBox.Show("Используйте Введите другой ОГРН", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (OKATOAlredyInUse())
                MessageBox.Show("Используйте Введите другой ОКАТО", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (OKPOAlredyInUse())
                MessageBox.Show("Используйте Введите другой ОКПО", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _organizationService.Insert(new Organization { Title = TitleOrganization, LegalAddress = LegalAdress, INN= Inn, KPP = Kpp, Owner = Owner, MailingAddress = MailAdress, NumberPhone = NumberPhone,BankAccountNumber = BankAccountNumber, OGRN = Ogrn, OKATO = Okta, OKPO = Okpo });
                MessageBox.Show("Организация Добавлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        private void UpdateOrganizationsData()
        {
            if (SelectedOrganizationsIsNull())
                MessageBox.Show("Выберите организации!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _selectedOrganization.Title = TitleOrganization;
                _selectedOrganization.LegalAddress = LegalAdress;
                _selectedOrganization.INN = Inn;
                _selectedOrganization.KPP = Kpp;
                _selectedOrganization.Owner = Owner;
                _selectedOrganization.MailingAddress = MailAdress;
                _selectedOrganization.NumberPhone = NumberPhone;
                _selectedOrganization.BankAccountNumber = BankAccountNumber;
                _selectedOrganization.OGRN = Ogrn;
                _selectedOrganization.OKATO = Okta;
                _selectedOrganization.OKPO = Okpo;
                _organizationService.Update(_selectedOrganization);
                MessageBox.Show("Данные организации  успешно обновлены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        public void DeleteOrganizations()
        {
            if (!SelectedOrganizationsIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _organizationService.Delete(SelectedOrganization);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите организации", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
       
        #endregion
        #region Product
        private Product _selectedProduct;
        private Product _product;
        private List<Product> _products;
        private List<Product> _productsRole;
        private string _titleProduct;
        private string _descripionProduct;
        private string _picture;
        private decimal _cost;
        private string _guarantee;
        private decimal _discount;
        private ProductService _productService;
        private CategorieService _categorieService;
        private PictureProductSevice _pictureProductSevice;
        private Categorie _selectedCategorie;
        private List<Categorie> _categorie;

        private List<PictureProduct> _pictureProduct;
        private PictureProduct _selectedPictureporoduct;

        
        public List<PictureProduct> PictureProduct { get => _pictureProduct; set => Set(ref _pictureProduct, value, nameof(PictureProduct)); }
        public PictureProduct SelectedPictureProduct { get => _selectedPictureporoduct; set => Set(ref _selectedPictureporoduct, value, nameof(SelectedPictureProduct)); }
        public Product Product { get => _product; set => Set(ref _product, value, nameof(Product)); }
        public List<Categorie> Categorie { get => _categorie; set => Set(ref _categorie, value, nameof(Categorie)); }
        public string TitleProduct { get => _titleProduct; set => Set(ref _titleProduct, FirstLetterToUpper(value), nameof(TitleProduct)); }
        public string DescriptionProduct { get => _descripionProduct; set => Set(ref _descripionProduct, FirstLetterToUpper(value), nameof(DescriptionProduct)); }
        public string PictureSelected { get => _picture; set => Set(ref _picture, value, nameof(PictureSelected)); }
        public string Guarantee { get => _guarantee; set => Set(ref _guarantee, FirstLetterToUpper(value), nameof(Guarantee)); }
        public decimal Discount { get => _discount; set => Set(ref _discount, value, nameof(Discount)); }
        public decimal Cost { get => _cost; set => Set(ref _cost, value, nameof(Cost)); }
        public Categorie SelectedCategories { get => _selectedCategorie; set => Set(ref _selectedCategorie, value, nameof(SelectedCategories)); }
        public List<Product> Products { get => _products; set => Set(ref _products, value, nameof(Products)); }
        public List<Product> ProductsRole { get => _productsRole; set => Set(ref _productsRole, value, nameof(ProductsRole)); }
        public Product SelecteProduct
        {
            get => _selectedProduct;
            set
            {
                Set(ref _selectedProduct, value, nameof(SelecteProduct));
                if (value != null)
                {
                    TitleProduct = value.Title;
                    DescriptionProduct = value.Description;
                    SelectedPictureProduct = value.PictureProduct;
                    Cost = value.Cost;
                    Guarantee = value.Guarantee;
                    Discount = value.Discount;
                    SelectedCategories = value.Categorie;

                }
            }
        }
        public ICommand AddProductbutton => new Command(Addregistration => AddProduct());
        public ICommand UpdateProductButton => new Command(updateaccount => UpdateProductData());
        public ICommand DeleteProductButton => new Command(delete => DeleteProduct());
        private bool TitleProductAlredyInUse() => _productService.GetProducts().Any(c => c.Title == TitleProduct);
        private bool DescriptionProductAlredyInUse() => _productService.GetProducts().Any(c => c.Description == DescriptionProduct);
        private bool ProductPropertiesIsNull() => (string.IsNullOrEmpty(TitleProduct) || string.IsNullOrEmpty(DescriptionProduct) || Cost == null! || string.IsNullOrEmpty(Guarantee) || SelectedCategories ==null || SelectedPictureProduct==null);
        private bool SelectedProductIsNull() => SelecteProduct == null;
        private void AddProduct()
        {
            //Owner.All(x => char.IsNumber(x));
            if (ProductPropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (TitleProductAlredyInUse())
                MessageBox.Show("Используйте Введите другое название", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (DescriptionProductAlredyInUse())
                MessageBox.Show("Используйте Введите другое описание", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _productService.Insert(new Product { Title = TitleProduct, Description = DescriptionProduct, Cost = Cost, PictureProductId = SelectedPictureProduct.Id, Guarantee = Guarantee, Discount = Discount, CategorieId = SelectedCategories.Id });
                MessageBox.Show("Товар Добавлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        private void UpdateProductData()
        {
            if (SelectedProductIsNull())
                MessageBox.Show("Выберите товар!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _selectedProduct.Title = TitleProduct;
                _selectedProduct.Description = DescriptionProduct;
                _selectedProduct.PictureProductId = SelectedPictureProduct.Id;
                _selectedProduct.Guarantee = Guarantee;
                _selectedProduct.CategorieId = SelectedCategories.Id;
                _selectedProduct.Discount = Discount;
                _selectedProduct.Cost = Cost;
                _productService.Update(_selectedProduct);
                MessageBox.Show("Данные Товара  успешно обновлены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        public void DeleteProduct()
        {
            if (!SelectedProductIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _productService.Delete(SelecteProduct);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите Товар", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
        #region Service
        private Service _selectedService;
        private List<Service> _service;
        private ServiceService _serviceService;

        private string _titleService;
        private string _decription;
        private decimal _costPerHour;
        public decimal CostPerHour { get => _costPerHour; set => Set(ref _costPerHour, value, nameof(CostPerHour)); }
        public string TitleService { get => _titleService; set => Set(ref _titleService, FirstLetterToUpper(value), nameof(TitleService)); }
        public string DescriptionService { get => _decription; set => Set(ref _decription, FirstLetterToUpper(value), nameof(DescriptionService)); }
        public Service SelectedService
        {
            get => _selectedService;
            set
            {
                Set(ref _selectedService, value, nameof(SelectedService));
                if (value != null)
                {
                    TitleService = value.Title;
                    DescriptionService = value.Description;
                    CostPerHour = value.CostPerHour;

                }
            }
        }
        public List<Service> Services { get => _service; set => Set(ref _service, value, nameof(Services)); }

        private bool TitleServicePhoneAlredyInUse() => _serviceService.GetServices().Any(c => c.Title == TitleService);
        private bool DescriptionServiceAlredyInUse() => _serviceService.GetServices().Any(c => c.Description == DescriptionService);

        private bool ServicePropertiesIsNull() => (string.IsNullOrEmpty(TitleService) || string.IsNullOrEmpty(DescriptionService) || CostPerHour == null! );
        private bool SelectedServiceIsNull() => SelectedService == null;
        public ICommand AddServicebutton => new Command(Addregistration => AddService());
        public ICommand UpdateServiceButton => new Command(updateaccount => UpdateServiceData());
        public ICommand DeleteServiceButton => new Command(delete => DeleteService());
        private void AddService()
        {
            //Owner.All(x => char.IsNumber(x));
            if (ServicePropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (TitleServicePhoneAlredyInUse())
                MessageBox.Show("Используйте Введите другое название", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (DescriptionServiceAlredyInUse())
                MessageBox.Show("Используйте Введите другое описание", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _serviceService.Insert(new Service { Title = TitleService, Description = DescriptionService, CostPerHour = CostPerHour});
                MessageBox.Show("Услуга Добавлена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        private void UpdateServiceData()
        {
            if (SelectedServiceIsNull())
                MessageBox.Show("Выбирете услугу", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _selectedService.Title = TitleService;
                _selectedService.Description = DescriptionService;
                _selectedService.CostPerHour = CostPerHour;
                _serviceService.Update(_selectedService);
                MessageBox.Show("Данные услуги  успешно обновлены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateLists();
            }
        }
        public void DeleteService()
        {
            if (!SelectedServiceIsNull())
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _serviceService.Delete(SelectedService);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите услугу", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion


    }
}
