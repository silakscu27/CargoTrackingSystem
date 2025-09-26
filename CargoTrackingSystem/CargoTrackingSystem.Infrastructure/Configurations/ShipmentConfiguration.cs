using CargoTrackingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargoTrackingSystem.Infrastructure.Configurations;

internal sealed class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.ToTable("Shipments");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.TrackingNumber)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasIndex(s => s.TrackingNumber)
               .IsUnique();

        builder.Property(s => s.Weight)
               .HasPrecision(18, 2);

        builder.Property(s => s.Dimensions)
               .HasMaxLength(200);

        builder.Property(s => s.ContentValue)
               .HasPrecision(18, 2);

        builder.Property(s => s.ContentType)
               .HasMaxLength(100);

        builder.Property(s => s.Status)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.CurrentLocation)
               .HasMaxLength(200);

        builder.Property(s => s.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        // Relationships
        builder.HasOne(s => s.SenderCustomer)
               .WithMany(c => c.SentShipments)
               .HasForeignKey(s => s.SenderCustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.ReceiverCustomer)
               .WithMany(c => c.ReceivedShipments)
               .HasForeignKey(s => s.ReceiverCustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Creator)
               .WithMany(u => u.CreatedShipments)
               .HasForeignKey(s => s.CreatedBy);

        builder.HasMany(s => s.StatusHistories)
               .WithOne(sh => sh.Shipment)
               .HasForeignKey(sh => sh.ShipmentId);

        builder.HasMany(s => s.Transfers)
               .WithOne(t => t.Shipment)
               .HasForeignKey(t => t.ShipmentId);
    }
}
