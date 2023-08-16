using AutoMapper;

using CleanArchitectureIntro.Application.Features.RoleFeatures.Command;
using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Entities;

using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureIntro.Persistance.Services;

public sealed class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public RoleService(RoleManager<Role> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateRoleCommand request)
    {
        Role role = _mapper.Map<Role>(request);

        var result = await _roleManager.CreateAsync(role);
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);
    }
}
