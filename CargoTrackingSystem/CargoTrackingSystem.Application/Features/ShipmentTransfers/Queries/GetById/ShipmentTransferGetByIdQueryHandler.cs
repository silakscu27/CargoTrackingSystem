using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Queries.GetById;

public sealed class ShipmentTransferGetByIdQueryHandler
    : IRequestHandler<ShipmentTransferGetByIdQuery, ShipmentTransfer?>
{
    private readonly IShipmentTransferRepository _shipmentTransferRepository;

    public ShipmentTransferGetByIdQueryHandler(IShipmentTransferRepository shipmentTransferRepository)
    {
        _shipmentTransferRepository = shipmentTransferRepository;
    }

    public async Task<ShipmentTransfer?> Handle(
        ShipmentTransferGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _shipmentTransferRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
