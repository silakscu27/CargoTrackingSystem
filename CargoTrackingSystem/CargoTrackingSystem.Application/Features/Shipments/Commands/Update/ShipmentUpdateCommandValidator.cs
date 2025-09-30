using FluentValidation;

namespace CargoTrackingSystem.Application.Features.Shipments.Commands.Update;

public sealed class ShipmentUpdateCommandValidator : AbstractValidator<ShipmentUpdateCommand>
{
    public ShipmentUpdateCommandValidator()
    {
        RuleFor(s => s.Id)
            .NotEmpty().WithMessage("Lütfen bir kargo seçiniz");

        RuleFor(s => s.Weight)
            .GreaterThan(0).WithMessage("Kargo ağırlığı 0’dan büyük olmalıdır");

        RuleFor(s => s.Dimensions)
            .NotEmpty().WithMessage("Kargo boyutları boş olamaz");

        RuleFor(s => s.ContentValue)
            .GreaterThan(0).WithMessage("İçerik değeri 0’dan büyük olmalıdır");

        RuleFor(s => s.ContentType)
            .NotEmpty().WithMessage("İçerik tipi boş olamaz");

        RuleFor(s => s.Status)
            .NotEmpty().WithMessage("Durum bilgisi boş olamaz");

        RuleFor(s => s.CurrentLocation)
            .NotEmpty().WithMessage("Mevcut konum boş olamaz");
    }
}
