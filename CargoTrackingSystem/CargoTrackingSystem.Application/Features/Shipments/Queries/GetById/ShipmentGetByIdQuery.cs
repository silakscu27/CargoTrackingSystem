using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Shipments.Queries.GetById;

public sealed record ShipmentGetByIdQuery(Guid Id) : IRequest<Result<ShipmentGetByIdDto>>;
