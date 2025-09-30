using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Shipments.Commands.Update;

internal sealed class ShipmentUpdateCommandHandler(
    IShipmentRepository shipmentRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<ShipmentUpdateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ShipmentUpdateCommand request, CancellationToken cancellationToken)
    {
        // Find shipment by Id
        Shipment? shipment = await shipmentRepository.FindByAsync(s => s.Id == request.Id);

        if (shipment is null)
        {
            return Result<string>.Failure("Kargo bulunamadı");
        }

        // Map incoming request values to existing entity
        mapper.Map(request, shipment);

        // Update timestamp
        shipment.UpdatedAt = DateTime.UtcNow;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Kargo bilgileri başarıyla güncellendi");
    }
}
