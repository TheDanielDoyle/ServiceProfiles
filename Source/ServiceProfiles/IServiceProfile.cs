using Microsoft.Extensions.Hosting;

namespace ServiceProfiles;

public interface IServiceProfile<in TEnvironment> where TEnvironment : IHostEnvironment
{
    void Configure(IServiceProfileContext<TEnvironment> context);
}