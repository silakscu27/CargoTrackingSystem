using CargoTrackingSystem.Domain.Entities;

namespace CargoTrackingSystem.Domain.Repositories
{
    public interface IPackageRepository
    {
        Task<Package?> GetByIdAsync(int id);
        Task<IEnumerable<Package>> GetAllAsync();
        Task AddAsync(Package package);
        Task UpdateAsync(Package package);
        Task DeleteAsync(Package package);
    }
}
