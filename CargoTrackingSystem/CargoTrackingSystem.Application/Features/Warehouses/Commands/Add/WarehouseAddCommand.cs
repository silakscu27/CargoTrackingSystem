using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Warehouses.Commands.Add;

public sealed record WarehouseAddCommand(
    string Name,
    string Code,
    string Address,
    string City,
    string Country,
    string Phone,
    bool IsActive) : IRequest<Result<Guid>>;
