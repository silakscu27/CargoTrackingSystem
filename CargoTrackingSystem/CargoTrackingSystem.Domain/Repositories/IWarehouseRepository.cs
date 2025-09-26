using CargoTrackingSystem.Domain.Entities;

namespace CargoTrackingSystem.Domain.Repositories;

public interface IWarehouseRepository : IRepository<Warehouse>
{
    // Fetch all active repositories
    Task<List<Warehouse>> GetActiveWarehousesAsync(CancellationToken cancellationToken);
}