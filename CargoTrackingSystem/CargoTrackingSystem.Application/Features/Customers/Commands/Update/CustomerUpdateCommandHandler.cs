using AutoMapper;
using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Customers.CustomerUpdate;

internal sealed class CustomerUpdateCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CustomerUpdateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
    {
        // Receive customer with tracking
        Customer? customer = await customerRepository.FindByAsync(c => c.Id == request.Id);

        if (customer is null)
        {
            return Result<string>.Failure("Müşteri bulunamadı");
        }

        // Check if your tax number has changed
        if (customer.TaxNumber != request.TaxNumber)
        {
            bool isTaxNumberExists = (await customerRepository.FindBy(c => c.TaxNumber == request.TaxNumber)
                .AnyAsync(cancellationToken));

            if (isTaxNumberExists)
            {
                return Result<string>.Failure("Vergi numarası daha önce kaydedilmiş");
            }
        }

        // Apply the request to the entity with Mapper
        mapper.Map(request, customer);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Müşteri bilgileri başarıyla güncellendi");
    }
}
