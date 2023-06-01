using Diplom.Data;
using Diplom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Services
{
    public class RoleService
    {
        private ApplicationDbContext _ctx;
        public RoleService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Role> GetRole()
            => _ctx.Roles
            .ToList();
        public Role? GetRole(int id)
            => _ctx.Roles.SingleOrDefault(c => c.Id == id);
        public void Insert(Role role)
        {
            _ctx.Roles.Add(role);
            _ctx.SaveChanges();
        }
        public void Update(Role role)
        {
            _ctx.Roles.Update(role);
            _ctx.SaveChanges();
        }
        public void Delete(Role role)
        {
            _ctx.Roles.Remove(role);
            _ctx.SaveChanges();
        }
    }
}
