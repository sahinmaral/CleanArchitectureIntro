using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.RoleFeatures.Command;

public sealed class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, MessageResponse>
{
    private readonly IUserRoleService _userRoleService;

    public CreateUserRoleCommandHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<MessageResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _userRoleService.CreateAsync(request);

        return new MessageResponse("Rol başarıyla kullanıcıya verildi");
    }
}