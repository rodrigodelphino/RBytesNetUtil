using System;

namespace RBytesNetUtil;

/// <summary>
/// Funções matemáticas auxiliares.
/// </summary>
public static class RBytesCalculation
{
    /// <summary>
    /// Calcula o montante final com base em juros simples.
    /// </summary>
    /// <param name="capital">O valor principal (inicial).</param>
    /// <param name="taxa">A taxa de juros por período. Deve ser em formato decimal (ex: 5% = 0.05).</param>
    /// <param name="tempo">A quantidade de períodos (ex: meses, anos).</param>
    /// <returns>O montante total (capital + juros).</returns>
    public static double CalcularJurosSimples(double capital, double taxa, double tempo)
    {
        if (capital < 0 || taxa < 0 || tempo < 0)
        {
            throw new ArgumentException("Capital, taxa e tempo não podem ser negativos.");
        }

        // Fórmula do Montante em Juros Simples: M = C * (1 + i * t)
        double montante = capital * (1 + taxa * tempo);
        return montante;
    }

    /// <summary>
    /// Calcula o montante final com base em juros compostos.
    /// </summary>
    /// <param name="capital">O valor principal (inicial).</param>
    /// <param name="taxa">A taxa de juros por período. Deve ser em formato decimal (ex: 5% = 0.05).</param>
    /// <param name="tempo">A quantidade de períodos de capitalização.</param>
    /// <returns>O montante total (capital + juros compostos).</returns>
    public static double CalcularJurosCompostos(double capital, double taxa, double tempo)
    {
        if (capital < 0 || taxa < 0 || tempo < 0)
        {
            throw new ArgumentException("Capital, taxa e tempo não podem ser negativos.");
        }

        // Fórmula do Montante em Juros Compostos: M = C * (1 + i)^t
        double montante = capital * Math.Pow(1 + taxa, tempo);
        return montante;
    }

    /// <summary>
    /// Calcula o valor total de juros pagos em uma transação, com base no valor original e no total pago.
    /// </summary>
    /// <param name="valorDoBem">O valor original do bem ou do principal.</param>
    /// <param name="totalPago">O valor total pago, incluindo o principal e os juros.</param>
    /// <returns>O valor absoluto dos juros pagos.</returns>
    /// <exception cref="ArgumentException">Lançada se o total pago for menor que o valor do bem.</exception>
    public static double CalcularJurosTotal(double valorDoBem, double totalPago)
    {
        if (valorDoBem < 0 || totalPago < 0)
        {
            throw new ArgumentException("Os valores não podem ser negativos.");
        }
        if (totalPago < valorDoBem)
        {
            throw new ArgumentException("O total pago não pode ser menor que o valor do bem.");
        }

        return totalPago - valorDoBem;
    }

    /// <summary>
    /// Calcula o valor do juro embutido em cada parcela de um financiamento.
    /// </summary>
    /// <param name="valorDoBem">O valor original do bem ou do principal.</param>
    /// <param name="totalPago">O valor total pago ao final do financiamento.</param>
    /// <param name="numeroDeParcelas">O número total de parcelas.</param>
    /// <returns>O valor do juro contido em uma única parcela.</returns>
    /// <exception cref="ArgumentException">Lançada se o número de parcelas for menor ou igual a zero.</exception>
    public static double CalcularJurosPorParcela(double valorDoBem, double totalPago, int numeroDeParcelas)
    {
        if (numeroDeParcelas <= 0)
        {
            throw new ArgumentException("O número de parcelas deve ser maior que zero.");
        }

        // Reutilizamos a função anterior para obter o juro total
        double jurosTotal = CalcularJurosTotal(valorDoBem, totalPago);

        // Dividimos o juro total pelo número de parcelas
        return jurosTotal / numeroDeParcelas;
    }
}
