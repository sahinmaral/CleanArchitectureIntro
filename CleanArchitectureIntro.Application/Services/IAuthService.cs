using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.RefreshToken;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.VerifyAccount;

namespace CleanArchitectureIntro.Application.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
    Task VerifyAccountAsync(VerifyAccountCommand request);
    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
    Task<LoginCommandResponse> RefreshTokenAsync(RefreshTokenCommand request);
}
