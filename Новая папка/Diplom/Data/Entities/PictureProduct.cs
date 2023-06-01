using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data.Entities
{
    public class PictureProduct
    {
        public PictureProduct()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public string Picture { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = null!;


        [NotMapped]
        public string CorrectPicturePath
        {
            get => (Picture == string.Empty || Picture == null)
                ? @"\Resources\Pictures\NonPicture.png" : @$"\Resources\Pictures\{Picture}";
        }
    }
}
