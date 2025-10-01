using CargoTrackingSystem.Domain.Entities;
using MediatR;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Queries.GetById;

public sealed record ShipmentTransferGetByIdQuery(Guid Id)
    : IRequest<ShipmentTransfer?>;
