using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function;

public class FunctionValidaCPF
{
    private readonly ILogger<FunctionValidaCPF> _logger;

    public FunctionValidaCPF(ILogger<FunctionValidaCPF> logger)
    {
        _logger = logger;
    }

    [Function("FunctionValidaCPF")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}