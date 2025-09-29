using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Customers.Commands.Add;

internal sealed class CustomerAddCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CustomerAddCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CustomerAddCommand request, CancellationToken cancellationToken)
    {
        // Check if your tax number already exists
        bool isTaxNumberExists = (await customerRepository.FindBy(c => c.TaxNumber == request.TaxNumber)
            .AnyAsync(cancellationToken));

        if (isTaxNumberExists)
        {
            return Result<Guid>.Failure("Vergi numarası daha önce kaydedilmiş");
        }

        // Create a new customer
        var customer = mapper.Map<Customer>(request);

        customer.CreatedAt = DateTime.UtcNow;

        customerRepository.Add(customer);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Succeed(customer.Id);
    }
}
