using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Queries.GetAll;

public sealed class ShipmentTransferGetAllQueryHandler
    : IRequestHandler<ShipmentTransferGetAllQuery, List<ShipmentTransfer>>
{
    private readonly IShipmentTransferRepository _shipmentTransferRepository;

    public ShipmentTransferGetAllQueryHandler(IShipmentTransferRepository shipmentTransferRepository)
    {
        _shipmentTransferRepository = shipmentTransferRepository;
    }

    public async Task<List<ShipmentTransfer>> Handle(
        ShipmentTransferGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _shipmentTransferRepository.GetAllAsync(cancellationToken);
    }
}
