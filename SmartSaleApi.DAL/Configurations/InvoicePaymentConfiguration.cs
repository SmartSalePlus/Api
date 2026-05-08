using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.DAL.Configurations;

internal class InvoicePaymentConfiguration : IEntityTypeConfiguration<InvoicePayment> {
    public void Configure(EntityTypeBuilder<InvoicePayment> builder) {
        builder.HasIndex(x => x.Date);
    }
}
