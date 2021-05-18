using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Swagger.Presentation;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System.Reflection;

[assembly: WebJobsStartup(typeof(SwashBuckleStartup))]
namespace AzureFunctions.Swagger.Presentation
{
    internal class SwashBuckleStartup : IWebJobsStartup
    {
        [System.Obsolete]
        public void Configure(IWebJobsBuilder builder)
        {
            _ = builder.AddSwashBuckle(Assembly.GetExecutingAssembly());
        }
    }
}