using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data.Entities
{
    public class Organization
    {

        public Organization()
        {
            SaleProducts = new HashSet<SaleProduct>();
            SaleServices = new HashSet<SaleService>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public int INN { get; set; }
        public int KPP { get; set; }
        public string Owner { get; set; }
        public string MailingAddress { get; set; }
        public int NumberPhone { get; set; }
        public int BankAccountNumber { get; set; }
        public int OGRN { get; set; }
        public string OKATO { get; set; }
        public int OKPO { get; set; }

        public ICollection<SaleProduct> SaleProducts { get; set; } = null!;
        public ICollection<SaleService> SaleServices { get; set; } = null!;
    }
}
