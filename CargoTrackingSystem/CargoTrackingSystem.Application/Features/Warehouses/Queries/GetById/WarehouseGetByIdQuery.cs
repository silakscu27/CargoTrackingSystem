using MediatR;
using TS.Result;
using System;

namespace CargoTrackingSystem.Application.Features.Warehouses.Queries.GetById
{
    public sealed record WarehouseGetByIdQuery(Guid Id) : IRequest<Result<WarehouseGetByIdDto>>;
}
