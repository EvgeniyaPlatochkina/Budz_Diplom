using Diplom.Data;
using Diplom.Data.Entities;
using Diplom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diplom.ViewModel
{
    public class PdfViewModel : ViewModelBase
    {
        public PdfViewModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _organizationService = new(_ctx);
            _productService = new(_ctx);
            _categorieService = new(_ctx);
            _saleProductSale = new(_ctx);
            _employeesProduct = new(_ctx);
            ProductsSaleProduct = _productService.GetProducts();

            DateOfSaleProduct = DateTime.Now;
            ProductFilthers = new List<string> { "Не выбрана" };
            ProductFilthersTtile = new List<string> { "Не выбрана" };
            ProductSorts = new List<string> { "Не выбрана", "По стоимости(убыв.)", "По стоимости(возр.)", };
            ProductFilthers.AddRange(_categorieService.GetCategories().Select(c => c.Title));
            ProductFilthersTtile.AddRange(_productService.GetProducts().Select(c => c.Title));
            SelectedProductFilther = ProductFilthers[0];
            SelectedProductFiltherTitle = ProductFilthersTtile[0];
            SelectedProductSort = ProductSorts[0];
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            UpdateLists();
        }
        private ApplicationDbContext _ctx;
        private CategorieService _categorieService;
        private ProductService _productService;
        private OrganizationService _organizationService;
        private void UpdateLists()
        {


            SaleProducts = new List<SaleProduct>(GetSaleProduct()).ToList();
            
            EmployeesList = _employeesProduct.GetЕmployees();
            ProductsCount = $"{SaleProducts.Count}";
            CategorieName = $"{SelectedProductFilther}";

            GetProductIncome();
            GetProductProfit();


        }
        #region Search Filter Sort
        private string _selectedProductFilther;
        private string _selectedProductFiltherTitle;
        private string _selectedProductSort;
        private string _productsCount;
        private string _categorieName;
        private decimal _productsIncome;
        private decimal _productsProfit;
        private string _searchSaleProductValue;
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
        private ICollection<SaleProduct> GetSaleProduct() => SortProducts(SearchSaleProduct(FiltherProducts(FiltherProductsTitle(_saleProductSale.GetSaleProducts().Where(d => d.DateOfSale >= StartDate && d.DateOfSale <= EndDate).ToList()))));
        public List<string> ProductFilthers { get; set; } = null!;
        public List<string> ProductFilthersTtile { get; set; } = null!;
        public List<string> ProductSortDate { get; set; } = null!;
        public List<string> ProductSorts { get; set; } = null!;
        public string CategorieName { get => _categorieName; set => Set(ref _categorieName, value, nameof(CategorieName)); }
        public string ProductsCount { get => _productsCount; set => Set(ref _productsCount, value, nameof(ProductsCount)); }
        public decimal ProductsIncome { get => _productsIncome; set => Set(ref _productsIncome, value, nameof(ProductsIncome)); }
        public decimal ProductsProfit { get => _productsProfit; set => Set(ref _productsProfit, value, nameof(ProductsProfit)); }

        private void GetProductIncome()
        {
            ProductsIncome = 0;
            foreach (var item in SaleProducts)
            {
                ProductsIncome += Math.Ceiling(item.Income);

            }
        }
        private void GetProductProfit()
        {
            ProductsProfit = 0;
            foreach (var item in SaleProducts)
            {
                ProductsProfit += Math.Ceiling(item.Profit);

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
     
        public string SelectedProductSort
        {
            get => _selectedProductSort; set
            {
                if (Set(ref _selectedProductSort, value, nameof(SelectedProductSort)))
                    UpdateLists();
            }
        }
    

       
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

        private ICollection<SaleProduct> SortProducts(ICollection<SaleProduct> productOrders)
        {
            if (SelectedProductSort == ProductSorts[1])
                return productOrders.OrderByDescending(p => p.Income).ToList();
            else if (SelectedProductSort == ProductSorts[2])
                return productOrders.OrderBy(p => p.Income).ToList();
            else
                return productOrders;
        }
        private ICollection<SaleProduct> SortProductsDate(ICollection<SaleProduct> productOrders)
        {
            if (SelectedProductSort == ProductSorts[1])
                return productOrders.OrderByDescending(p => p.DateOfSale).ToList();
            else if (SelectedProductSort == ProductSorts[2])
                return productOrders.OrderBy(p => p.DateOfSale).ToList();
            else
                return productOrders;
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

        private Organization _selectedorganizationSaleProduct;
        private Product _selectedProductSaleProduct;
        private Еmployees _selectedеmployees;


        private EmployeesService _employeesProduct;
        private SaleProductService _saleProductSale;



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
            }
        }


        public string ArticleProduct { get => _articleProduct; set => Set(ref _articleProduct, value, nameof(ArticleProduct)); }
        public DateTime DateOfSaleProduct { get => _dateOfSaleProduct; set => Set(ref _dateOfSaleProduct, value, nameof(DateOfSaleProduct)); }
        public List<Organization> OrganizationsSaleProduct { get => _organizationsSaleProduct; set => Set(ref _organizationsSaleProduct, value, nameof(OrganizationsSaleProduct)); }
        public List<Product> ProductsSaleProduct { get => _productsSaleProduct; set => Set(ref _productsSaleProduct, value, nameof(ProductsSaleProduct)); }

        public decimal Profit { get => _profit; set => Set(ref _profit, value, nameof(Profit)); }


        #endregion
    }
}
