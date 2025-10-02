using CargoTrackingSystem.Domain.Enums;
using FluentValidation;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Update;

public sealed class ShipmentStatusHistoryUpdateCommandValidator : AbstractValidator<ShipmentStatusHistoryUpdateCommand>
{
    public ShipmentStatusHistoryUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Geçerli bir gönderi durumu seçilmelidir.");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Geçerli bir durum seçilmelidir.");

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Konum bilgisi boş olamaz.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Açıklama en fazla 500 karakter olabilir.");
    }
}
