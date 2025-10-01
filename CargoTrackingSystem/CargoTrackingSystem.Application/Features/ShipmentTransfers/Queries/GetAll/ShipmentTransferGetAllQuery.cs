using CargoTrackingSystem.Domain.Entities;
using MediatR;

namespace CargoTrackingSystem.Application.Features.ShipmentTransfers.Queries.GetAll;

public sealed record ShipmentTransferGetAllQuery()
    : IRequest<List<ShipmentTransfer>>;
