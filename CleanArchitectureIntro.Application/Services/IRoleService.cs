using CleanArchitectureIntro.Application.Features.RoleFeatures.Command;

namespace CleanArchitectureIntro.Application.Services;

public interface IRoleService
{
    Task CreateAsync(CreateRoleCommand request);
}
