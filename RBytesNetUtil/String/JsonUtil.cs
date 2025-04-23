using System.Text.Json;

namespace RBytesNetUtil;

/// <summary>
/// Funções utilitárias para manipulação de JSON.
/// </summary>
public static class RBytesJsonUtil
{
    /// <summary>
    /// Serializa um objeto para uma string JSON.
    /// </summary>
    public static string ToJson<T>(T obj, bool indented = false)
    {
        var options = new JsonSerializerOptions { WriteIndented = indented };
        return JsonSerializer.Serialize(obj, options);
    }

    /// <summary>
    /// Desserializa uma string JSON para um objeto do tipo informado.
    /// </summary>
    public static T FromJson<T>(string json)
    {
            // Verifica se o json é nulo ou vazio
    if (string.IsNullOrEmpty(json))
        throw new ArgumentNullException(nameof(json), "O JSON não pode ser nulo ou vazio.");
    
        // Tenta desserializar o JSON
    return JsonSerializer.Deserialize<T>(json) 
           ?? throw new JsonException("Falha ao desserializar o JSON.");
    }

    /// <summary>
    /// Verifica se uma string é um JSON válido.
    /// </summary>
    public static bool IsValidJson(string json)
    {
        try
        {
            JsonDocument.Parse(json);
            return true;
        }
        catch
        {
            return false;
        }
    }

        public static object JsonMessage(int codigo, string descricao)
    {
        return new { Cod = codigo, Dsc = descricao };
    }

    public static object JsonMessage(string codigo, string descricao)
    {
        return new { Cod = codigo, Dsc = descricao };
    }

    public static object JsonMessageCanalComunicacao(string codigo, string descricao, string perfil, string nomeUsuario)
    {
        return new { Cod = codigo, Dsc = descricao, Perfil = perfil, UsuarioOrigem = nomeUsuario };
    }

    public static object JsonRedirect(string action, string controller)
    {
        return new { Action = action, Controller = controller };
    }

    public static object JsonRedirect(int codigo, string action, string controller, string param1)
    {
        return new { Cod = codigo, Action = action, Controller = controller, Param1 = param1 };
    }

    public static object JsonRedirect(string action, string controller, string param1)
    {
        return new { Action = action, Controller = controller, Param1 = param1 };
    }

    public static object JsonRedirect(string action, string controller, string param1, string param2)
    {
        return new { Action = action, Controller = controller, Param1 = param1, Param2 = param2 };
    }
    public static object JsonRedirect(string action, string controller, string param1, string param2, string param3)
    {
        return new { Action = action, Controller = controller, Param1 = param1, Param2 = param2, Param3 = param3 };
    }
    public static object JsonRedirect(int codigo, string action, string controller, string param1, string param2)
    {
        return new { Cod = codigo, Action = action, Controller = controller, Param1 = param1, Param2 = param2 };
    }
}
