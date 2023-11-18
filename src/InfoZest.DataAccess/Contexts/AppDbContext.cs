using InfoZest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoZest.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Asset> Assets { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<InvalidProduct> InvalidProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Asset)
            .WithOne()
            .HasForeignKey<Product>(p => p.AssetId)
            .IsRequired(false);

        modelBuilder.Entity<InvalidProduct>()
            .HasOne(p => p.Product)
            .WithOne()
            .HasForeignKey<InvalidProduct>(i => i.ProductId);
    }
}