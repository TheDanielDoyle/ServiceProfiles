using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ServiceProfiles.Samples.Console.Services
{
    public class DefaultProfile : HostServiceProfile
    {
        public override void Configure(IServiceProfileContext<IHostEnvironment> context)
        {
            context.Services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Information);
            });
        }
    }
}
