using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Configurations;

internal sealed class ReceptionDetailConfiguration : IEntityTypeConfiguration<ReceptionDetail> {
    public void Configure(EntityTypeBuilder<ReceptionDetail> builder) {
        builder.HasKey(x => new { x.ReceptionId, x.ProductId });
    }
}