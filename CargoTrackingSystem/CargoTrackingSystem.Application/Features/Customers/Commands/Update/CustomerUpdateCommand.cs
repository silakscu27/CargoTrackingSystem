using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Customers.CustomerUpdate;

public sealed record CustomerUpdateCommand(
    Guid Id,
    string CompanyName,
    string TaxNumber,
    string Address,
    string City,
    string Country) : IRequest<Result<string>>;
