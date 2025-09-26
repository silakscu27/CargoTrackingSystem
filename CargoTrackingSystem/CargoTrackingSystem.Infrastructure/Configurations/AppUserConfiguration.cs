using CargoTrackingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargoTrackingSystem.Infrastructure.Configurations;

internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers");

        // Key IdentityUser<Guid> (Id)
        builder.HasKey(u => u.Id);

        // Properties
        builder.Property(u => u.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Ignore(u => u.FullName); // computed property

        builder.Property(u => u.RefreshToken)
               .HasMaxLength(500);

        builder.Property(u => u.RefreshTokenExpires);

        // Relationships

        // 1:1 Customer
        builder.HasOne(u => u.Customer)
               .WithOne(c => c.User)
               .HasForeignKey<Customer>(c => c.UserId);

        // 1:N Shipments (CreatedBy)
        builder.HasMany(u => u.CreatedShipments)
               .WithOne(s => s.Creator)
               .HasForeignKey(s => s.CreatedBy);

        // 1:N ShipmentStatusHistory (CreatedBy)
        builder.HasMany(u => u.CreatedStatusHistories)
               .WithOne(sh => sh.Creator)
               .HasForeignKey(sh => sh.CreatedBy);
    }
}
