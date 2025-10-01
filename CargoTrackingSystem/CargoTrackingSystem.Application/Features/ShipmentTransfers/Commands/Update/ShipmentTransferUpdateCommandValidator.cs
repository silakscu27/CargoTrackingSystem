using FluentValidation;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Update;

public sealed class ShipmentTransferUpdateCommandValidator : AbstractValidator<ShipmentTransferUpdateCommand>
{
    public ShipmentTransferUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Lütfen güncellenecek transfer kaydını seçiniz.");

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
    }
}
