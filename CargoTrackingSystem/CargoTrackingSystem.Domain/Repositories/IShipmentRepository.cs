using CargoTrackingSystem.Domain.Entities;
using GenericRepository;

namespace CargoTrackingSystem.Domain.Repositories;

public interface IShipmentRepository : IRepository<Shipment>
{
    Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber, CancellationToken cancellationToken);
    Task<List<Shipment>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
    Task<List<Shipment>> GetByStatusAsync(string status, CancellationToken cancellationToken);
}
