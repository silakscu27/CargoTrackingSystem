using CargoTrackingSystem.Application.Features.Warehouses.Queries.GetById;
using MediatR;
using TS.Result;

public sealed record WarehouseGetByIdQuery : IRequest<Result<WarehouseGetByIdDto>>
{
    public Guid Id { get; init; }
}
