using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Logging;

namespace WebJobsSDKSample
{
    public class Functions
    {
        

        [FunctionName("TimerFunction")]
        public async Task RunAsyn([TimerTrigger ("%cronsetting%")] TimerInfo myTimer, ILogger log)
        {
            
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}