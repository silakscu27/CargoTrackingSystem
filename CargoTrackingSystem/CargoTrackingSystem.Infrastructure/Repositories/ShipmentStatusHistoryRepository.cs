using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using CargoTrackingSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CargoTrackingSystem.Infrastructure.Repositories;

public sealed class ShipmentStatusHistoryRepository : BaseRepository<ShipmentStatusHistory>, IShipmentStatusHistoryRepository
{
    public ShipmentStatusHistoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<ShipmentStatusHistory>> GetByShipmentIdAsync(Guid shipmentId, CancellationToken cancellationToken)
    {
        return await _context.ShipmentStatusHistories
            .Where(h => h.ShipmentId == shipmentId)
            .ToListAsync(cancellationToken);
    }
    public async Task<ShipmentStatusHistory?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.ShipmentStatusHistories
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }
    public async Task<List<ShipmentStatusHistory>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.ShipmentStatusHistories.ToListAsync(cancellationToken);
    }


}
