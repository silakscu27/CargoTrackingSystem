using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Shipments.Commands.Add;

internal sealed class ShipmentAddCommandHandler(
    IShipmentRepository shipmentRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<ShipmentAddCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(ShipmentAddCommand request, CancellationToken cancellationToken)
    {
        // Create a new shipment 
        var shipment = mapper.Map<Shipment>(request);

        // Tracking number can be generated automatically (example: first 8 characters of GUID)
        shipment.TrackingNumber = $"TRK-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        shipment.Status = "Created";
        shipment.CreatedAt = DateTime.UtcNow;

        shipmentRepository.Add(shipment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Succeed(shipment.Id);
    }
}
