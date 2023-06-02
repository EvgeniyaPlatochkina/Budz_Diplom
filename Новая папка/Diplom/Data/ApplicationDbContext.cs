using Diplom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const string connectionString = @"Server=localhost\SQLEXPRESS; Database=DIPLOM6; Trusted_Connection=true; TrustServerCertificate=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<SaleService> SaleServices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<PictureProduct> PictureProducts { get; set; }
        public DbSet<Еmployees> Еmployees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
