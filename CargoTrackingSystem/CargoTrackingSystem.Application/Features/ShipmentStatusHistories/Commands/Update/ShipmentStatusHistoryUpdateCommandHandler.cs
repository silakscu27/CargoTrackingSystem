using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Update;

internal sealed class ShipmentStatusHistoryUpdateCommandHandler(
    IShipmentStatusHistoryRepository shipmentStatusHistoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<ShipmentStatusHistoryUpdateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ShipmentStatusHistoryUpdateCommand request, CancellationToken cancellationToken)
    {
        // Fetch the existing status history
        ShipmentStatusHistory? statusHistory = await shipmentStatusHistoryRepository.GetByIdAsync(request.Id, cancellationToken);

        if (statusHistory is null)
        {
            return Result<string>.Failure("Shipment durumu bulunamadı");
        }

        // Apply the update using AutoMapper
        mapper.Map(request, statusHistory);

        statusHistory.UpdatedAt = DateTime.UtcNow;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Shipment durumu başarıyla güncellendi");
    }
}
