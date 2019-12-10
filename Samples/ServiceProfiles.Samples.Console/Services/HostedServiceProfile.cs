using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceProfiles.Samples.Console.Services
{
    public class HostedServiceProfile : HostServiceProfile
    {
        public override void Configure(IServiceProfileContext<IHostEnvironment> context)
        {
            context.Services.AddHostedService<MerryChristmasHostedService>();
        }
    }
}
