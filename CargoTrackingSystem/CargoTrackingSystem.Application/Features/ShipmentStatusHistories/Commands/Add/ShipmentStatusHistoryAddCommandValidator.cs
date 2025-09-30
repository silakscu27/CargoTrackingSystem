using FluentValidation;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Add;

public sealed class ShipmentStatusHistoryAddCommandValidator : AbstractValidator<ShipmentStatusHistoryAddCommand>
{
    public ShipmentStatusHistoryAddCommandValidator()
    {
        RuleFor(x => x.ShipmentId)
            .NotEmpty()
            .WithMessage("Gönderi bilgisi boş olamaz");

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Durum boş olamaz");

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Konum boş olamaz");

        RuleFor(x => x.CreatedBy)
            .NotEmpty()
            .WithMessage("Oluşturan bilgisi boş olamaz");
    }
}
