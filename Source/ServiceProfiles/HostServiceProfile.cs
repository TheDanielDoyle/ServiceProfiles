using Microsoft.Extensions.Hosting;

namespace ServiceProfiles
{
    public abstract class HostServiceProfile : DefaultServiceProfile, IServiceProfile<IHostEnvironment>
    {
        void IServiceProfile<IHostEnvironment>.Configure(IServiceProfileContext<IHostEnvironment> context)
        {
            Configure(context as IHostServiceProfileContext);
        }

        public abstract void Configure(IHostServiceProfileContext context);
    }
}