using CargoTrackingSystem.Domain.Enums;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Add;

public sealed record ShipmentStatusHistoryAddCommand(
    Guid ShipmentId,
    ShipmentStatus Status,
    string Location,
    string Description,
    Guid CreatedBy
) : IRequest<Result<Guid>>;
