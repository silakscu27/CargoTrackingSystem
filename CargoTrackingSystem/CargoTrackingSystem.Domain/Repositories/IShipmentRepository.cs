using CargoTrackingSystem.Domain.Entities;

namespace CargoTrackingSystem.Domain.Repositories;

public interface IShipmentRepository : IRepository<Shipment>
{
    Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber, CancellationToken cancellationToken);
    Task<List<Shipment>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
    Task<List<Shipment>> GetByStatusAsync(string status, CancellationToken cancellationToken);

    // to fetch the all shipments
    Task<List<Shipment>> GetAllAsync(CancellationToken cancellationToken);

    // to recieve the shipments by id
    Task<Shipment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}