using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiparisNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Contexts
{
    public class SiparisContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-RDITVOK\\CIHAN; database=Siparis; integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urun>().HasMany(I => I.UrunCategories).WithOne(I => I.urun).HasForeignKey(I => I.urunId);
            modelBuilder.Entity<Category>().HasMany(I => I.UrunCategories).WithOne(I => I.category).HasForeignKey(I => I.categoryId);
            modelBuilder.Entity<UrunCategory>().HasIndex(I => new
            {
                I.categoryId,
                I.urunId,
            }).IsUnique();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UrunCategory> UrunCategories { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
