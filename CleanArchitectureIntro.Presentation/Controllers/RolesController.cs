using CleanArchitectureIntro.Application.Features.RoleFeatures.Command;
using CleanArchitectureIntro.Domain.Dtos;
using CleanArchitectureIntro.Presentation.Abstraction;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Net;

namespace CleanArchitectureIntro.Presentation.Controllers;

public sealed class RolesController : BaseController
{

    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}



