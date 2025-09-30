using FluentValidation;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Update;

public sealed class ShipmentStatusHistoryUpdateCommandValidator : AbstractValidator<ShipmentStatusHistoryUpdateCommand>
{
    public ShipmentStatusHistoryUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Geçerli bir gönderi durumu seçiniz");

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Durum bilgisi boş olamaz");

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Konum bilgisi boş olamaz");
    }
}
