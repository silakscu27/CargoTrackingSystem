using CargoTrackingSystem.Domain.Entities;
using GenericRepository;

namespace CargoTrackingSystem.Domain.Repositories;

public interface IShipmentTransferRepository : IRepository<ShipmentTransfer>
{
    // Get all transfers for a specific shipment
    Task<List<ShipmentTransfer>> GetByShipmentIdAsync(Guid shipmentId, CancellationToken cancellationToken);

    // Retrieve transfers from or to a specific warehouse
    Task<List<ShipmentTransfer>> GetByWarehouseIdAsync(Guid warehouseId, CancellationToken cancellationToken);
}
