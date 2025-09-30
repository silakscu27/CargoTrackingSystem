using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Queries.GetById;

public sealed record ShipmentStatusHistoryGetByIdQuery(Guid Id)
    : IRequest<Result<ShipmentStatusHistoryGetByIdDto>>;
