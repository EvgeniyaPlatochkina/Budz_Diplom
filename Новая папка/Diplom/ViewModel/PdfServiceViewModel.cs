using Diplom.Data;
using Diplom.Data.Entities;
using Diplom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.ViewModel
{
    public class PdfServiceViewModel :ViewModelBase
    {

        public PdfServiceViewModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _organizationService = new(_ctx);
            _productService = new(_ctx);
            _saleServiceSale = new(_ctx);
            _employeesProduct = new(_ctx);
            DateOfSaleProduct = DateTime.Now;
            ServicesFilthersTtile = new List<string> { "Не выбрана" };
            ServiceSorts = new List<string> { "Не выбрана", "По стоимости(убыв.)", "По стоимости(возр.)", };
            ServicesFilthersTtile.AddRange(_productService.GetServices().Select(c => c.Title));
            SelectedServiceFiltherTitle = ServicesFilthersTtile[0];
            SelectedServiceSort = ServiceSorts[0];
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            UpdateLists();

        }
        private ApplicationDbContext _ctx;
        private ServiceService _productService;
        private OrganizationService _organizationService;
        private void UpdateLists()
        {

            SaleServices = new List<SaleService>(GetSaleService()).ToList();
            EmployeesList = _employeesProduct.GetЕmployees();
            ServiceCount = $"{SaleServices.Count}";
            GetServiceIncome();
            GetServiceProfit();
        }
        #region Search Filter Sort
        private string _searchServiceValue;
        private string _selectedProductFilther;
        private string _selectedServiceFiltherTitle;
        private string _selectedServiceSort;
        private string _serviceCount;
        private string _categorieName;
        private decimal _productsIncome;
        private decimal _productsProfit;
        private string _servicesCount;
        private DateTime _startDate;
        private DateTime _endDate;
        public DateTime StartDate
        {
            get => _startDate; set
            {
                Set(ref _startDate, value, nameof(StartDate));
                UpdateLists();
            }
        }
        public DateTime EndDate
        {
            get => _endDate; set
            {
                Set(ref _endDate, value, nameof(EndDate));
                UpdateLists();
            }
        }
        
        
        public List<string> ServicesFilthersTtile { get; set; } = null!;
        public List<string> ServiceSorts { get; set; } = null!;
        public string CategorieName { get => _categorieName; set => Set(ref _categorieName, value, nameof(CategorieName)); }
        public string ServiceCount { get => _serviceCount; set => Set(ref _serviceCount, value, nameof(ServiceCount)); }
        public decimal ServicesIncome { get => _productsIncome; set => Set(ref _productsIncome, value, nameof(ServicesIncome)); }
        public decimal ServicesProfit { get => _productsProfit; set => Set(ref _productsProfit, value, nameof(ServicesProfit)); }
        public string ServicesCount { get => _servicesCount; set => Set(ref _servicesCount, value, nameof(ServicesCount)); }

        private void GetServiceIncome()
        {
            ServicesIncome = 0;
            foreach (var item in SaleServices)
            {
                ServicesIncome += Math.Ceiling(item.Income);

            }
        }
        private void GetServiceProfit()
        {
            ServicesProfit = 0;
            foreach (var item in SaleServices)
            {
                ServicesProfit += Math.Ceiling(item.Profit);

            }
        }
        public string SearchServiceValue
        {
            get => _searchServiceValue; set
            {
                if (Set(ref _searchServiceValue, value, nameof(SearchServiceValue)))
                    UpdateLists();
            }
        }
        public string SelectedServiceFiltherTitle
        {
            get => _selectedServiceFiltherTitle; set
            {
                if (Set(ref _selectedServiceFiltherTitle, value, nameof(SelectedServiceFiltherTitle)))
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
      
        private List<SaleService> FiltherServiceTitle(List<SaleService> productOrders)
        {
            if (!(SelectedServiceFiltherTitle == ServicesFilthersTtile[0]))
                return productOrders.Where(p => p.Service.Title == SelectedServiceFiltherTitle).ToList();
            else
                return productOrders;
        }

        private ICollection<SaleService> SortService(ICollection<SaleService> productOrders)
        {
            if (SelectedServiceSort == ServiceSorts[1])
                return productOrders.OrderByDescending(p => p.Income).ToList();
            else if (SelectedServiceSort == ServiceSorts[2])
                return productOrders.OrderBy(p => p.Income).ToList();
            else
                return productOrders;
        }
        #endregion
        #region SaleService

        private string _articleProduct;
        private DateTime _dateOfSaleProduct;
        private decimal _profit;

        private List<Organization> _organizationsSaleProduct;
        private List<Service> _productsSaleProduct;
        private List<Еmployees> _еmployeesList;
        private List<SaleService> _saleService;

        private Organization _selectedorganizationSaleProduct;
        private Service _selectedServiceSaleProduct;
        private Еmployees _selectedеmployees;


        private EmployeesService _employeesProduct;
        private SaleServiceService _saleServiceSale;

        private ICollection<SaleService> GetSaleService() => SortService(SearchSaleService(FiltherServiceTitle(_saleServiceSale.GetSaleService().Where(d => d.DateOfSale >= StartDate && d.DateOfSale <= EndDate).ToList())));

        public List<SaleService> SaleServices { get => _saleService; set => Set(ref _saleService, value, nameof(SaleServices)); }
        public List<Еmployees> EmployeesList { get => _еmployeesList; set => Set(ref _еmployeesList, value, nameof(EmployeesList)); }
        public Еmployees SelectedEmployees { get => _selectedеmployees; set => Set(ref _selectedеmployees, value, nameof(SelectedEmployees)); }
        public Organization SelectedorganizationSaleProduct { get => _selectedorganizationSaleProduct; set => Set(ref _selectedorganizationSaleProduct, value, nameof(SelectedorganizationSaleProduct)); }
        public Service SelectedServiceSaleProduct
        {
            get => _selectedServiceSaleProduct;
            set
            {
                Set(ref _selectedServiceSaleProduct, value, nameof(SelectedServiceSaleProduct));
            }
        }


        public string ArticleProduct { get => _articleProduct; set => Set(ref _articleProduct, value, nameof(ArticleProduct)); }
        public DateTime DateOfSaleProduct { get => _dateOfSaleProduct; set => Set(ref _dateOfSaleProduct, value, nameof(DateOfSaleProduct)); }
        public List<Organization> OrganizationsSaleProduct { get => _organizationsSaleProduct; set => Set(ref _organizationsSaleProduct, value, nameof(OrganizationsSaleProduct)); }
        public List<Service> ServiceSaleProduct { get => _productsSaleProduct; set => Set(ref _productsSaleProduct, value, nameof(ServiceSaleProduct)); }

        public decimal Profit { get => _profit; set => Set(ref _profit, value, nameof(Profit)); }


        #endregion
    }
}
