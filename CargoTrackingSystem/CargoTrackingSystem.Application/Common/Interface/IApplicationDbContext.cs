using CargoTrackingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoTrackingSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<ShipmentStatusHistory> ShipmentStatusHistories { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<ShipmentTransfer> ShipmentTransfers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}
 