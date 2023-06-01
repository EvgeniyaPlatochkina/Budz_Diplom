using Diplom.Data;
using Diplom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Services
{
    public class EmployeesService
    {
        private ApplicationDbContext _ctx;
        public EmployeesService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Еmployees> GetЕmployees()
            => _ctx.Еmployees.ToList();
        public Еmployees? GetЕmployee(int id)
            => _ctx.Еmployees.SingleOrDefault(c => c.Id == id);
        public void Insert(Еmployees еmployees)
        {
            _ctx.Еmployees.Add(еmployees);
            _ctx.SaveChanges();
        }
        public void Update(Еmployees еmployees)
        {
            _ctx.Еmployees.Update(еmployees);
            _ctx.SaveChanges();
        }
        public void Delete(Еmployees еmployees)
        {
            _ctx.Еmployees.Remove(еmployees);
            _ctx.SaveChanges();
        }
    }
}
