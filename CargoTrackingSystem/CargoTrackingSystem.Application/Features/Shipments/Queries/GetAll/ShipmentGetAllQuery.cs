using CargoTrackingSystem.Domain.Entities;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Shipments.Queries.GetAll;

public sealed record ShipmentGetAllQuery() : IRequest<Result<List<Shipment>>>;
