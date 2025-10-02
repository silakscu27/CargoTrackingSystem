using CargoTrackingSystem.Domain.Enums;

namespace CargoTrackingSystem.Application.Features.Shipments.Queries.GetById
{
    public sealed class ShipmentGetByIdDto
    {
        public Guid Id { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;
        public Guid SenderCustomerId { get; set; }
        public Guid ReceiverCustomerId { get; set; }
        public decimal Weight { get; set; }
        public string Dimensions { get; set; } = string.Empty;
        public decimal ContentValue { get; set; }
        public ContentType ContentType { get; set; }
        public ContentType Status { get; set; }
        public string CurrentLocation { get; set; } = string.Empty;
        public DateTime? EstimatedDelivery { get; set; }
        public DateTime? ActualDelivery { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
