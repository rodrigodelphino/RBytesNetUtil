using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace RBytesNetUtil;

/// <summary>
/// Funções utilitárias para rede.
/// </summary>
public static class RBytesNetworkUtil
{
    /// <summary>
    /// Verifica se a máquina está conectada à internet.
    /// </summary>
    public static bool EstaConectado()
    {
        try
        {
            using var clientWeb = new HttpClient();
            var content = clientWeb.GetStringAsync("http://www.google.com");
            return true;
            
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Obtém o nome do host da máquina local.
    /// </summary>
    public static string NomeHost()
    {
        return Dns.GetHostName();
    }

    /// <summary>
    /// Obtém os endereços IP da máquina local.
    /// </summary>
    public static IEnumerable<string> ObterEnderecosIP()
    {
        return Dns.GetHostAddresses(Dns.GetHostName())
                  .Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                  .Select(ip => ip.ToString());
    }

    /// <summary>
    /// Verifica se um host está acessível (ping).
    /// </summary>
    public static bool Ping(string host)
    {
        try
        {
            using var ping = new Ping();
            var reply = ping.Send(host, 3000);
            return reply.Status == IPStatus.Success;
        }
        catch
        {
            return false;
        }
    }
}
