using System;

namespace RBytesNetUtil;

/// <summary>
/// Funções matemáticas auxiliares.
/// </summary>
public static class RBytesMathUtil
{
    /// <summary>
    /// Retorna o fatorial de um número.
    /// </summary>
    /// <param name="n">Número inteiro não-negativo</param>
    /// <returns>Fatorial de n</returns>
    public static long Fatorial(int n)
    {
        if (n < 0) throw new ArgumentException("Número deve ser não-negativo.");
        return n == 0 ? 1 : n * Fatorial(n - 1);
    }

    /// <summary>
    /// Retorna o n-ésimo número de Fibonacci (iterativo).
    /// </summary>
    /// <param name="n">Posição</param>
    /// <returns>Número de Fibonacci</returns>
    public static long Fibonacci(int n)
    {
        if (n < 0) throw new ArgumentException("Número deve ser não-negativo.");
        if (n == 0) return 0;
        if (n == 1) return 1;

        long a = 0, b = 1, c = 0;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }

    /// <summary>
    /// Retorna o máximo divisor comum (MDC) entre dois números.
    /// </summary>
    public static int MDC(int a, int b)
    {
        return b == 0 ? a : MDC(b, a % b);
    }

    /// <summary>
    /// Retorna o mínimo múltiplo comum (MMC) entre dois números.
    /// </summary>
    public static int MMC(int a, int b)
    {
        return Math.Abs(a * b) / MDC(a, b);
    }

    /// <summary>
    /// Retorna o maior valor de um array de inteiros.
    /// </summary>
    public static int Max(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Array não pode ser nulo ou vazio.");

        int max = array[0];
        foreach (var num in array)
            if (num > max) max = num;

        return max;
    }

    /// <summary>
    /// Retorna o menor valor de um array de inteiros.
    /// </summary>
    public static int Min(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Array não pode ser nulo ou vazio.");

        int min = array[0];
        foreach (var num in array)
            if (num < min) min = num;

        return min;
    }
}
