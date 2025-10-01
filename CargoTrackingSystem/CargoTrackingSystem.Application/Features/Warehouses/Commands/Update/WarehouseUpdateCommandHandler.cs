using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Warehouses.Commands.Update;

internal sealed class WarehouseUpdateCommandHandler(
    IWarehouseRepository warehouseRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<WarehouseUpdateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(WarehouseUpdateCommand request, CancellationToken cancellationToken)
    {
        // Fetch the warehouse with tracking
        Warehouse? warehouse = await warehouseRepository.FindByAsync(w => w.Id == request.Id);

        if (warehouse is null)
        {
            return Result<string>.Failure("Depo bulunamadı");
        }

        // Check if the warehouse code has changed and is unique
        if (warehouse.Code != request.Code)
        {
            bool isCodeExists = await warehouseRepository
                .FindBy(w => w.Code == request.Code)
                .AnyAsync(cancellationToken);

            if (isCodeExists)
            {
                return Result<string>.Failure("Bu kod ile başka bir depo zaten mevcut");
            }
        }

        // Map updated properties
        mapper.Map(request, warehouse);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Depo bilgileri başarıyla güncellendi");
    }
}
