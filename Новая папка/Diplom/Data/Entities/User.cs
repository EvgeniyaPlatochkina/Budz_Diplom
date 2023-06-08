using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data.Entities
{
    public class User
    {
        public User()
        {
            SaleProducts = new HashSet<SaleProduct>();
            SaleServices = new HashSet<SaleService>();
            Report = new HashSet<Report>();
        }
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public ICollection<SaleProduct> SaleProducts { get; set; } = null!;
        public ICollection<SaleService> SaleServices { get; set; } = null!;
        public ICollection<Report> Report { get; set; } = null!;

        [NotMapped]
        public string FullName { get => $"{LastName} {FirstName} {MiddleName}"; }

        [NotMapped]
        public string Name { get => $"{LastName} {FirstName}"; }
    }
}
