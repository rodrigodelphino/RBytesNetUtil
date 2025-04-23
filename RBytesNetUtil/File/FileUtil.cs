using System;
using System.IO;

namespace RBytesNetUtil;

/// <summary>
/// Funções utilitárias para manipulação de arquivos.
/// </summary>
public static class RBytesFileUtil
{
    /// <summary>
    /// Lê todo o conteúdo de um arquivo texto.
    /// </summary>
    public static string LerArquivo(string caminho)
    {
        return File.ReadAllText(caminho);
    }

    /// <summary>
    /// Escreve um conteúdo de texto em um arquivo (sobrescrevendo).
    /// </summary>
    public static void EscreverArquivo(string caminho, string conteudo)
    {
        File.WriteAllText(caminho, conteudo);
    }

    /// <summary>
    /// Verifica se um arquivo existe.
    /// </summary>
    public static bool Existe(string caminho)
    {
        return File.Exists(caminho);
    }

    /// <summary>
    /// Lê todas as linhas de um arquivo para um array de strings.
    /// </summary>
    public static string[] LerLinhas(string caminho)
    {
        return File.ReadAllLines(caminho);
    }

    /// <summary>
    /// Escreve um array de strings em um arquivo, uma por linha.
    /// </summary>
    public static void EscreverLinhas(string caminho, string[] linhas)
    {
        File.WriteAllLines(caminho, linhas);
    }

         // <summary>
        /// Método que deleta um arquivo do servidor
        /// </summary>
        /// <param name="localArquivo">local do arquivo</param>
        public static string DeletarArquivo(string localArquivo, bool caminhoAbsoluto = true)
        {
            try
            {
                string arquivoFisico = localArquivo;

                if (!caminhoAbsoluto)
                    arquivoFisico = Path.GetFullPath(localArquivo);

                if (System.IO.File.Exists(arquivoFisico))
                {
                    System.IO.File.Delete(arquivoFisico);
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static long RetornaTamanhoArquivo(string localArquivo, bool caminhoAbsoluto = true)
        {
            try
            {
                string arquivoFisico = localArquivo;

                if (!caminhoAbsoluto)
                    arquivoFisico = Path.GetFullPath(localArquivo);
        
                if (System.IO.File.Exists(arquivoFisico))
                {
                    System.IO.FileStream fs = new(arquivoFisico, System.IO.FileMode.Open);
                    return fs.Length;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

}
