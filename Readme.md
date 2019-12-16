# Service Profiles

A framework for splitting out the registration of services in __IServiceCollection__ into profiles. No more large Startup.cs classes.

## Quick start

1. Instantiate a __HostServiceProfileLoader()__ class.

2. Execute one of the __Load()__ methods and pass in the __IServiceCollection__, __IConfiguration__ and __IHostEnvironment__.

````csharp
IHostServiceProfileLoader loader = new HostServiceProfileLoader();
loader.Load(services, Configuration, Environment);
loader.LoadFromAssembly(services, Configuration, Environment, typeof(Program).Assembly);
loader.LoadFromAssemblies(services, Configuration, Environment, new Assembly[] {typeof(Program).Assembly});
````

3. Create profile classes that derive from __HostServiceProfileLoader__ and implement the __Configure()__ method.

````csharp
public class TestProfile : HostServiceProfile
{
    public override void Configure(IServiceProfileContext<IHostEnvironment> context)
    {
        context.Services.AddBeer();
    }
}
````

## Samples

See the following sample <https://github.com/TheDanielDoyle/ServiceProfiles/blob/develop/Samples/ServiceProfiles.Samples.Console/Program.cs>
