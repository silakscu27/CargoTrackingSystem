using CargoTrackingSystem.Domain.Entities;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Customers.Queries.GetAll;

public sealed record CustomerGetAllQuery() : IRequest<Result<List<Customer>>>;
