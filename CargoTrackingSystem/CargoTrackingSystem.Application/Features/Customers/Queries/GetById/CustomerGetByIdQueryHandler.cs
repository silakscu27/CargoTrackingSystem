using AutoMapper;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Customers.Queries.GetById
{
    internal sealed class CustomerGetByIdQueryHandler(
        ICustomerRepository customerRepository,
        IMapper mapper
    ) : IRequestHandler<CustomerGetByIdQuery, Result<CustomerGetByIdDto>>
    {
        public async Task<Result<CustomerGetByIdDto>> Handle(CustomerGetByIdQuery request, CancellationToken cancellationToken)
        {
            // Bringing a single customer
            Customer? customer = await customerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (customer is null)
            {
                return Result<CustomerGetByIdDto>.Failure("Müşteri bulunamadı");
            }

            // Mapping
            CustomerGetByIdDto dto = mapper.Map<CustomerGetByIdDto>(customer);

            return Result<CustomerGetByIdDto>.Succeed(dto);
        }
    }
}
