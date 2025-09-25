using CargoTrackingSystem.Domain.Abstractions;

namespace CargoTrackingSystem.Domain.Entities;

public sealed class Warehouse : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<ShipmentTransfer> ShipmentTransfersFrom { get; set; } = new HashSet<ShipmentTransfer>();
    public ICollection<ShipmentTransfer> ShipmentTransfersTo { get; set; } = new HashSet<ShipmentTransfer>();
}
