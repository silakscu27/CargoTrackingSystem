using FluentValidation;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Add;

public sealed class ShipmentTransferAddCommandValidator : AbstractValidator<ShipmentTransferAddCommand>
{
    public ShipmentTransferAddCommandValidator()
    {
        RuleFor(x => x.ShipmentId)
            .NotEmpty().WithMessage("Lütfen bir gönderi seçiniz.");

        RuleFor(x => x.FromWarehouseId)
            .NotEmpty().WithMessage("Kaynak deposu seçilmelidir.");

        RuleFor(x => x.ToWarehouseId)
            .NotEmpty().WithMessage("Hedef deposu seçilmelidir.")
            .NotEqual(x => x.FromWarehouseId)
            .WithMessage("Kaynak ve hedef deposu aynı olamaz.");

        RuleFor(x => x.TransferStatus)
            .IsInEnum().WithMessage("Geçerli bir transfer durumu seçiniz.");

        RuleFor(x => x.CreatedBy)
            .NotEmpty().WithMessage("Oluşturan kullanıcı belirtilmelidir.");
    }
}
