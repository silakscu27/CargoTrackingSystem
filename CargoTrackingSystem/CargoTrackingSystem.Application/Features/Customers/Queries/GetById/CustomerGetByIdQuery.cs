using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Customers.Queries.GetById;

public sealed record CustomerGetByIdQuery(Guid Id) : IRequest<Result<CustomerGetByIdDto>>;
