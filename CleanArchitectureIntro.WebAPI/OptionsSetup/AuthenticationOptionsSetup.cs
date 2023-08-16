using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace CleanArchitectureIntro.WebAPI.OptionsSetup;

public sealed class AuthenticationOptionsSetup : IPostConfigureOptions<AuthenticationOptions>
{
    public void PostConfigure(string? name, AuthenticationOptions options)
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
}
