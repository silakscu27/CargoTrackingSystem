using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using CargoTrackingSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CargoTrackingSystem.Infrastructure.Repositories;

public sealed class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
{
    public WarehouseRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Warehouse>> GetActiveWarehousesAsync(CancellationToken cancellationToken)
    {
        return await _context.Warehouses
            .Where(w => w.IsActive)
            .ToListAsync(cancellationToken);
    }
}
