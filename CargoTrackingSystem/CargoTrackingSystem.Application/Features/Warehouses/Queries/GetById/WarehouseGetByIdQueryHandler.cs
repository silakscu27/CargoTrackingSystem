using AutoMapper;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Warehouses.Queries.GetById
{
    internal sealed class WarehouseGetByIdQueryHandler(
        IWarehouseRepository warehouseRepository,
        IMapper mapper
    ) : IRequestHandler<WarehouseGetByIdQuery, Result<WarehouseGetByIdDto>>
    {
        public async Task<Result<WarehouseGetByIdDto>> Handle(WarehouseGetByIdQuery request, CancellationToken cancellationToken)
        {
            // fetch the warehouse
            var warehouse = await warehouseRepository.GetByIdAsync(request.Id, cancellationToken);

            if (warehouse is null)
            {
                return Result<WarehouseGetByIdDto>.Failure("Depo bulunamadı");
            }

            // Mapping
            WarehouseGetByIdDto dto = mapper.Map<WarehouseGetByIdDto>(warehouse);

            return Result<WarehouseGetByIdDto>.Succeed(dto);
        }
    }
}