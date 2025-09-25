using CargoTrackingSystem.Domain.Abstractions;

namespace CargoTrackingSystem.Domain.Entities;

public sealed class ShipmentTransfer : Entity
{
    public Guid ShipmentId { get; set; }
    public Guid FromWarehouseId { get; set; }
    public Guid ToWarehouseId { get; set; }

    public string TransferStatus { get; set; } = string.Empty;
    public DateTime? ScheduledDate { get; set; }
    public DateTime? ActualDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Shipment? Shipment { get; set; }
    public Warehouse? FromWarehouse { get; set; }
    public Warehouse? ToWarehouse { get; set; }
}
