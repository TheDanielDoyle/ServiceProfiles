using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceProfiles
{
    public interface IServiceProfileContext<out TEnvironment> where TEnvironment : IHostEnvironment
    {
        IConfiguration Configuration { get; }

        TEnvironment Environment { get; }

        IServiceCollection Services { get; }
    }
}