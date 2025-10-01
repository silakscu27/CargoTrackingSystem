using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Update;

internal sealed class ShipmentTransferUpdateCommandHandler(
    IShipmentTransferRepository shipmentTransferRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<ShipmentTransferUpdateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ShipmentTransferUpdateCommand request, CancellationToken cancellationToken)
    {
        // Fetch entity from database
        ShipmentTransfer? shipmentTransfer = await shipmentTransferRepository.GetByIdAsync(request.Id, cancellationToken);

        if (shipmentTransfer is null)
        {
            return Result<string>.Failure("Transfer kaydı bulunamadı.");
        }

        // Map new values onto existing entity
        mapper.Map(request, shipmentTransfer);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Transfer kaydı başarıyla güncellendi.");
    }
}
