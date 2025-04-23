using System.Globalization;
using System.Text.RegularExpressions;

namespace RBytesNetUtil;

/// <summary>
/// Funções utilitárias para formatação de dados.
/// </summary>
public static class RBytesFormatUtil
{
    /// <summary>
    /// Formata uma string como CPF.
    /// </summary>
    public static string FormatarCPF(string cpf)
    {
        cpf = Regex.Replace(cpf ?? string.Empty, "[^0-9]", "").PadLeft(11, '0');
        return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
    }

    /// <summary>
    /// Formata uma string como CNPJ.
    /// </summary>
    public static string FormatarCNPJ(string cnpj)
    {
        cnpj = Regex.Replace(cnpj ?? string.Empty, "[^0-9]", "").PadLeft(14, '0');
        return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
    }

    /// <summary>
    /// Formata uma string como CEP.
    /// </summary>
    public static string FormatarCEP(string cep)
    {
        cep = Regex.Replace(cep ?? string.Empty, "[^0-9]", "").PadLeft(8, '0');
        return Convert.ToUInt32(cep).ToString(@"00000\-000");
    }

    /// <summary>
    /// Formata uma string como número de telefone (formato brasileiro).
    /// </summary>
    public static string FormatarTelefone(string telefone)
    {
        telefone = Regex.Replace(telefone ?? string.Empty, "[^0-9]", "");
        if (telefone.Length == 10)
            return Convert.ToUInt64(telefone).ToString(@"(00) 0000\-0000");
        else if (telefone.Length == 11)
            return Convert.ToUInt64(telefone).ToString(@"(00) 00000\-0000");
        return telefone;
    }

    /// <summary>
    /// Formata uma data no padrão brasileiro (dd/MM/yyyy).
    /// </summary>
    public static string FormatarData(DateTime data)
    {
        return data.ToString("dd/MM/yyyy");
    }

    /// <summary>
    /// Formata um valor decimal como moeda brasileira.
    /// </summary>
    public static string FormatarMoeda(decimal valor)
    {
        return valor.ToString("C", new CultureInfo("pt-BR"));
    }
}
