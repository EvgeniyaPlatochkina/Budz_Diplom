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
    public class SaleServiceService
    {
        private ApplicationDbContext _ctx;
        public SaleServiceService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<SaleService> GetSaleService()
            => _ctx.SaleServices
            .Include(ss => ss.Еmployees)
            .Include(ss => ss.Organization)
            .Include(ss => ss.Service) 
            .ToList();
        public SaleService? GetSaleService(int id)
            => _ctx.SaleServices
            .Include(ss => ss.Еmployees)
            .Include(ss => ss.Organization)
            .Include(ss => ss.Service)
            .SingleOrDefault(po => po.Id == id);
        public void Insert(SaleService productOrder)
        {
            _ctx.SaleServices.Add(productOrder);
            _ctx.SaveChanges();
        }
        public void Update(SaleService productOrder)
        {
            _ctx.SaleServices.Update(productOrder);
            _ctx.SaveChanges();
        }
        public void Delete(SaleService productOrder)
        {
            _ctx.SaleServices.Remove(productOrder);
            _ctx.SaveChanges();
        }
    }
}
