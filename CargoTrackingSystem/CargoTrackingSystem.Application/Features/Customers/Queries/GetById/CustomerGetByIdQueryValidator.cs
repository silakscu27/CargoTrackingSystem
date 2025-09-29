using CargoTrackingSystem.Domain.Repositories;
using FluentValidation;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Customers.Queries.GetById
{
    public sealed class CustomerGetByIdQueryValidator : AbstractValidator<CustomerGetByIdQuery>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerGetByIdQueryValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen bir müşteri seçiniz.");

            RuleFor(x => x.Id)
                .MustAsync(AnyCustomerAsync)
                .WithMessage("Seçili müşteri bulunamadı.");
        }

        private async Task<bool> AnyCustomerAsync(Guid id, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(id, cancellationToken);
            return customer != null;
        }

    }
}
