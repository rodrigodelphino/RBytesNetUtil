using System;
using RBytesNetUtil;

//exemplos de uso
Console.WriteLine("Fatorial de 5: " + RBytesMathUtil.Fatorial(5));

ExemploExcel();

//EXEMPLO JSON
var pessoa = new { Nome = "Carlos", Idade = 28 };
string json = RBytesJsonUtil.ToJson(pessoa);

var novaPessoa = RBytesJsonUtil.FromJson<Dictionary<string, object>>(json);
Console.WriteLine(novaPessoa["Nome"]); // Carlos

//EXEMPLO MATH
Console.WriteLine(RBytesMathUtil.Fatorial(5));         // 120
Console.WriteLine(RBytesMathUtil.Fibonacci(6));        // 8
Console.WriteLine(RBytesMathUtil.MMC(10, 15));         // 30
Console.WriteLine(RBytesMathUtil.MDC(36, 60));         // 12

//EXEMPLO DATETIME
Console.WriteLine(RBytesDateTimeUtil.ConverterMesExtensoParaNumerico("01"));  // janeiro
Console.WriteLine(RBytesDateTimeUtil.AppendTimeStamp("arquivo.xls"));     

//EXEMPLO SORT
int[] numeros = { 5, 3, 8, 2, 1 };
RBytesSortUtil.BubbleSort(numeros);
Console.WriteLine(string.Join(", ", numeros)); // 1, 2, 3, 5, 8

//EXEMPLO ALGORITMO BUSCA BINARIA
int[] lista = { 1, 3, 5, 7, 9 };
int index = RBytesAlgoritmoUtil.BuscaBinaria(lista, 5);
Console.WriteLine(index); // 2


void ExemploExcel()
{
     // Definindo os dados para o Excel (listas de listas de strings)
        List<List<string>> dados = new List<List<string>>
        {
            new List<string> { "Nome", "Idade", "Cidade" },
            new List<string> { "João", "30", "São Paulo" },
            new List<string> { "Maria", "25", "Rio de Janeiro" },
            new List<string> { "Carlos", "35", "Belo Horizonte" }
        };

        // Definindo o caminho onde o arquivo Excel será salvo
        string caminhoArquivo = @"exemplo_excel.xlsx";
        
        // Chamando a função para criar o arquivo Excel
        try
        {
            RBytesExcelUtil.CriarExcelXLSX(caminhoArquivo, "Planilha1", dados);
            Console.WriteLine($"Arquivo Excel criado com sucesso em {caminhoArquivo}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar o arquivo Excel: {ex.Message}");
        }
}