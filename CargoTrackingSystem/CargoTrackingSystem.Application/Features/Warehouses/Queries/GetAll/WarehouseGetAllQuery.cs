using CargoTrackingSystem.Domain.Entities;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Warehouses.Queries.GetAll;

public sealed record WarehouseGetAllQuery() : IRequest<Result<List<Warehouse>>>;
