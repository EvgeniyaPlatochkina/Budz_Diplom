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
    public class ReportService
    {
        private ApplicationDbContext _ctx;
        public ReportService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ICollection<Report> GetReport()
            => _ctx.Reports
            .Include(u => u.User)
            .ToList();
        public Report? GetReport(int id)
            => _ctx.Reports.SingleOrDefault(c => c.Id == id);
        public void Insert(Report report)
        {
            _ctx.Reports.Add(report);
            _ctx.SaveChanges();
        }
        public void Update(Report report)
        {
            _ctx.Reports.Update(report);
            _ctx.SaveChanges();
        }
        public void Delete(Report report)
        {
            _ctx.Reports.Remove(report);
            _ctx.SaveChanges();
        }
    }
}
