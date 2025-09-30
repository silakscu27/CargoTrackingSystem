using FluentValidation;

namespace CargoTrackingSystem.Application.Features.Shipments.Commands.Add;

public sealed class ShipmentAddCommandValidator : AbstractValidator<ShipmentAddCommand>
{
    public ShipmentAddCommandValidator()
    {
        RuleFor(s => s.SenderCustomerId)
            .NotEmpty().WithMessage("Gönderici müşteri seçilmelidir.");

        RuleFor(s => s.ReceiverCustomerId)
            .NotEmpty().WithMessage("Alıcı müşteri seçilmelidir.");

        RuleFor(s => s.Weight)
            .GreaterThan(0).WithMessage("Kargo ağırlığı 0'dan büyük olmalıdır.");

        RuleFor(s => s.Dimensions)
            .NotEmpty().WithMessage("Kargo boyutları boş olamaz.");

        RuleFor(s => s.ContentValue)
            .GreaterThan(0).WithMessage("İçerik değeri 0'dan büyük olmalıdır.");

        RuleFor(s => s.ContentType)
            .NotEmpty().WithMessage("İçerik türü boş olamaz.");

        RuleFor(s => s.CurrentLocation)
            .NotEmpty().WithMessage("Geçerli konum boş olamaz.");

        RuleFor(s => s.CreatedBy)
            .NotEmpty().WithMessage("Oluşturan kullanıcı bilgisi boş olamaz.");
    }
}
