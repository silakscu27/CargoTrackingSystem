using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Add;

internal sealed class ShipmentStatusHistoryAddCommandHandler(
    IShipmentStatusHistoryRepository shipmentStatusHistoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<ShipmentStatusHistoryAddCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(ShipmentStatusHistoryAddCommand request, CancellationToken cancellationToken)
    {
        // Create a new status history
        ShipmentStatusHistory statusHistory = mapper.Map<ShipmentStatusHistory>(request);

        statusHistory.CreatedAt = DateTime.UtcNow;

        shipmentStatusHistoryRepository.Add(statusHistory);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Succeed(statusHistory.Id);
    }
}
