using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data.Entities
{
    public class Service
    {
        public Service()
        {
            
            SaleServices = new HashSet<SaleService>();
        }
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        public decimal CostPerHour { get; set; }
        public ICollection<SaleService> SaleServices { get; set; } = null!;
        [NotMapped]
        public decimal ProfitSale => CostPerHour / 2;
    }
}
