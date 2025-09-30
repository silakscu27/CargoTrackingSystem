using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Shipments.Commands.Add;

public sealed record ShipmentAddCommand(
    Guid SenderCustomerId,
    Guid ReceiverCustomerId,
    decimal Weight,
    string Dimensions,
    decimal ContentValue,
    string ContentType,
    string CurrentLocation,
    DateTime? EstimatedDelivery,
    Guid CreatedBy
) : IRequest<Result<Guid>>;
