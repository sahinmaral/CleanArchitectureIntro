using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;

namespace CleanArchitectureIntro.Application.Services;

public interface IUserRoleService
{
    Task CreateAsync(CreateUserRoleCommand request);
}