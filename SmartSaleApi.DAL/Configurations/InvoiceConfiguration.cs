using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.DAL.Configurations;

internal sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice> {
    public void Configure(EntityTypeBuilder<Invoice> builder) {
        builder.HasIndex(x => x.Date);
    }
}
