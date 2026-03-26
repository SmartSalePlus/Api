using Microsoft.EntityFrameworkCore;
using SmartSaleApi.DAL.Configurations;
using SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Contexts;

public sealed class SmartSaleDbContext(DbContextOptions<SmartSaleDbContext> options) : DbContext(options) {
    internal DbSet<Buyer> Buyers { get; set; }
    internal DbSet<Invoice> Invoices { get; set; }
    internal DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    internal DbSet<Product> Products { get; set; }
    internal DbSet<Reception> Receptions { get; set; }
    internal DbSet<ReceptionDetail> ReceptionDetails { get; set; }
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new BuyerConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceDetailConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ReceptionConfiguration());
        modelBuilder.ApplyConfiguration(new ReceptionDetailConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}