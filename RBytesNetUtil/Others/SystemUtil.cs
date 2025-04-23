using System.Runtime.InteropServices;

namespace RBytesNetUtil;

/// <summary>
/// Funções utilitárias para informações do sistema.
/// </summary>
public static class RBytesSystemUtil
{
    /// <summary>
    /// Retorna o nome da máquina atual.
    /// </summary>
    public static string NomeDaMaquina()
    {
        return Environment.MachineName;
    }

    /// <summary>
    /// Retorna o sistema operacional.
    /// </summary>
    public static string SistemaOperacional()
    {
        return RuntimeInformation.OSDescription;
    }

    /// <summary>
    /// Verifica se o sistema operacional é Windows.
    /// </summary>
    public static bool EhWindows()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }

    /// <summary>
    /// Verifica se o sistema operacional é Linux.
    /// </summary>
    public static bool EhLinux()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }

    /// <summary>
    /// Retorna a quantidade de processadores lógicos.
    /// </summary>
    public static int NumeroDeProcessadores()
    {
        return Environment.ProcessorCount;
    }

    /// <summary>
    /// Retorna o diretório atual do processo.
    /// </summary>
    public static string DiretorioAtual()
    {
        return Environment.CurrentDirectory;
    }
}