using Microsoft.Extensions.Hosting;

using System.Reflection;

namespace CleanArchitectureIntro.WebAPI.Configurations
{
    public static class ServiceInstallerInjector
    {
        public static IServiceCollection InstallServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostBuilder hostBuilder,
            params Assembly[] assemblies)
        {
            IEnumerable<IServiceInstaller> serviceInstallers = assemblies
                .SelectMany(s => s.DefinedTypes)
                .Where(IsAssignableToType<IServiceInstaller>)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();

            foreach (IServiceInstaller serviceInstaller in serviceInstallers)
            {
                serviceInstaller.Install(services, configuration,hostBuilder);
            }

            return services;

            static bool IsAssignableToType<T>(TypeInfo typeInfo)
                => typeof(T).IsAssignableFrom(typeInfo) &&
                !typeInfo.IsInterface &&
                !typeInfo.IsAbstract;
        }
    }
}
