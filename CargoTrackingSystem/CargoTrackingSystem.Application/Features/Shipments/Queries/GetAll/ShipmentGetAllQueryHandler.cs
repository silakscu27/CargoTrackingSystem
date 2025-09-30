using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Shipments.Queries.GetAll;

internal sealed class ShipmentGetAllQueryHandler(
    IShipmentRepository shipmentRepository) : IRequestHandler<ShipmentGetAllQuery, Result<List<Shipment>>>
{
    public async Task<Result<List<Shipment>>> Handle(ShipmentGetAllQuery request, CancellationToken cancellationToken)
    {
        List<Shipment> shipments = await shipmentRepository.GetAllAsync(cancellationToken);

        return shipments.Any()
            ? Result<List<Shipment>>.Succeed(shipments)
            : Result<List<Shipment>>.Failure("Kargo bulunamadı");
    }
}
