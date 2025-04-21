using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSaleApi.DAL.Entities;

namespace SmartSaleApi.DAL.Configurations;

internal sealed class ReceptionConfiguration : IEntityTypeConfiguration<Reception> {
    public void Configure(EntityTypeBuilder<Reception> builder) {
        builder.HasIndex(x => x.Date);
    }
}