# AzureFunctions.Swagger

- Azure Functions
- .NET Core 3.1
- AzureExtensions.Swashbuckle

### csproj
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <AzureFunctionsVersion>v3</AzureFunctionsVersion>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="AzureExtensions.Swashbuckle" Version="3.2.2" />
    <PackageReference Include="Microsoft.NET.Sdk.Functions" Version="3.0.9" />
  </ItemGroup>
  <ItemGroup>
    <None Update="host.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Update="local.settings.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
      <CopyToPublishDirectory>Never</CopyToPublishDirectory>
    </None>
  </ItemGroup>
</Project>
```

### FunctionController
```csharp
public static class FunctionController
    {
        [FunctionName("function-get")]
        public static IActionResult Run(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            return new OkObjectResult("Get Ok");
        }
    }
```

### SwaggerController
```csharp
public static class SwaggerController
    {
        [SwaggerIgnore]
        [FunctionName("Swagger")]
        public static Task<HttpResponseMessage> RunSwagger(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Swagger/json")] HttpRequestMessage req,
                [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerDocumentResponse(req));
        }

        [SwaggerIgnore]
        [FunctionName("SwaggerUi")]
        public static Task<HttpResponseMessage> RunSwaggerUi(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Swagger/ui")] HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerUIResponse(req, "swagger/json"));
        }
    }
```

### host
```json
{
  "version": "2.0",
  "logging": {
    "fileLoggingMode": "always",
    "logLevel": {
      "default": "Information",
      "Host.Results": "Error",
      "Function": "Error",
      "Host.Aggregator": "Trace"
    }
  }
}
```

### SwashBuckleStartup
```csharp
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
```
