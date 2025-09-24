using CargoTrackingSystem.Domain.Entities;

namespace CargoTrackingSystem.Domain.Repositories
{
    public interface ITrackingStatusRepository
    {
        Task<TrackingStatus?> GetByIdAsync(int id);
        Task<IEnumerable<TrackingStatus>> GetByPackageIdAsync(int packageId);
        Task AddAsync(TrackingStatus status);
    }
}
