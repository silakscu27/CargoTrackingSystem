using CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Add;
using CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Update;
using CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Queries.GetAll;
using CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Queries.GetById;
using CargoTrackingSystem.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CargoTrackingSystem.WebAPI.Controllers;

public sealed class ShipmentStatusHistoriesController : ApiController
{
    public ShipmentStatusHistoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ShipmentStatusHistoryGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var request = new ShipmentStatusHistoryGetByIdQuery(id);
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShipmentStatusHistoryAddCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(ShipmentStatusHistoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
