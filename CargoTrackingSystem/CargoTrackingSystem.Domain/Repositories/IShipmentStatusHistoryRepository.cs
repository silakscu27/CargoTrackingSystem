using CargoTrackingSystem.Domain.Entities;

namespace CargoTrackingSystem.Domain.Repositories;

public interface IShipmentStatusHistoryRepository : IRepository<ShipmentStatusHistory>
{
    // Retrieve all status history for a specific ShipmentId
    Task<List<ShipmentStatusHistory>> GetByShipmentIdAsync(Guid shipmentId, CancellationToken cancellationToken);
    Task<ShipmentStatusHistory?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<ShipmentStatusHistory>> GetAllAsync(CancellationToken cancellationToken);

}