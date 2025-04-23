namespace RBytesNetUtil;

/// <summary>
/// Algoritmos clássicos e úteis.
/// </summary>
public static class RBytesAlgoritmosUtil
{
    /// <summary>
    /// Algoritmo de Kadane: encontra a soma máxima de subarray contíguo.
    /// </summary>
    public static int Kadane(int[] arr)
    {
        int maxAtual = arr[0], maxTotal = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            maxAtual = Math.Max(arr[i], maxAtual + arr[i]);
            maxTotal = Math.Max(maxTotal, maxAtual);
        }
        return maxTotal;
    }

    /// <summary>
    /// Busca binária em um array ordenado.
    /// </summary>
    public static int BuscaBinaria(int[] arr, int alvo)
    {
        int esq = 0, dir = arr.Length - 1;
        while (esq <= dir)
        {
            int meio = (esq + dir) / 2;
            if (arr[meio] == alvo)
                return meio;
            else if (arr[meio] < alvo)
                esq = meio + 1;
            else
                dir = meio - 1;
        }
        return -1;
    }

    /// <summary>
    /// Verifica se uma string é palíndromo.
    /// </summary>
    public static bool EhPalindromo(string texto)
    {
        texto = new string(texto.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        return texto.SequenceEqual(texto.Reverse());
    }
}
