namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Queries.GetById;

public sealed class ShipmentStatusHistoryGetByIdDto
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}
