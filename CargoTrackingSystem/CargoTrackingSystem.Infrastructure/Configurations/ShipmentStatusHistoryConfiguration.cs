using CargoTrackingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargoTrackingSystem.Infrastructure.Configurations;

internal sealed class ShipmentStatusHistoryConfiguration : IEntityTypeConfiguration<ShipmentStatusHistory>
{
    public void Configure(EntityTypeBuilder<ShipmentStatusHistory> builder)
    {
        builder.ToTable("ShipmentStatusHistories");

        builder.HasKey(sh => sh.Id);

        builder.Property(sh => sh.Status)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(sh => sh.Location)
               .HasMaxLength(200);

        builder.Property(sh => sh.Description)
               .HasMaxLength(500);

        builder.Property(sh => sh.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(sh => sh.Shipment)
               .WithMany(s => s.StatusHistories)
               .HasForeignKey(sh => sh.ShipmentId)
               .OnDelete(DeleteBehavior.NoAction); 

        builder.HasOne(sh => sh.Creator)
               .WithMany(u => u.CreatedStatusHistories)
               .HasForeignKey(sh => sh.CreatedBy)
               .OnDelete(DeleteBehavior.NoAction); 
    }
}