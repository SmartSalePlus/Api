using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product> {
    public void Configure(EntityTypeBuilder<Product> builder) {
        builder.HasMany(x => x.PriceHistories)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

        builder.HasMany(x => x.ReceptionDetails)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

        builder.HasMany(x => x.InvoiceDetails)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
    }
}