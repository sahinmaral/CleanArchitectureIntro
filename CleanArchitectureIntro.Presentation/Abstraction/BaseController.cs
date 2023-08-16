﻿using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureIntro.Presentation.Abstraction;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    public readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
