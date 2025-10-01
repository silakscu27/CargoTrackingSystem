using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Warehouses.Commands.Add;

internal sealed class WarehouseAddCommandHandler(
    IWarehouseRepository warehouseRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<WarehouseAddCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(WarehouseAddCommand request, CancellationToken cancellationToken)
    {
        // Check if warehouse code already exists
        bool isCodeExists = await warehouseRepository
            .FindBy(w => w.Code == request.Code)
            .AnyAsync(cancellationToken);

        if (isCodeExists)
        {
            return Result<Guid>.Failure("Bu kod ile bir depo zaten mevcut");
        }

        // Create a new warehouse entity
        var warehouse = mapper.Map<Warehouse>(request);
        warehouse.CreatedAt = DateTime.UtcNow;

        // Add to repository and save changes
        warehouseRepository.Add(warehouse);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Succeed(warehouse.Id);
    }
}
