using Microsoft.EntityFrameworkCore;
using AutoMarket.Models;

namespace AutoMarket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Annonces)
                .WithOne(a => a.Seller)
                .HasForeignKey(a => a.SellerId);

            modelBuilder.Entity<Annonce>()
                .HasOne(a => a.Vehicule)
                .WithOne(v => v.Annonce)
                .HasForeignKey<Annonce>(a => a.VehiculeId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
