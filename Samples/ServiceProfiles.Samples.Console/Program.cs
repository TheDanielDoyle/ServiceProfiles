using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ServiceProfiles.Samples.Console
{
    internal class Program
    {
        public static async Task<int> Main(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    IHostServiceProfileLoader loader = new HostServiceProfileLoader();
                    loader.Load(services, context.Configuration, context.HostingEnvironment);
                });
            using (IHost host = builder.Build())
            {
                await host.RunAsync();
            }
            return 0;
        }
    }
}
