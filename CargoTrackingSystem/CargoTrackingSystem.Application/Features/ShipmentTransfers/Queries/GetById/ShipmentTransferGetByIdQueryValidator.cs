using FluentValidation;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Queries.GetById;

public sealed class ShipmentTransferGetByIdQueryValidator
    : AbstractValidator<ShipmentTransferGetByIdQuery>
{
    public ShipmentTransferGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id boş olamaz.");
    }
}
