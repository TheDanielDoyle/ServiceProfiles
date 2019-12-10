using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceProfiles
{
    public class HostServiceProfileLoader : DefaultServiceProfileLoader<IHostEnvironment>, IHostServiceProfileLoader
    {
        public IHostServiceProfileLoader Load(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            return LoadFromAssembly(services, configuration, environment, Assembly.GetCallingAssembly());
        }

        public IHostServiceProfileLoader LoadFromAssemblies(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment, params Assembly[] assemblies)
        {
            HostServiceProfileLoader loader = new HostServiceProfileLoader();
            loader.LoadFromAssemblies(new HostServiceProfileContext(services, configuration, environment), assemblies);
            return loader;
        }

        public IHostServiceProfileLoader LoadFromAssembly(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment, Assembly assembly)
        {
            return LoadFromAssemblies(services, configuration, environment, new[] { assembly });
        }
    }
}