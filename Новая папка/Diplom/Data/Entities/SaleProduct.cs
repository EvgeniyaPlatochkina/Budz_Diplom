using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data.Entities
{
    public class SaleProduct
    {
        //public SaleProduct()
        //{
        //    SaleReport = new HashSet<SaleReport>();
        //}
        public int Id { get; set; }
        public string Article { get; set; }
        public DateTime DateOfSale { get; set; }
        public decimal Income { get; set; }
        public decimal Profit { get; set; }
        public int OrganizationId { get; set; }
        public int ProductId { get; set; }
        public int ЕmployeesId { get; set; }




        public Product Product { get; set; } = null!;
        public Organization Organization { get; set; } = null!;
        public Еmployees Еmployees { get; set; } = null!;

        //public ICollection<SaleReport> SaleReport { get; set; } = null!;

        
       

    }
}
