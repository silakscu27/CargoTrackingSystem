using CargoTrackingSystem.Domain.Entities;

namespace CargoTrackingSystem.Domain.Repositories
{
    public interface IShipmentRepository
    {
        Task<Shipment?> GetByIdAsync(int id);
        Task<IEnumerable<Shipment>> GetAllAsync();
        Task AddAsync(Shipment shipment);
        Task UpdateAsync(Shipment shipment);
        Task DeleteAsync(Shipment shipment);
    }
}
