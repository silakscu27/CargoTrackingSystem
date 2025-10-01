using CargoTrackingSystem.Domain.Enums;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Add;

public sealed record ShipmentTransferAddCommand(
    Guid ShipmentId,
    Guid FromWarehouseId,
    Guid ToWarehouseId,
    TransferStatus TransferStatus,
    DateTime? ScheduledDate,
    DateTime? ActualDate,
    Guid CreatedBy
) : IRequest<Result<Guid>>;
