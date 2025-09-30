using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Update;

public sealed record ShipmentStatusHistoryUpdateCommand(
    Guid Id,
    string Status,
    string Location,
    string Description
) : IRequest<Result<string>>;
