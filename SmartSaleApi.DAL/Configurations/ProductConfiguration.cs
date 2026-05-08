using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSaleApi.Core.Models;

namespace SmartSaleApi.DAL.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product> {
    public void Configure(EntityTypeBuilder<Product> builder) {
        builder.HasIndex(x => x.Name);
    }
}