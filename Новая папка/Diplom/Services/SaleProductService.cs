using Diplom.Data;
using Diplom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Services
{
    public class SaleProductService
    {
        private ApplicationDbContext _ctx;
        public SaleProductService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<SaleProduct> GetSaleProducts()
            => _ctx.SaleProducts
            .Include(sp => sp.Еmployees)
            .Include(sp => sp.Organization)
            .Include(sp => sp.Product)
                    .ThenInclude(pc => pc.Categorie)
            .ToList();
        public SaleProduct? GetSaleProduct(int id)
            => _ctx.SaleProducts
            .Include(sp => sp.Еmployees)
            .Include(sp => sp.Organization)
            .Include(sp => sp.Product)
                    .ThenInclude(pc => pc.Categorie)
            .SingleOrDefault(po => po.Id == id);
        public void Insert(SaleProduct productOrder)
        {
            _ctx.SaleProducts.Add(productOrder);
            _ctx.SaveChanges();
        }
        public void Update(SaleProduct productOrder)
        {
            _ctx.SaleProducts.Update(productOrder);
            _ctx.SaveChanges();
        }
        public void Delete(SaleProduct productOrder)
        {
            _ctx.SaleProducts.Remove(productOrder);
            _ctx.SaveChanges();
        }
    }
}
