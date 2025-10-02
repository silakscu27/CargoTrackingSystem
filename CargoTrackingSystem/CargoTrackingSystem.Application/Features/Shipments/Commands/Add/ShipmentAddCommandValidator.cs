using FluentValidation;
using CargoTrackingSystem.Domain.Enums;

namespace CargoTrackingSystem.Application.Features.Shipments.Commands.Add;

public sealed class ShipmentAddCommandValidator : AbstractValidator<ShipmentAddCommand>
{
    public ShipmentAddCommandValidator()
    {
        RuleFor(s => s.SenderCustomerId)
            .NotEqual(Guid.Empty).WithMessage("Gönderici müşteri seçilmelidir.");

        RuleFor(s => s.ReceiverCustomerId)
            .NotEqual(Guid.Empty).WithMessage("Alıcı müşteri seçilmelidir.");

        RuleFor(s => s.Weight)
            .GreaterThan(0).WithMessage("Kargo ağırlığı 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(1000).WithMessage("Kargo ağırlığı 1000 kg'dan fazla olamaz.");

        RuleFor(s => s.Dimensions)
            .NotEmpty().WithMessage("Kargo boyutları boş olamaz.")
            .MaximumLength(100).WithMessage("Kargo boyutları 100 karakteri geçemez.");

        RuleFor(s => s.ContentValue)
            .GreaterThan(0).WithMessage("İçerik değeri 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(1_000_000).WithMessage("İçerik değeri 1.000.000 ₺'den fazla olamaz.");

        RuleFor(s => s.ContentType)
            .IsInEnum().WithMessage("Geçerli bir içerik türü seçilmelidir.");

        RuleFor(s => s.CurrentLocation)
            .NotEmpty().WithMessage("Geçerli konum boş olamaz.")
            .MaximumLength(200).WithMessage("Geçerli konum 200 karakteri geçemez.");

        RuleFor(s => s.EstimatedDelivery)
            .Must(date => !date.HasValue || date.Value >= DateTime.UtcNow)
            .WithMessage("Tahmini teslim tarihi bugünden önce olamaz.");

        RuleFor(s => s.CreatedBy)
            .NotEqual(Guid.Empty).WithMessage("Oluşturan kullanıcı bilgisi boş olamaz.");
    }
}
