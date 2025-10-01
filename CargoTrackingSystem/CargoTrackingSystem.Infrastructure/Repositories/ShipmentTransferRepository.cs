using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using CargoTrackingSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CargoTrackingSystem.Infrastructure.Repositories;

public sealed class ShipmentTransferRepository : BaseRepository<ShipmentTransfer>, IShipmentTransferRepository
{
    public ShipmentTransferRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<ShipmentTransfer>> GetByShipmentIdAsync(Guid shipmentId, CancellationToken cancellationToken)
    {
        return await _context.ShipmentTransfers
            .Where(t => t.ShipmentId == shipmentId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<ShipmentTransfer>> GetByWarehouseIdAsync(Guid warehouseId, CancellationToken cancellationToken)
    {
        return await _context.ShipmentTransfers
            .Where(t => t.FromWarehouseId == warehouseId || t.ToWarehouseId == warehouseId)
            .ToListAsync(cancellationToken);
    }
    public async Task<List<ShipmentTransfer>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.ShipmentTransfers.ToListAsync(cancellationToken);
    }

    public async Task<ShipmentTransfer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.ShipmentTransfers
            .FirstOrDefaultAsync(st => st.Id == id, cancellationToken);
    }
}
