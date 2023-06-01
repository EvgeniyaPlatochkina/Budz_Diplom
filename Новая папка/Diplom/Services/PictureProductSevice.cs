using Diplom.Data;
using Diplom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Services
{
    public class PictureProductSevice
    {
        private ApplicationDbContext _ctx;
        public PictureProductSevice(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<PictureProduct> GetCategories()
            => _ctx.PictureProducts.ToList();
        public PictureProduct? GetCategory(int id)
            => _ctx.PictureProducts.SingleOrDefault(c => c.Id == id);
        public void Insert(PictureProduct pictureProduct)
        {
            _ctx.PictureProducts.Add(pictureProduct);
            _ctx.SaveChanges();
        }
        public void Update(PictureProduct pictureProduct)
        {
            _ctx.PictureProducts.Update(pictureProduct);
            _ctx.SaveChanges();
        }
        public void Delete(PictureProduct pictureProduct)
        {
            _ctx.PictureProducts.Remove(pictureProduct);
            _ctx.SaveChanges();
        }
    }
}
