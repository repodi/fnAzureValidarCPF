using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
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
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        _logger.LogInformation("Iniciando a execução da função de validação de CPF");
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data =  JsonSerializer.Deserialize<ValidarCPFRequest>(requestBody);
        if (data == null || string.IsNullOrWhiteSpace(data.CPF))
        {
            return new BadRequestObjectResult("Informar o CPF");
        }
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}