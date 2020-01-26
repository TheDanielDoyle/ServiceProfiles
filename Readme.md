# Service Profiles

A framework for splitting out the registration of services in __IServiceCollection__ into profiles. No more large Startup.cs classes.

## Quick start (The easy way)

1. When building an IHost, add __ConfigureServicesWithProfiles()__ method to the __IHostBuilder__ to load __Service Profiles__ in the executing assembly.

````csharp
IHostBuilder builder = Host.CreateDefaultBuilder(args).ConfigureServicesWithProfiles();
````               

## Quick start (The manual way)

1. Instantiate a __HostServiceProfileLoader()__ class.

2. Execute one of the __Load()__ methods and pass in the __IServiceCollection__, __IConfiguration__ and __IHostEnvironment__.

````csharp
IHostServiceProfileLoader loader = new HostServiceProfileLoader();
loader.Load(services, Configuration, Environment);
loader.LoadFromAssembly(services, Configuration, Environment, typeof(Program).Assembly);
loader.LoadFromAssemblies(services, Configuration, Environment, new Assembly[] {typeof(Program).Assembly});
````

3. Create profile classes that derive from __HostServiceProfile__ and implement the __Configure()__ method.

````csharp
public class TestProfile : HostServiceProfile
{
    public override void Configure(IHostServiceProfileContext context)
    {
        context.Services.AddBeer();
    }
}
````

## Samples

See the following sample <https://github.com/TheDanielDoyle/ServiceProfiles/blob/develop/Samples/ServiceProfiles.Samples.Console/Program.cs>
