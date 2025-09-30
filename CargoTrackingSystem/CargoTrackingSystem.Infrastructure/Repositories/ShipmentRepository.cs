using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using CargoTrackingSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CargoTrackingSystem.Infrastructure.Repositories;

public sealed class ShipmentRepository : BaseRepository<Shipment>, IShipmentRepository
{
    public ShipmentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber, CancellationToken cancellationToken)
    {
        return await _context.Shipments
            .FirstOrDefaultAsync(s => s.TrackingNumber == trackingNumber, cancellationToken);
    }

    public async Task<List<Shipment>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
    {
        return await _context.Shipments
            .Where(s => s.SenderCustomerId == customerId || s.ReceiverCustomerId == customerId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Shipment>> GetByStatusAsync(string status, CancellationToken cancellationToken)
    {
        return await _context.Shipments
            .Where(s => s.Status == status)
            .ToListAsync(cancellationToken);
    }
    public async Task<List<Shipment>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Shipments.ToListAsync(cancellationToken);
    }

    public async Task<Shipment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Shipments
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }
}
