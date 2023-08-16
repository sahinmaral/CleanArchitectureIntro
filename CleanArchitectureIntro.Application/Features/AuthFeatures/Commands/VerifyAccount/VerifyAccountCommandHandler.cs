using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.VerifyAccount;

public class VerifyAccountCommandHandler : IRequestHandler<VerifyAccountCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public VerifyAccountCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
    {
        await _authService.VerifyAccountAsync(request);

        return new MessageResponse("Kullanıcı başarıyla onaylandı");
    }
}
