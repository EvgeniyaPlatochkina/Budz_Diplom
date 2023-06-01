using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data.Entities
{
    public class Categorie
    {
        public Categorie()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Product> Products { get; set; } = null!;
    }
}
