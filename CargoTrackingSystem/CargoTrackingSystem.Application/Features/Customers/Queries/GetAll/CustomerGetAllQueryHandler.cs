using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Customers.Queries.GetAll;

internal sealed class CustomerGetAllQueryHandler(
    ICustomerRepository customerRepository) : IRequestHandler<CustomerGetAllQuery, Result<List<Customer>>>
{
    public async Task<Result<List<Customer>>> Handle(CustomerGetAllQuery request, CancellationToken cancellationToken)
    {
        List<Customer> customers = await customerRepository.GetAllAsync(cancellationToken);

        return customers.Any()
            ? Result<List<Customer>>.Succeed(customers)
            : Result<List<Customer>>.Failure("Müşteri bulunamadı");
    }
}
