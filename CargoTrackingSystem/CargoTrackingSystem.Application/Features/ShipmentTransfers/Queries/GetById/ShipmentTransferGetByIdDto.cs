using CargoTrackingSystem.Domain.Enums;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Queries.GetById;

public sealed class ShipmentTransferGetByIdDto
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public Guid FromWarehouseId { get; set; }
    public Guid ToWarehouseId { get; set; }
    public TransferStatus TransferStatus { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? ActualDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}
