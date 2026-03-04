using System.Text.Json;
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
        var response = new ValidarCPFResponse();

        _logger.LogInformation("Iniciando a execução da função de validação de CPF");
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonSerializer.Deserialize<ValidarCPFRequest>(requestBody);
        if (data == null || string.IsNullOrWhiteSpace(data.CPF))
        {
            response = MontarRetorno(false, "Obrigatório informar o CPF");
            return new BadRequestObjectResult(response);
        }

        if (data.CPF.Length < 11)
            data.CPF = data.CPF.PadLeft(11,'0');

        if (!HelperCPF.IsCpf(data.CPF))
        {
            response = MontarRetorno(false, "O CPF é inválido");
            return new BadRequestObjectResult(response);
        }
            

        var cpfSomenteNumeros = HelperCPF.SemFormatacao(data.CPF);
        var cpfFormatado = HelperCPF.FormatCPF(cpfSomenteNumeros);
        response = MontarRetorno(true, "O CPF é válido");
        response.CPFFormatado = cpfFormatado;
        return new OkObjectResult(response);
    }

    private ValidarCPFResponse MontarRetorno(bool sucesso, string mensagem)
    {
        return new ValidarCPFResponse()
        {
            Sucesso = sucesso,
            Mensagem = mensagem
        };
    }

}