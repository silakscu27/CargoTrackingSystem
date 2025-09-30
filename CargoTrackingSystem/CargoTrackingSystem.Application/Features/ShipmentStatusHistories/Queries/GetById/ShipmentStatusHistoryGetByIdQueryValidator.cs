using CargoTrackingSystem.Domain.Repositories;
using FluentValidation;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Queries.GetById;

public sealed class ShipmentStatusHistoryGetByIdQueryValidator
    : AbstractValidator<ShipmentStatusHistoryGetByIdQuery>
{
    private readonly IShipmentStatusHistoryRepository _repository;

    public ShipmentStatusHistoryGetByIdQueryValidator(IShipmentStatusHistoryRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Lütfen bir kargo durumu seçiniz.");

        RuleFor(x => x.Id)
            .MustAsync(AnyStatusHistoryAsync)
            .WithMessage("Seçili kargo durumu bulunamadı");
    }

    private async Task<bool> AnyStatusHistoryAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        return entity != null;
    }
}
