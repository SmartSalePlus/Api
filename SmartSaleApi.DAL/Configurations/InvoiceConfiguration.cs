using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Configurations;

internal sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice> {
    public void Configure(EntityTypeBuilder<Invoice> builder) {
        builder.HasMany(x => x.InvoiceDetails)
            .WithOne(x => x.Invoice)
            .HasForeignKey(x => x.InvoiceId);
    }
}