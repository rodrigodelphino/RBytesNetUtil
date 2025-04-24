# RBytesNetUtil

Biblioteca utilitária para .NET com funções comuns de manipulação de dados, datas, arquivos, ordenações, algoritmos e geração de planilhas Excel simples sem dependências externas.

## 🚀 Funcionalidades Disponíveis

- 📊 Geração de arquivos Excel (.xlsx) com estrutura XML pura
- 🔢 Funções matemáticas (Fatorial, Fibonacci, MMC, MDC...)
- 🧠 Algoritmos úteis (Busca Binária, Kadane, Palíndromo...)
- 🔤 Ordenações (Bubble Sort, Quick Sort, Merge Sort...)
- 📅 Utilitários de data e hora
- 📦 Manipulação de JSON
- 🌐 Utilitários de rede

## 💡 Exemplos de Uso

### 📊 Excel — Criar um arquivo .xlsx simples

```csharp
var dados = new List<List<string>>
{
    new() { "Nome", "Idade", "Cidade" },
    new() { "Ana", "30", "São Paulo" },
    new() { "Bruno", "25", "Rio de Janeiro" }
};

RBytesExcelUtil.CriarExcelXLSX("dados.xlsx", "Pessoas", dados);
```

---

### 🔢 Json — Serializar e desserializar objetos

```csharp
var pessoa = new { Nome = "Carlos", Idade = 28 };
string json = RBytesJsonUtil.ToJson(pessoa);

var novaPessoa = RBytesJsonUtil.FromJson<Dictionary<string, object>>(json);
Console.WriteLine(novaPessoa["Nome"]); // Carlos
```

---

### 🧮 Math — Fatorial, Fibonacci, MMC e MDC

```csharp
Console.WriteLine(RBytesMathUtil.Fatorial(5));         // 120
Console.WriteLine(RBytesMathUtil.Fibonacci(6));        // 8
Console.WriteLine(RBytesMathUtil.MMC(10, 15));         // 30
Console.WriteLine(RBytesMathUtil.MDC(36, 60));         // 12
```

---

### 📅 DateTime — Datas úteis

```csharp
Console.WriteLine(RBytesDateTimeUtil.ConverterMesExtensoParaNumerico("01"));          // janeiro
Console.WriteLine(RBytesDateTimeUtil.AppendTimeStamp("arquivo.xls"));     
```

---

### 🔤 Sort — Algoritmos de ordenação

```csharp
int[] numeros = { 5, 3, 8, 2, 1 };
RBytesSortUtil.BubbleSort(numeros);
Console.WriteLine(string.Join(", ", numeros)); // 1, 2, 3, 5, 8
```

---

### 🔎 Algoritmos — Busca Binária

```csharp
int[] lista = { 1, 3, 5, 7, 9 };
int index = RBytesAlgoritmoUtil.BuscaBinaria(lista, 5);
Console.WriteLine(index); // 2
```

---

## 📦 Como instalar

```bash
# Em seu terminal:
dotnet add package RBytesNetUtil
```

Ou copie o código do repositório [RBytesNetUtil](https://github.com/rodrigodelphino/RBytesNetUtil) diretamente.

## 📂 Organização

- `Excel/ExcelUtil.cs`
- `Json/JsonUtil.cs`
- `Sort/SortUtil.cs`
- `Math/MathUtil.cs`
- `DateTime/DateTimeUtil.cs`
- `Algorithms/AlgoritmoUtil.cs`
- `Others/NetworkUtil.cs`

---

# RBytesNetUtil

Biblioteca utilitária em .NET focada em produtividade, reutilização de código e simplicidade.

Contém funções comuns para manipulação de arquivos, datas, textos, formatações (CPF, CNPJ, CEP, etc), operações matemáticas e muito mais.

---

## 📁 Estrutura do projeto

- `RBytesNetUtil/` — Código-fonte da biblioteca.
- `RBytesNetUtil.Tests/` — Projeto de testes unitários com xUnit.
- `Samples/` — Exemplos práticos de uso.
- `RBytesNetUtil.sln` — Solução do Visual Studio / .NET CLI.

---

## 🚀 Comandos úteis para desenvolvimento (.NET)

### ▶️ Executar exemplo (via CLI)
```bash
dotnet run --project Samples
```

### 🧪 Executar todos os testes
```bash
dotnet test
```

### 🔧 Compilar a solução
```bash
dotnet build MinhaBiblioteca.sln
```

### 🧹 Restaurar pacotes e limpar build
```bash
dotnet restore

dotnet clean
```

### 📦 Adicionar novo pacote NuGet
```bash
dotnet add package NomeDoPacote
```

### 📄 Atualizar todos os pacotes NuGet (via PowerShell)
```powershell
Get-Project | ForEach-Object { dotnet list $_.Name package --outdated }
```

Ou use a interface do Visual Studio para gerenciar pacotes NuGet graficamente.

---

## 🆕 Como criar novos projetos no .NET

Esses comandos ajudam a criar novos tipos de projetos e adicioná-los à solução (`.sln`) existente:

### 📚 Biblioteca de Classes (Class Library)
Cria um novo projeto de biblioteca com código reutilizável:
```bash
dotnet new classlib -n MinhaBiblioteca.Utils
# Adiciona o projeto à solução
dotnet sln MinhaBiblioteca.sln add MinhaBiblioteca.Utils/MinhaBiblioteca.Utils.csproj
```

### 🧪 Projeto de Testes com xUnit
Ideal para testar funcionalidades da biblioteca:
```bash
dotnet new xunit -n MinhaBiblioteca.Utils.Tests
# Adiciona à solução e cria referência à biblioteca
dotnet sln MinhaBiblioteca.sln add MinhaBiblioteca.Utils.Tests/MinhaBiblioteca.Utils.Tests.csproj
dotnet add MinhaBiblioteca.Utils.Tests reference MinhaBiblioteca.Utils
```

### 🌐 API Web (Web API)
Cria um backend simples via HTTP:
```bash
dotnet new webapi -n MinhaBiblioteca.Api
# Adiciona à solução
dotnet sln MinhaBiblioteca.sln add MinhaBiblioteca.Api/MinhaBiblioteca.Api.csproj
```

### 🖥 Aplicativo de Console (Exemplo)
Útil para demonstrar uso da biblioteca:
```bash
dotnet new console -n Samples.ExemploNovo
# Adiciona à solução
dotnet sln MinhaBiblioteca.sln add Samples.ExemploNovo/Samples.ExemploNovo.csproj
```

> 💡 *Dica:* a extensão `.sln` (solution) organiza vários projetos em um mesmo repositório, facilitando o desenvolvimento e testes conjuntos.

---

## 🤝 Contribuição

Pull requests são bem-vindos! Sinta-se à vontade para abrir issues, reportar bugs ou sugerir melhorias. Este projeto visa ser simples e acessível para toda a comunidade .NET.

---

Por Rodrigo Delphino - [github.com/rodrigodelphino](https://github.com/rodrigodelphino)

