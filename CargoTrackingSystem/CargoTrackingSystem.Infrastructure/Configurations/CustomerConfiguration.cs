using CargoTrackingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargoTrackingSystem.Infrastructure.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CompanyName)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(c => c.TaxNumber)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(c => c.Address)
               .HasMaxLength(500);

        builder.Property(c => c.City)
               .HasMaxLength(100);

        builder.Property(c => c.Country)
               .HasMaxLength(100);

        builder.Property(c => c.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        // 1:1 AppUser
        builder.HasOne(c => c.User)
               .WithOne(u => u.Customer)
               .HasForeignKey<Customer>(c => c.UserId);

        // 1:N Sent Shipments
        builder.HasMany(c => c.SentShipments)
               .WithOne(s => s.SenderCustomer)
               .HasForeignKey(s => s.SenderCustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        // 1:N Received Shipments
        builder.HasMany(c => c.ReceivedShipments)
               .WithOne(s => s.ReceiverCustomer)
               .HasForeignKey(s => s.ReceiverCustomerId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
