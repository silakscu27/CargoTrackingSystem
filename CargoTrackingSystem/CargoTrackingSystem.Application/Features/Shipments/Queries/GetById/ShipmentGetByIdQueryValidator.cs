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
            .NotEmpty()
            .WithMessage("Lütfen bir kargo seçiniz.");

        RuleFor(x => x.Id)
            .MustAsync(AnyShipmentAsync)
            .WithMessage("Seçili kargo bulunamadı.");
    }

    private async Task<bool> AnyShipmentAsync(Guid id, CancellationToken cancellationToken)
    {
        var shipment = await _shipmentRepository.GetByIdAsync(id, cancellationToken);
        return shipment != null;
    }
}
