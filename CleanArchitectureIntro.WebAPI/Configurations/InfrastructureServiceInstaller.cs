using CleanArchitectureIntro.WebAPI.OptionsSetup;

namespace CleanArchitectureIntro.WebAPI.Configurations
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration,IHostBuilder hostBuilder)
        {
            //Options pattern
            services.ConfigureOptions<JWTOptionsSetup>();
            services.ConfigureOptions<JWTBearerOptionsSetup>();
            services.ConfigureOptions<AuthenticationOptionsSetup>();
        }
    }
}
