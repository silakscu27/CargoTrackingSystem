using CargoTrackingSystem.Domain.Repositories;
using FluentValidation;

namespace CargoTrackingSystem.Application.Features.Warehouses.Commands.Add;

public sealed class WarehouseAddCommandValidator : AbstractValidator<WarehouseAddCommand>
{
    public WarehouseAddCommandValidator()
    {
        RuleFor(w => w.Name)
            .NotEmpty().WithMessage("Depo adı boş olamaz");

        RuleFor(w => w.Code)
            .NotEmpty().WithMessage("Depo kodu boş olamaz");

        RuleFor(w => w.Address)
            .NotEmpty().WithMessage("Adres boş olamaz");

        RuleFor(w => w.City)
            .NotEmpty().WithMessage("Şehir boş olamaz");

        RuleFor(w => w.Country)
            .NotEmpty().WithMessage("Ülke boş olamaz");

        RuleFor(w => w.Phone)
            .NotEmpty().WithMessage("Telefon boş olamaz");
    }
}
