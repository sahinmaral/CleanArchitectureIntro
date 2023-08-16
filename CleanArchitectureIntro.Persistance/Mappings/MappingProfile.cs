using AutoMapper;

using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureIntro.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitectureIntro.Application.Features.ErrorLogFeatures.Commands.CreateErrorLog;
using CleanArchitectureIntro.Application.Features.RoleFeatures.Command;
using CleanArchitectureIntro.Domain.Entities;

using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureIntro.Persistance.Mappings;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<CreateUserRoleCommand, IdentityUserRole<string>>();
        CreateMap<CreateRoleCommand, Role>();

        CreateMap<RegisterCommand, User>();

        CreateMap<CreateCarCommand, Car>();
        CreateMap<CreateErrorLogCommand, ErrorLog>().ReverseMap();
	}
}
