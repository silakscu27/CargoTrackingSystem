using CargoTrackingSystem.Domain.Abstractions;

namespace CargoTrackingSystem.Domain.Entities;

public sealed class Shipment : Entity
{
    public string TrackingNumber { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public string Dimensions { get; set; } = string.Empty;
    public decimal ContentValue { get; set; }
    public string ContentType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string CurrentLocation { get; set; } = string.Empty;
    public DateTime? EstimatedDelivery { get; set; }
    public DateTime? ActualDelivery { get; set; }

    public Guid SenderCustomerId { get; set; }
    public Customer SenderCustomer { get; set; }

    public Guid ReceiverCustomerId { get; set; }
    public Customer ReceiverCustomer { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    // Relations
    public ICollection<ShipmentStatusHistory> StatusHistories { get; set; } = new HashSet<ShipmentStatusHistory>();
}
