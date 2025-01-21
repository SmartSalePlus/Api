using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Configurations;

internal sealed class BuyerConfiguration : IEntityTypeConfiguration<Buyer> {
    public void Configure(EntityTypeBuilder<Buyer> builder) {
        builder.HasIndex(x => x.Name);

        builder.HasMany(x => x.Invoices)
            .WithOne(x => x.Buyer)
            .HasForeignKey(x => x.BuyerId);
    }
}