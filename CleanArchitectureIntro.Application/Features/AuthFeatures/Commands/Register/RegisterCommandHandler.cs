using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;

public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authService.RegisterAsync(request);

        return new MessageResponse("Kullanıcı başarıyla oluşturuldu");
    }
}