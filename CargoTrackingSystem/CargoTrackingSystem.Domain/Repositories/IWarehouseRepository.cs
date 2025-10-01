using CargoTrackingSystem.Domain.Entities;

namespace CargoTrackingSystem.Domain.Repositories;

public interface IWarehouseRepository : IRepository<Warehouse>
{
    // Fetch all active warehouses
    Task<List<Warehouse>> GetActiveWarehousesAsync(CancellationToken cancellationToken);

    // Fetch all warehouses
    Task<List<Warehouse>> GetAllAsync(CancellationToken cancellationToken);

    // Fetch single warehouse by Id
    Task<Warehouse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
