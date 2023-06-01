using Diplom.Data;
using Diplom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Services
{
    public class CategorieService
    {
        private ApplicationDbContext _ctx;
        public CategorieService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Categorie> GetCategories()
            => _ctx.Categories.ToList();
        public Categorie? GetCategory(int id)
            => _ctx.Categories.SingleOrDefault(c => c.Id == id);
        public void Insert(Categorie category)
        {
            _ctx.Categories.Add(category);
            _ctx.SaveChanges();
        }
        public void Update(Categorie category)
        {
            _ctx.Categories.Update(category);
            _ctx.SaveChanges();
        }
        public void Delete(Categorie category)
        {
            _ctx.Categories.Remove(category);
            _ctx.SaveChanges();
        }
    }
}
