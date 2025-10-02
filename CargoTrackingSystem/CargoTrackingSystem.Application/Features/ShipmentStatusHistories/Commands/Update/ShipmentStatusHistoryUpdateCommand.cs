using CargoTrackingSystem.Domain.Enums;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Update;

public sealed record ShipmentStatusHistoryUpdateCommand(
    Guid Id,
    ShipmentStatus Status,
    string Location,
    string Description
) : IRequest<Result<string>>;
