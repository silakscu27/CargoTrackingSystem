using CargoTrackingSystem.Domain.Enums;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Update;

public sealed record ShipmentTransferUpdateCommand(
    Guid Id,
    Guid ShipmentId,
    Guid FromWarehouseId,
    Guid ToWarehouseId,
    TransferStatus TransferStatus,
    DateTime? ScheduledDate,
    DateTime? ActualDate
) : IRequest<Result<string>>;
