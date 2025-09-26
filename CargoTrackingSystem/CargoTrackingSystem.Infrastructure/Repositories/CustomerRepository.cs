using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using CargoTrackingSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CargoTrackingSystem.Infrastructure.Repositories;

public sealed class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Customer>> GetByIdsAsync(List<Guid> customerIds, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .Where(c => customerIds.Contains(c.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Customers
            .ToListAsync(cancellationToken);
    }
}