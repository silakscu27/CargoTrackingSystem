using CargoTrackingSystem.Domain.Abstractions;

namespace CargoTrackingSystem.Domain.Entities;

public sealed class ShipmentStatusHistory : Entity
{
    public Guid ShipmentId { get; set; }
    public Shipment Shipment { get; set; }

    public string Status { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Guid CreatedBy { get; set; }
}
