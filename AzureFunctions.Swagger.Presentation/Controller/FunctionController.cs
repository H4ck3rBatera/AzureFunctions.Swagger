using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace AzureFunctions.Swagger.Presentation.Controller
{
    public static class FunctionController
    {
        [FunctionName("function-get")]
        public static IActionResult Run(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            return new OkObjectResult("Get Ok");
        }
    }
}