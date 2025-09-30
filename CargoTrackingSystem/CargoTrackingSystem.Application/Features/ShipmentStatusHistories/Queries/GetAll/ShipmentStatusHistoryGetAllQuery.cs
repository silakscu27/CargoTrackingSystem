using CargoTrackingSystem.Domain.Entities;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Queries.GetAll;

public sealed record ShipmentStatusHistoryGetAllQuery() : IRequest<Result<List<ShipmentStatusHistory>>>;
