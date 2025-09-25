using Microsoft.AspNetCore.Identity;

namespace CargoTrackingSystem.Domain.Entities;

public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }

    // Navigation Properties

    // 1:1 Customer
    public Customer? Customer { get; set; }

    // 1:N Shipments 
    public ICollection<Shipment> CreatedShipments { get; set; } = new HashSet<Shipment>();

    // 1:N ShipmentStatusHistory 
    public ICollection<ShipmentStatusHistory> CreatedStatusHistories { get; set; } = new HashSet<ShipmentStatusHistory>();
}
