using CleanArchitectureIntro.WebAPI.OptionsSetup;

using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureIntro.WebAPI.Configurations;

public class AuthorizeServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration,IHostBuilder hostBuilder)
    {

        services.AddAuthentication().AddJwtBearer();
        services.AddAuthorization();

        services.ConfigureApplicationCookie(o => {
            o.ExpireTimeSpan = TimeSpan.FromDays(5);
            o.SlidingExpiration = true;
        });

        services.Configure<DataProtectionTokenProviderOptions>(o =>
       o.TokenLifespan = TimeSpan.FromHours(3));
    }
}
