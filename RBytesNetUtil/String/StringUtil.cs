using System.Text.RegularExpressions;

namespace RBytesNetUtil;

/// <summary>
/// Funções utilitárias para manipulação de strings.
/// </summary>
public static class RBytesStringUtil
{
    /// <summary>
    /// Remove todos os caracteres não numéricos de uma string.
    /// </summary>
    public static string SomenteNumeros(string input)
    {
        return Regex.Replace(input ?? string.Empty, "[^0-9]", "");
    }

    /// <summary>
    /// Converte a primeira letra de cada palavra para maiúscula.
    /// </summary>
    public static string Capitalizar(string input)
    {
        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input?.ToLower() ?? string.Empty);
    }

    /// <summary>
    /// Verifica se uma string é um palíndromo.
    /// </summary>
    public static bool EhPalindromo(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;
        string texto = Regex.Replace(input.ToLower(), "[^a-z0-9]", "");
        return texto.SequenceEqual(texto.Reverse());
    }

    /// <summary>
    /// Conta quantas vezes uma substring aparece dentro da string.
    /// </summary>
    public static int ContarOcorrencias(string texto, string termo)
    {
        if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(termo)) return 0;
        return Regex.Matches(texto, Regex.Escape(termo)).Count;
    }

    /// <summary>
    /// Inverte uma string.
    /// </summary>
    public static string Reverter(string input)
    {
        return new string((input ?? string.Empty).Reverse().ToArray());
    }

public static string RemoverFormatacaoCpfCnpj(string valor)
{
    if (string.IsNullOrEmpty(valor)) return "";

    return valor.Replace(".", string.Empty)
                    .Replace("-", string.Empty)
                    .Replace("/", string.Empty);
}

public static string RemoverFormatacaoTelefone(string valor)
{
    if (string.IsNullOrEmpty(valor)) return "";

    return valor.Replace(" ", string.Empty)
                   .Replace("-", string.Empty)
                   .Replace("(", string.Empty)
                   .Replace(")", string.Empty);
}

public static string PrimeiraEmMaiscula(this string valor)
{
    switch (valor)
    {
        case null: throw new ArgumentNullException(nameof(valor));
        case "": throw new ArgumentException($"{nameof(valor)} não pode ser nulo", nameof(valor));
        default: return valor.First().ToString().ToUpper() + valor.Substring(1);
    }
}

public static string FormatarCpfCnpj(string documento)
{
    if (string.IsNullOrEmpty(documento)) 
        return string.Empty;

    documento = Regex.Replace(documento, "[^0-9]", ""); // Remove tudo que não for número

    if (documento.Length == 11) // CPF
        return Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00");

    if (documento.Length == 14) // CNPJ
        return Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");

    return documento; // Retorna original se não for CPF ou CNPJ válido
}

public static string IncluirPontoFinal(string texto, bool removerUltimoCaractere = true)
{
    if (string.IsNullOrEmpty(texto))
        return string.Empty;

    if (removerUltimoCaractere)
    {
        texto = texto[..^1]; // Remove o último caractere

        if (!texto.EndsWith("."))
            texto += "."; // Adiciona o ponto final
    }
    else
    {
        texto += ".";
    }

    return texto; 
}

public static string FormatarTelefone(string telefone)
{
    if (string.IsNullOrEmpty(telefone))
        return string.Empty;

    telefone = Regex.Replace(telefone, "[^0-9]", ""); // Remove tudo que não for número

    if (telefone.Length == 11) // Celular com DDD (ex: 11 98765-4321)
        return Convert.ToUInt64(telefone).ToString(@"(00) 00000-0000");

    if (telefone.Length == 10) // Telefone fixo com DDD (ex: 11 3456-7890)
        return Convert.ToUInt64(telefone).ToString(@"(00) 0000-0000");

    if (telefone.Length == 9) // Celular sem DDD (ex: 98765-4321)
        return Convert.ToUInt64(telefone).ToString(@"00000-0000");

    if (telefone.Length == 8) // Fixo sem DDD (ex: 3456-7890)
        return Convert.ToUInt64(telefone).ToString(@"0000-0000");

    return telefone; // Retorna original se não for um número válido
}

}
