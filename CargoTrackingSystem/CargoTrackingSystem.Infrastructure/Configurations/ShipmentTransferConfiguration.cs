using CargoTrackingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargoTrackingSystem.Infrastructure.Configurations;

internal sealed class ShipmentTransferConfiguration : IEntityTypeConfiguration<ShipmentTransfer>
{
    public void Configure(EntityTypeBuilder<ShipmentTransfer> builder)
    {
        builder.ToTable("ShipmentTransfers");

        builder.HasKey(st => st.Id);

        builder.Property(st => st.TransferStatus)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(st => st.ScheduledDate)
               .HasColumnType("datetime2");

        builder.Property(st => st.ActualDate)
               .HasColumnType("datetime2");

        builder.Property(st => st.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(st => st.Shipment)
               .WithMany(s => s.Transfers)
               .HasForeignKey(st => st.ShipmentId);

        builder.HasOne(st => st.FromWarehouse)
               .WithMany(w => w.ShipmentTransfersFrom)
               .HasForeignKey(st => st.FromWarehouseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(st => st.ToWarehouse)
               .WithMany(w => w.ShipmentTransfersTo)
               .HasForeignKey(st => st.ToWarehouseId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
