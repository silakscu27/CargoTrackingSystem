using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Add;

internal sealed class ShipmentTransferAddCommandHandler(
    IShipmentTransferRepository shipmentTransferRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<ShipmentTransferAddCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(ShipmentTransferAddCommand request, CancellationToken cancellationToken)
    {
        // Map request to entity
        ShipmentTransfer shipmentTransfer = mapper.Map<ShipmentTransfer>(request);

        shipmentTransfer.CreatedAt = DateTime.UtcNow;

        shipmentTransferRepository.Add(shipmentTransfer);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Succeed(shipmentTransfer.Id);
    }
}
