using CleanArchitectureIntro.Application.Abstractions;
using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Repositories;
using CleanArchitectureIntro.Infrastructure.Authentication;
using CleanArchitectureIntro.Infrastructure.Repositories;
using CleanArchitectureIntro.Infrastructure.Services;
using CleanArchitectureIntro.Persistance.Context;
using CleanArchitectureIntro.Persistance.Services;

namespace CleanArchitectureIntro.WebAPI.Configurations;

public class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration,IHostBuilder hostBuilder)
    {
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IErrorLogService, ErrorLogService>();
    }
}
