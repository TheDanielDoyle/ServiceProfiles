using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ServiceProfiles;

namespace Microsoft.Extensions.Hosting;

public static class IHostBuilderExtensions
{
    public static IHostBuilder ConfigureServicesWithProfiles(this IHostBuilder builder)
    {
        return ConfigureServicesWithProfiles(builder, default(Action<HostBuilderContext, IServiceCollection>), Assembly.GetCallingAssembly());
    }

    public static IHostBuilder ConfigureServicesWithProfiles(this IHostBuilder builder, Action<HostBuilderContext, IServiceCollection> configureDelegate)
    {
        return ConfigureServicesWithProfiles(builder, configureDelegate, Assembly.GetCallingAssembly());
    }

    public static IHostBuilder ConfigureServicesWithProfiles(this IHostBuilder builder, params Assembly[] assemblies)
    {
        return ConfigureServicesWithProfiles(builder, default(Action<HostBuilderContext, IServiceCollection>), assemblies);
    }

    public static IHostBuilder ConfigureServicesWithProfiles(this IHostBuilder builder, Action<HostBuilderContext, IServiceCollection> configureDelegate, params Assembly[] assemblies)
    {
        builder.ConfigureServices((context, services) =>
        {
            configureDelegate?.Invoke(context, services);
            IHostServiceProfileLoader loader = new HostServiceProfileLoader();
            loader.LoadFromAssemblies(services, context.Configuration, context.HostingEnvironment, assemblies);
        });
        return builder;
    }
}