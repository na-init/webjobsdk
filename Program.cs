using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebJobsSDKSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath (Directory.GetCurrentDirectory())
                .AddJsonFile ("appsettings.json", optional: false, reloadOnChange: true)
                .Build ();
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddTimers();
            });
            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();

            });
            
            var host = builder.Build();
            using (host)
            {
                var jobHost = host.Services.GetService<IJobHost>();
                await host.StartAsync();
               await jobHost.CallAsync("TimerFunction");
                await host.StopAsync();
                //host.Run();
            }
        }
    }
}