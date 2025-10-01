using CargoTrackingSystem.Domain.Repositories;
using FluentValidation;

namespace CargoTrackingSystem.Application.Features.Warehouses.Commands.Update;

public sealed class WarehouseUpdateCommandValidator : AbstractValidator<WarehouseUpdateCommand>
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseUpdateCommandValidator(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Depo adı boş olamaz");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Depo kodu boş olamaz");

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Lütfen bir depo seçiniz.")
            .MustAsync(AnyWarehouseAsync)
            .WithMessage("Seçili depo bulunamadı");
    }

    private async Task<bool> AnyWarehouseAsync(Guid id, CancellationToken cancellationToken)
    {
        var warehouse = await _warehouseRepository.GetByIdAsync(id, cancellationToken);
        return warehouse != null;
    }
}
