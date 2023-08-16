using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Login;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.RefreshToken
{
    public sealed record RefreshTokenCommand(
        string UserId,
        string RefreshToken) : IRequest<LoginCommandResponse>;
}

