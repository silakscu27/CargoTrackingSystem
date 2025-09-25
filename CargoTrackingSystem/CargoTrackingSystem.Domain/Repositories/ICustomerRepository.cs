using CargoTrackingSystem.Domain.Entities;
using GenericRepository;

namespace CargoTrackingSystem.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    // List customers with multiple IDs
    Task<List<Customer>> GetByIdsAsync(List<Guid> customerIds, CancellationToken cancellationToken);

    // Fetch all customers
    Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken);
}
