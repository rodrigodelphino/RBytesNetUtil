using System;
using RBytesNetUtil;

//exemplos de uso
Console.WriteLine("Fatorial de 5: " + RBytesMathUtil.Fatorial(5));

ExemploExcel();

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