using CargoTrackingSystem.Domain.Enums;
using FluentValidation;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Add;

public sealed class ShipmentStatusHistoryAddCommandValidator : AbstractValidator<ShipmentStatusHistoryAddCommand>
{
    public ShipmentStatusHistoryAddCommandValidator()
    {
        RuleFor(x => x.ShipmentId)
            .NotEqual(Guid.Empty)
            .WithMessage("Geçerli bir gönderi seçilmelidir.");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Geçerli bir durum seçilmelidir.");

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Konum bilgisi boş olamaz.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Açıklama en fazla 500 karakter olabilir.");

        RuleFor(x => x.CreatedBy)
            .NotEqual(Guid.Empty)
            .WithMessage("Oluşturan kullanıcı bilgisi boş olamaz.");
    }
}
