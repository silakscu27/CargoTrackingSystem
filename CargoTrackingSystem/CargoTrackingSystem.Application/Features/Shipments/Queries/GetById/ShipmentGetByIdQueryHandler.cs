using AutoMapper;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Shipments.Queries.GetById;

internal sealed class ShipmentGetByIdQueryHandler(
    IShipmentRepository shipmentRepository,
    IMapper mapper
) : IRequestHandler<ShipmentGetByIdQuery, Result<ShipmentGetByIdDto>>
{
    public async Task<Result<ShipmentGetByIdDto>> Handle(ShipmentGetByIdQuery request, CancellationToken cancellationToken)
    {
        // recieve the one shipment
        Shipment? shipment = await shipmentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (shipment is null)
        {
            return Result<ShipmentGetByIdDto>.Failure("Kargo bulunamadı");
        }

        // Mapping
        ShipmentGetByIdDto dto = mapper.Map<ShipmentGetByIdDto>(shipment);

        return Result<ShipmentGetByIdDto>.Succeed(dto);
    }
}
