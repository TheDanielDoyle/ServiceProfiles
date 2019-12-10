using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceProfiles
{
    public interface IHostServiceProfileLoader : IServiceProfileLoader<IHostEnvironment>
    {
        IHostServiceProfileLoader Load(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment);

        IHostServiceProfileLoader LoadFromAssemblies(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment, params Assembly[] assemblies);

        IHostServiceProfileLoader LoadFromAssembly(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment, Assembly assembly);
    }
}