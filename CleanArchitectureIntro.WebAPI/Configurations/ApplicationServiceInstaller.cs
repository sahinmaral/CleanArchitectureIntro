using CleanArchitectureIntro.Application.Behaviors;

using FluentValidation;

using MediatR;

namespace CleanArchitectureIntro.WebAPI.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration,IHostBuilder hostBuilder)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CleanArchitectureIntro.Application.AssemblyReference).Assembly);
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(CleanArchitectureIntro.Application.AssemblyReference).Assembly);
    }
}
