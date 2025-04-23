namespace RBytesNetUtil;

/// <summary>
/// Funções utilitárias para manipulação de arrays.
/// </summary>
public static class RBytesArrayUtil
{
    /// <summary>
    /// Verifica se dois arrays são iguais.
    /// </summary>
    public static bool AreEqual<T>(T[] a, T[] b) where T : IEquatable<T>
    {
        if (a == null || b == null) return false;
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++)
        {
            if (!a[i].Equals(b[i])) return false;
        }
        return true;
    }

    /// <summary>
    /// Inverte os elementos de um array.
    /// </summary>
    public static void Reverse<T>(T[] array)
    {
        if (array == null) return;
        int left = 0;
        int right = array.Length - 1;
        while (left < right)
        {
            (array[left], array[right]) = (array[right], array[left]);
            left++;
            right--;
        }
    }

    /// <summary>
    /// Retorna uma cópia do array sem elementos repetidos.
    /// </summary>
    public static T[] Distinct<T>(T[] array)
    {
        if (array == null) return Array.Empty<T>();
        return array.Distinct().ToArray();
    }

    /// <summary>
    /// Retorna o índice do maior valor em um array de inteiros.
    /// </summary>
    public static int IndexOfMax(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Array não pode ser nulo ou vazio.");

        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex]) maxIndex = i;
        }
        return maxIndex;
    }

    /// <summary>
    /// Retorna o índice do menor valor em um array de inteiros.
    /// </summary>
    public static int IndexOfMin(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Array não pode ser nulo ou vazio.");

        int minIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[minIndex]) minIndex = i;
        }
        return minIndex;
    }
}