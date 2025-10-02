using CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Add;
using CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Update;
using CargoTrackingSystem.Application.Features.ShipmentTransfers.Queries.GetAll;
using CargoTrackingSystem.Application.Features.ShipmentTransfers.Queries.GetById;
using CargoTrackingSystem.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CargoTrackingSystem.WebAPI.Controllers;

public sealed class ShipmentTransfersController : ApiController
{
    public ShipmentTransfersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ShipmentTransferGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response); 
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var request = new ShipmentTransferGetByIdQuery(id);
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response); 
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShipmentTransferAddCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response); 
    }

    [HttpPut]
    public async Task<IActionResult> Update(ShipmentTransferUpdateCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response); 
    }
}
