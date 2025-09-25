using CargoTrackingSystem.Domain.Entities;
using GenericRepository;

namespace CargoTrackingSystem.Domain.Repositories;

public interface IWarehouseRepository : IRepository<Warehouse>
{
    // Fetch all active repositories
    Task<List<Warehouse>> GetActiveWarehousesAsync(CancellationToken cancellationToken);
}
