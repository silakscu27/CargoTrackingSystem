using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Shipments.Commands.Update;

public sealed record ShipmentUpdateCommand(
    Guid Id,
    decimal Weight,
    string Dimensions,
    decimal ContentValue,
    string ContentType,
    string Status,
    string CurrentLocation,
    DateTime? EstimatedDelivery,
    DateTime? ActualDelivery
) : IRequest<Result<string>>;
