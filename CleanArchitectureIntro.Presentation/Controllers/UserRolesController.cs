using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureIntro.Domain.Dtos;
using CleanArchitectureIntro.Presentation.Abstraction;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureIntro.Presentation.Controllers;

public sealed class UserRolesController : BaseController
{

    public UserRolesController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}



