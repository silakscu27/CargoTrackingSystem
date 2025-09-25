using CargoTrackingSystem.Domain.Entities;
using GenericRepository;

namespace CargoTrackingSystem.Domain.Repositories;

public interface IUserRepository : IRepository<AppUser>
{
    Task<AppUser?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<List<AppUser>> GetActiveUsersAsync(CancellationToken cancellationToken);
}
