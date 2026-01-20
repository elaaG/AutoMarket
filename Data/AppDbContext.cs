using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AutoMarket.Models;

namespace AutoMarket.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }

        public DbSet<Verification> Verifications { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Annonces)
                .WithOne(a => a.Seller)
                .HasForeignKey(a => a.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Annonce>()
                .HasOne(a => a.Vehicule)
                .WithOne(v => v.Annonce)
                .HasForeignKey<Annonce>(a => a.VehiculeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
