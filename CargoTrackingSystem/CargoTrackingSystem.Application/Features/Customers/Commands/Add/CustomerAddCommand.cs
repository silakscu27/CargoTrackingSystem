using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Customers.Commands.Add;

public sealed record CustomerAddCommand(
    Guid UserId,
    string CompanyName,
    string TaxNumber,
    string Address,
    string City,
    string Country) : IRequest<Result<Guid>>;
