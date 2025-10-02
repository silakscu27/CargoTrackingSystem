using CargoTrackingSystem.Application.Features.Warehouses.Commands.Add;
using CargoTrackingSystem.Application.Features.Warehouses.Commands.Update;
using CargoTrackingSystem.Application.Features.Warehouses.Queries.GetAll;
using CargoTrackingSystem.Application.Features.Warehouses.Queries.GetById;
using CargoTrackingSystem.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CargoTrackingSystem.WebAPI.Controllers;

public sealed class WarehousesController : ApiController
{
    public WarehousesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] WarehouseGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var request = new WarehouseGetByIdQuery(id);
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(WarehouseAddCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(WarehouseUpdateCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
