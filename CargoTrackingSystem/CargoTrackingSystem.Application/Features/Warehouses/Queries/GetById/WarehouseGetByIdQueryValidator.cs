using CargoTrackingSystem.Domain.Repositories;
using FluentValidation;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Warehouses.Queries.GetById
{
    public sealed class WarehouseGetByIdQueryValidator : AbstractValidator<WarehouseGetByIdQuery>
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseGetByIdQueryValidator(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen bir depo seçiniz.");

            RuleFor(x => x.Id)
                .MustAsync(AnyWarehouseAsync)
                .WithMessage("Seçili depo bulunamadı.");
        }

        private async Task<bool> AnyWarehouseAsync(Guid id, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(id, cancellationToken);
            return warehouse != null;
        }
    }
}
