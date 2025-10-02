using CargoTrackingSystem.Domain.Repositories;
using FluentValidation;

namespace CargoTrackingSystem.Application.Features.Shipments.Queries.GetById;

public sealed class ShipmentGetByIdQueryValidator : AbstractValidator<ShipmentGetByIdQuery>
{
    private readonly IShipmentRepository _shipmentRepository;

    public ShipmentGetByIdQueryValidator(IShipmentRepository shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;

        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Geçerli bir kargo ID’si seçiniz.");

        RuleFor(x => x.Id)
            .MustAsync(AnyShipmentAsync)
            .WithMessage("Seçili kargo bulunamadı.");
    }

    // Checks if Shipment exists in DB
    private async Task<bool> AnyShipmentAsync(Guid id, CancellationToken cancellationToken)
    {
        var shipment = await _shipmentRepository.GetByIdAsync(id, cancellationToken);
        return shipment != null;
    }
}
