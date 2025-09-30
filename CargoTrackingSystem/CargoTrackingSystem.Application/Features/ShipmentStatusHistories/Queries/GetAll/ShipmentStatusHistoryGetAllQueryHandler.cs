using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Queries.GetAll;

internal sealed class ShipmentStatusHistoryGetAllQueryHandler(
    IShipmentStatusHistoryRepository repository
) : IRequestHandler<ShipmentStatusHistoryGetAllQuery, Result<List<ShipmentStatusHistory>>>
{
    public async Task<Result<List<ShipmentStatusHistory>>> Handle(
        ShipmentStatusHistoryGetAllQuery request,
        CancellationToken cancellationToken)
    {
        var histories = await repository.GetAllAsync(cancellationToken);

        return histories.Any()
            ? Result<List<ShipmentStatusHistory>>.Succeed(histories)
            : Result<List<ShipmentStatusHistory>>.Failure("Hiçbir kargo durumu bulunamadı");
    }
}
