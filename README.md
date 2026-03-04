# Azure Function - .NET 8 (C#) - Isolated Worker

Este projeto contém uma Azure Function desenvolvida em **.NET 8** utilizando o modelo **Isolated Worker**.

A function irá executar uma validação de CPF

---

# 📋 Pré-requisitos

Antes de executar o projeto, instale:

- .NET SDK 8.0
- Azure Functions Core Tools v4
- Visual Studio 2022+ ou VS Code

## Verificar instalações

```bash
dotnet --version
func --version
```

---

# 🚀 Executando o Projeto Localmente

## 1️⃣ Restaurar dependências

```bash
dotnet restore
```

---

## 2️⃣ Configurar variáveis locais

Crie (ou edite) o arquivo:

```
local.settings.json
```

Exemplo:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
  }
}
```

⚠️ **Importante:**  
O arquivo `local.settings.json` não deve ser versionado no repositório.

---

## 3️⃣ Compilar o projeto

```bash
dotnet build
```

---

## 4️⃣ Executar a Function

Você pode iniciar com:

```bash
func start
```

Ou:

```bash
dotnet run
```

O console:

```
http://localhost:7071/api/FunctionValidaCPF
```

---

# 🧪 Testando a Function

## POST (via curl)

```bash
curl -X POST http://localhost:7071/api/FunctionValidaCPF \
     -H "Content-Type: application/json" \
     -d '{"CPF":"2732632260"}'
```

Você também pode testar via Postman.

---

# 📂 Estrutura do Projeto

```
/Projeto
 ├── FunctionValidaCPF.cs
 ├── Program.cs
 ├── host.json
 ├── local.settings.json
 └── fnAzureValidarCPF.csproj
```

---

# ⚙️ Arquivos Importantes

## Program.cs (Modelo .NET 8 Isolated)

```csharp
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
```

---

## host.json (Exemplo básico)

```json
{
  "version": "2.0"
}
```

---

# ☁️ Publicação no Azure

## 1️⃣ Login na Azure

```bash
az login
```

## 2️⃣ Publicar a Function

```bash
func azure functionapp publish NOME_DA_FUNCTION_APP
```

---

# 🔧 Configuração no Azure

As variáveis de ambiente devem ser configuradas em:

```
Function App → Configuration → Application Settings
```

Nunca utilize `local.settings.json` em produção.

---

# 📝 Logs

## Local
Logs aparecem diretamente no console ao executar `func start`.

## Azure
Acesse:

```
Function App → Monitoring → Log Stream
```

---

# 🧹 Comandos Úteis

## Limpar build

```bash
dotnet clean
```

## Restaurar pacotes

```bash
dotnet restore
```

---

# 📌 Observações Importantes

- Runtime utilizado: `dotnet-isolated`
- Azure Functions Version: `v4`
- Framework alvo: `.NET 8`
- Utilize sempre o modelo **Isolated Worker** para novos projetos

---

# ✅ Projeto pronto para execução!

Sua Azure Function em .NET 8 está pronta para rodar localmente e ser publicada no Azure.