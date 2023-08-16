using CleanArchitectureIntro.WebAPI.Extensions;
using CleanArchitectureIntro.WebAPI.Middlewares;

namespace CleanArchitectureIntro.WebAPI.Configurations;

public class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration,IHostBuilder hostBuilder)
    {
        services.AddTransient<ExceptionMiddleware>();


        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });


        services.AddControllers()
            .AddApplicationPart(typeof(CleanArchitectureIntro.Presentation.AssemblyReference).Assembly);


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        services.ConfigureSwaggerOptions();
    }
}
