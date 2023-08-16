using CleanArchitectureIntro.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitectureIntro.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitectureIntro.Domain.Dtos;
using CleanArchitectureIntro.Domain.Entities;
using CleanArchitectureIntro.Persistance.Context;
using CleanArchitectureIntro.Presentation.Abstraction;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureIntro.Presentation.Controllers;


public sealed class CarsController : BaseController
{

    public CarsController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateCarCommand request,CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]GetAllCarQuery request,CancellationToken cancellationToken)
    {
        PaginationResult<Car> cars = await _mediator.Send(request, cancellationToken);
        return Ok(cars);
    }
}


