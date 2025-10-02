using FluentValidation;
using CargoTrackingSystem.Domain.Enums;

namespace CargoTrackingSystem.Application.Features.Shipments.Commands.Update;

public sealed class ShipmentUpdateCommandValidator : AbstractValidator<ShipmentUpdateCommand>
{
    public ShipmentUpdateCommandValidator()
    {
        RuleFor(s => s.Id)
            .NotEqual(Guid.Empty).WithMessage("Lütfen geçerli bir kargo seçiniz.");

        RuleFor(s => s.Weight)
            .GreaterThan(0).WithMessage("Kargo ağırlığı 0’dan büyük olmalıdır.")
            .LessThanOrEqualTo(1000).WithMessage("Kargo ağırlığı 1000 kg’dan fazla olamaz.");

        RuleFor(s => s.Dimensions)
            .NotEmpty().WithMessage("Kargo boyutları boş olamaz.")
            .MaximumLength(100).WithMessage("Kargo boyutları 100 karakteri geçemez.");

        RuleFor(s => s.ContentValue)
            .GreaterThan(0).WithMessage("İçerik değeri 0’dan büyük olmalıdır.")
            .LessThanOrEqualTo(1_000_000).WithMessage("İçerik değeri 1.000.000 ₺'den fazla olamaz.");

        RuleFor(s => s.ContentType)
            .IsInEnum().WithMessage("Geçerli bir içerik tipi seçilmelidir.");

        RuleFor(s => s.Status)
            .IsInEnum().WithMessage("Geçerli bir durum seçilmelidir.");

        RuleFor(s => s.CurrentLocation)
            .NotEmpty().WithMessage("Mevcut konum boş olamaz.")
            .MaximumLength(200).WithMessage("Mevcut konum 200 karakteri geçemez.");
    }
}
