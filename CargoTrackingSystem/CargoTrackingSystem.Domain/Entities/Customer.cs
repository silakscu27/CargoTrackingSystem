using CargoTrackingSystem.Domain.Abstractions;

namespace CargoTrackingSystem.Domain.Entities;

public sealed class Customer : Entity
{
    public Guid UserId { get; set; } 
    public string CompanyName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    public AppUser? User { get; set; }

    // Shipments relationship
    public ICollection<Shipment> SentShipments { get; set; } = new HashSet<Shipment>();
    public ICollection<Shipment> ReceivedShipments { get; set; } = new HashSet<Shipment>();
}
