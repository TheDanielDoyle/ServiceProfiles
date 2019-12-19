using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ServiceProfiles.Samples.Console.Profiles
{
    public class DefaultProfile : HostServiceProfile
    {
        public override void Configure(IHostServiceProfileContext context)
        {
            context.Services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Information);
            });
        }
    }
}
