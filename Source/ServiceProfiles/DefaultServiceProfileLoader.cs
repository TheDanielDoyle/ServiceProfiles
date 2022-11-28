using System;
using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace ServiceProfiles;

public abstract class DefaultServiceProfileLoader<TEnvironment> : IServiceProfileLoader<TEnvironment> where TEnvironment : IHostEnvironment
{
    public IServiceProfileLoader<TEnvironment> LoadFromAssembly(IServiceProfileContext<TEnvironment> context, Assembly assembly)
    {
        return LoadFromAssemblies(context, new[] { assembly }); ;
    }

    public IServiceProfileLoader<TEnvironment> LoadFromAssemblies(IServiceProfileContext<TEnvironment> context, params Assembly[] assemblies)
    {
        foreach (Assembly assembly in assemblies)
        {
            ConfigureServiceProfiles(assembly, context);
        }
        return this;
    }

    protected void ConfigureServiceProfiles(Assembly assembly, IServiceProfileContext<TEnvironment> context)
    {
        foreach (Type profileType in assembly.GetServiceProfileTypes<TEnvironment>())
        {
            ConfigureServiceProfile(profileType, context);
        }
    }

    protected void ConfigureServiceProfile(Type profileType, IServiceProfileContext<TEnvironment> context)
    {
        try
        {
            IServiceProfile<TEnvironment> profile = (IServiceProfile<TEnvironment>)Activator.CreateInstance(profileType);
            profile.Configure(context);
        }
        catch (Exception exception)
        {
            throw new ServiceProfileLoaderException($"Unable to create service profile instance for {profileType.Name}", exception);
        }
    }
}