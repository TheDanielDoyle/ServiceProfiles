using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace ServiceProfiles
{
    public interface IServiceProfileLoader<in TEnvironment> where TEnvironment : IHostEnvironment
    {
        IServiceProfileLoader<TEnvironment> LoadFromAssemblies(IServiceProfileContext<TEnvironment> context, params Assembly[] assemblies);
    }
}
