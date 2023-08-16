using CleanArchitectureIntro.Domain.Entities;
using CleanArchitectureIntro.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Serilog;

namespace CleanArchitectureIntro.WebAPI.Configurations;

public class PersistanceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration,IHostBuilder hostBuilder)
    {
        services.AddAutoMapper(typeof(CleanArchitectureIntro.Persistance.AssemblyReference).Assembly);

        var connectionString = configuration.GetConnectionString("MSSQLConnectionString");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(connectionString: connectionString, tableName: "Logs", autoCreateSqlTable: true).CreateLogger();

        hostBuilder.UseSerilog();
    }
}
