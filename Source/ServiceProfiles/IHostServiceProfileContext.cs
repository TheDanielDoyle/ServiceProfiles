using Microsoft.Extensions.Hosting;

namespace ServiceProfiles;

public interface IHostServiceProfileContext : IServiceProfileContext<IHostEnvironment>
{
}