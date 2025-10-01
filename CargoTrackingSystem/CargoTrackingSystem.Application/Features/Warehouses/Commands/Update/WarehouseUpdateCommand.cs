using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Warehouses.Commands.Update;

public sealed record WarehouseUpdateCommand(
    Guid Id,
    string Name,
    string Code,
    string Address,
    string City,
    string Country,
    string Phone,
    bool IsActive
) : IRequest<Result<string>>;
