using CargoTrackingSystem.Application.Features.Customers.Commands.Add;
using CargoTrackingSystem.Application.Features.Customers.CustomerUpdate;
using CargoTrackingSystem.Application.Features.Customers.Queries.GetAll;
using CargoTrackingSystem.Application.Features.Customers.Queries.GetById;
using CargoTrackingSystem.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CargoTrackingSystem.WebAPI.Controllers;

public sealed class CustomersController : ApiController
{
    public CustomersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CustomerGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var request = new CustomerGetByIdQuery(id);
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CustomerAddCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(CustomerUpdateCommand request, CancellationToken cancellationToken) 
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
