using FluentValidation;

namespace CargoTrackingSystem.Application.Features.Customers.Commands.Add;

public sealed class CustomerAddCommandValidator : AbstractValidator<CustomerAddCommand>
{
    public CustomerAddCommandValidator()
    {
        RuleFor(c => c.CompanyName)
            .NotEmpty().WithMessage("Firma adı boş olamaz");

        RuleFor(c => c.TaxNumber)
            .NotEmpty().WithMessage("Vergi numarası boş olamaz")
            .Length(10, 11).WithMessage("Vergi numarası 10-11 karakter olmalıdır");

        RuleFor(c => c.Address)
            .NotEmpty().WithMessage("Adres boş olamaz");

        RuleFor(c => c.City)
            .NotEmpty().WithMessage("Şehir boş olamaz");

        RuleFor(c => c.Country)
            .NotEmpty().WithMessage("Ülke boş olamaz");

        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("UserId boş olamaz");
    }
}
