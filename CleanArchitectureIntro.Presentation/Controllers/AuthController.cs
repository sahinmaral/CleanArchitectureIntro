using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.RefreshToken;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.VerifyAccount;
using CleanArchitectureIntro.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitectureIntro.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Dtos;
using CleanArchitectureIntro.Domain.Entities;
using CleanArchitectureIntro.Presentation.Abstraction;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureIntro.Presentation.Controllers;

public sealed class AuthController : BaseController
{

    public AuthController(IMediator mediator) : base(mediator)
    {
        
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Login(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Refresh(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("verify")]
    public async Task<IActionResult> VerifyAccount([FromQuery]VerifyAccountCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}

