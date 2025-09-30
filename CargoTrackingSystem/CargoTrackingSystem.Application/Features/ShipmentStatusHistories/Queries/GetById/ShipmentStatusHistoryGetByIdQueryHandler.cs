using AutoMapper;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Queries.GetById;

internal sealed class ShipmentStatusHistoryGetByIdQueryHandler(
    IShipmentStatusHistoryRepository repository,
    IMapper mapper
) : IRequestHandler<ShipmentStatusHistoryGetByIdQuery, Result<ShipmentStatusHistoryGetByIdDto>>
{
    public async Task<Result<ShipmentStatusHistoryGetByIdDto>> Handle(
        ShipmentStatusHistoryGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return Result<ShipmentStatusHistoryGetByIdDto>.Failure("Kargo durumu bulunamadı");
        }

        var dto = mapper.Map<ShipmentStatusHistoryGetByIdDto>(entity);

        return Result<ShipmentStatusHistoryGetByIdDto>.Succeed(dto);
    }
}
