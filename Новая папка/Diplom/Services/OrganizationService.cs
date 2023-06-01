using Diplom.Data;
using Diplom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Services
{
    public class OrganizationService
    {
        private ApplicationDbContext _ctx;
        public OrganizationService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Organization> GetOrganization()
            => _ctx.Organizations.ToList();
        public Organization? GetOrganization(int id)
            => _ctx.Organizations.SingleOrDefault(c => c.Id == id);
        public void Insert(Organization organization)
        {
            _ctx.Organizations.Add(organization);
            _ctx.SaveChanges();
        }
        public void Update(Organization organization)
        {
            _ctx.Organizations.Update(organization);
            _ctx.SaveChanges();
        }
        public void Delete(Organization organization)
        {
            _ctx.Organizations.Remove(organization);
            _ctx.SaveChanges();
        }
    }
}
