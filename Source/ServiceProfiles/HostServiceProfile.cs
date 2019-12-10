using Microsoft.Extensions.Hosting;

namespace ServiceProfiles
{
    public abstract class HostServiceProfile : DefaultServiceProfile, IServiceProfile<IHostEnvironment>
    {
        public abstract void Configure(IServiceProfileContext<IHostEnvironment> context);
    }
}