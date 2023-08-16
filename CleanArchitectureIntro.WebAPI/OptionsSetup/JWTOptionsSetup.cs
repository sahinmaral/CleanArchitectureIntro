using CleanArchitectureIntro.Infrastructure.Authentication;

using Microsoft.Extensions.Options;

namespace CleanArchitectureIntro.WebAPI.OptionsSetup;

public sealed class JWTOptionsSetup : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration;

    public JWTOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection("JWT").Bind(options);
    }
}
