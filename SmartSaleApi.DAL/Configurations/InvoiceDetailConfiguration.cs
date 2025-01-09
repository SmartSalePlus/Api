
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Configurations;

internal sealed class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail> {
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder) {
        builder.HasKey(x => new { x.InvoiceId, x.ProductId });
    }
}