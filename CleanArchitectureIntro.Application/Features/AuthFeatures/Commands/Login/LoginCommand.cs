using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Login;

public sealed record LoginCommand(
    string UsernameOrEmail,
    string Password
    ) : IRequest<LoginCommandResponse>;