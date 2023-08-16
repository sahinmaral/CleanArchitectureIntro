using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureIntro.Domain.Entities;

namespace CleanArchitectureIntro.Application.Abstractions;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(User user);
}
