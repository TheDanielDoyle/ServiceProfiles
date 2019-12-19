using Microsoft.Extensions.DependencyInjection;

namespace ServiceProfiles.Samples.Console.Profiles
{
    public class HostedServiceProfile : HostServiceProfile
    {
        public override void Configure(IHostServiceProfileContext context)
        {
            context.Services.AddHostedService<MerryChristmasHostedService>();
        }
    }
}
