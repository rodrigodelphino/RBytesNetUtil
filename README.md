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

Contribuições são bem-vindas! 🚀
