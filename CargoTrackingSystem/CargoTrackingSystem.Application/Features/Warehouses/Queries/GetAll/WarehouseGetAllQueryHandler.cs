using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Warehouses.Queries.GetAll;

internal sealed class WarehouseGetAllQueryHandler(
    IWarehouseRepository warehouseRepository
) : IRequestHandler<WarehouseGetAllQuery, Result<List<Warehouse>>>
{
    public async Task<Result<List<Warehouse>>> Handle(WarehouseGetAllQuery request, CancellationToken cancellationToken)
    {
        List<Warehouse> warehouses = await warehouseRepository.GetAllAsync(cancellationToken);

        return warehouses.Any()
            ? Result<List<Warehouse>>.Succeed(warehouses)
            : Result<List<Warehouse>>.Failure("Depo bulunamadı");
    }
}
