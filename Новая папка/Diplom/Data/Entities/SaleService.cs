using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data.Entities
{
    public class SaleService
    {
        //public SaleService()
        //{
        //    SaleReport = new HashSet<SaleReport>();
        //}
        public int Id { get; set; }
        public string Article { get; set; }
        public DateTime DateOfSale { get; set; }
        public decimal Income { get; set; }
        public decimal Profit { get; set; }
        public int ServiceId { get; set; }
        public int OrganizationId { get; set; }
        public int ЕmployeesiD { get; set; }



        public Еmployees Еmployees { get; set; } = null!;
        public Organization Organization { get; set; } = null!;
        public Service Service { get; set; } = null!;

        //public ICollection<SaleReport> SaleReport { get; set; } = null!;

    }
}
