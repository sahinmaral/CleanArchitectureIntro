using AutoMapper;

using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureIntro.Application.Features.RoleFeatures.Command;
using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Entities;

using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureIntro.Persistance.Services;

public sealed class UserRoleService : IUserRoleService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public UserRoleService(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task CreateAsync(CreateUserRoleCommand request)
    {
        IdentityUserRole<string> userRole = _mapper.Map<IdentityUserRole<string>>(request);

        User? user = await _userManager.FindByIdAsync(userRole.UserId);
        if(user == null)
            throw new Exception("Bu kullanıcı id ye sahip bir kullanıcı yok");

        Role? role = await _roleManager.FindByIdAsync(userRole.RoleId);
        if (role == null)
            throw new Exception("Bu rol id ye sahip bir rol yok");

        var result = await _userManager.AddToRoleAsync(user,role.Name);
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);
    }
}
