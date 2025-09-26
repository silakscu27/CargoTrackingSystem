using CargoTrackingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargoTrackingSystem.Infrastructure.Configurations;

internal sealed class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(w => w.Code)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(w => w.Code)
               .IsUnique();

        builder.Property(w => w.Address)
               .HasMaxLength(500);

        builder.Property(w => w.City)
               .HasMaxLength(100);

        builder.Property(w => w.Country)
               .HasMaxLength(100);

        builder.Property(w => w.Phone)
               .HasMaxLength(20);

        builder.Property(w => w.IsActive)
               .HasDefaultValue(true);

        builder.Property(w => w.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");
    }
}
