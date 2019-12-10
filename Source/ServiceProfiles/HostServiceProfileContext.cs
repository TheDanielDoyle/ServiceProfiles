using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceProfiles
{
    public class HostServiceProfileContext : IServiceProfileContext<IHostEnvironment>
    {
        public HostServiceProfileContext(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            Services = services;
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IHostEnvironment Environment { get; }

        public IServiceCollection Services { get; }
    }
}