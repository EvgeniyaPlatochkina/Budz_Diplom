using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data.Entities
{
    public class Product
    {
        private decimal _totalCost;
        public Product()
        {
            SaleProducts = new HashSet<SaleProduct>();
        }
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int PictureProductId { get; set; }
        public decimal Cost { get; set; }
        public string Guarantee { get; set; }
        public decimal Discount { get; set; }
        public int CategorieId { get; set; }


        public Categorie Categorie { get; set; } = null!;
        public PictureProduct PictureProduct { get; set; } = null!;

        public ICollection<SaleProduct> SaleProducts { get; set; } = null!;



        public bool IsDiscount { get => Discount != 0; }
        public decimal CorrectCost { get => IsDiscount ? Cost - (Cost * (Discount / 100)) : Cost; }
        public int CorrectDiscount { get => (int)(Discount); }
        public decimal TotalCost_ { get => Cost += Cost; }


    [NotMapped]
        public decimal ProfitSale => Cost /2;

      
        [NotMapped]
        public decimal SumProfitSale
        {
            get
            {
                decimal price = 0;
                foreach (var item in SaleProducts)
                {
                    price += item.Profit;
                }
                return price;
            }
            set { }
        }
    }
}
