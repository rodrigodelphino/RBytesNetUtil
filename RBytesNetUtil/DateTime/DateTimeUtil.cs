using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBytesNetUtil;

/// <summary>
/// Funções auxiliares para manipulação de datas e horas.
/// </summary>
public static class RBytesDateTimeUtil
{
    /// <summary>
    /// Retorna a data atual em UTC.
    /// </summary>
    public static DateTime UtcNow()
    {
        return DateTime.UtcNow;
    }

    /// <summary>
    /// Retorna a diferença entre duas datas em dias.
    /// </summary>
    public static int DiasEntre(DateTime inicio, DateTime fim)
    {
        return (fim.Date - inicio.Date).Days;
    }

    /// <summary>
    /// Verifica se uma data é final de semana.
    /// </summary>
    public static bool EhFinalDeSemana(DateTime data)
    {
        return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
    }

    /// <summary>
    /// Retorna o primeiro dia do mês da data informada.
    /// </summary>
    public static DateTime PrimeiroDiaDoMes(DateTime data)
    {
        return new DateTime(data.Year, data.Month, 1);
    }

    /// <summary>
    /// Retorna o último dia do mês da data informada.
    /// </summary>
    public static DateTime UltimoDiaDoMes(DateTime data)
    {
        return new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
    }

    /// <summary>
    /// Converte string para DateTime no formato brasileiro (dd/MM/yyyy).
    /// </summary>
    public static DateTime ParseDataBrasileira(string data)
    {
        return DateTime.ParseExact(data, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Formata um DateTime no formato brasileiro (dd/MM/yyyy).
    /// </summary>
    public static string FormatarDataBrasileira(DateTime data)
    {
        return data.ToString("dd/MM/yyyy");
    }

     public static string ConverterMesExtensoParaNumerico(string mes)
 {
     if (String.IsNullOrEmpty(mes)) return "";

     switch(mes.ToLower().Trim())
     {
         case "janeiro":
             return "01";
         case "fevereiro":
             return "02";
         case "março":
             return "03";
         case "abril":
             return "04";
         case "maio":
             return "05";
         case "junho":
             return "06";
         case "julho":
             return "07";
         case "agosto":
             return "08";
         case "setembro":
             return "09";
         case "outubro":
             return "10";
         case "novembro":
             return "11";
         case "dezembro":
             return "12";
         default:
             return "";
     }
 }

 public static string ConverterParaTextoFormatoDataHoraPtBr(this DateTime? data)
 {
     return data.HasValue ? data.Value.ConverterParaTextoFormatoDataHoraPtBr() : String.Empty;
 }
 public static string ConverterParaTextoFormatoDataHoraPtBr(this DateTime data)
 {
     return data.ToString("dd/MM/yyyy HH:mm:ss");
 }
 public static string ConverterParaTextoFormatoDataPtBr(this DateTime? data)
 {
     return data.HasValue ? data.Value.ConverterParaTextoFormatoDataPtBr() : String.Empty;
 }
 public static string ConverterParaTextoFormatoDataPtBr(this DateTime data)
 {
     return data.ToString("dd/MM/yyyy");
 }

 public static int ObterDiferencaEmMeses(this DateTime primeiraData, DateTime segundaData)
 {
     return Math.Abs((segundaData.Month - primeiraData.Month) + 12 * (segundaData.Year - primeiraData.Year));
 }

 public static double ObterDiferencaEmDias(DateTime primeiraData, DateTime segundaData)
 {
     return (primeiraData - segundaData).TotalDays;
 }

 public static string MontarDataDeAcordoComFormato(this string strData)
 {
     DateTime dataTratada;
     string dataFormatada = String.Empty;

     if (
             DateTime.TryParseExact(strData, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "yyyy/MM/d", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "yyyy/M/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "yyyy/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "MM/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "M/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "MMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada) ||
             DateTime.TryParseExact(strData, "yyyy/MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataTratada)
         )
     {
         dataFormatada = dataTratada.ConverterParaTextoFormatoDataPtBr();
     }

     return dataFormatada;
 }

 public static DateTime SubtrairDiasUteis(this DateTime data, long quantidadeDias)
 {
     return AdicionarDiasUteis(data, -quantidadeDias);
 }

 public static DateTime AdicionarDiasUteis(this DateTime data, long quantidadeDias)
 {
     int sign = Math.Sign(quantidadeDias);
     long unsignedDays = Math.Abs(quantidadeDias);

     for (int i = 0; i < unsignedDays; i++)
     {
         do
         {
             data = data.AddDays(sign);
         }
         while (data.DayOfWeek.Equals(DayOfWeek.Saturday) || data.DayOfWeek.Equals(DayOfWeek.Sunday));
     }

     return data;
 }

 public static string ObterMesPorExtenso(this int mes)
 {
     string mesPorExtenso = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes).ToLower();

     return Char.ToUpper(mesPorExtenso[0]) + mesPorExtenso.Substring(1);
 }

 public static string AppendTimeStamp(this string fileName)
 {
     return string.Concat(
         Path.GetFileNameWithoutExtension(fileName),
         "_",
         DateTime.Now.ToString("yyyyMMddHHmmssfff"),
         Path.GetExtension(fileName)
         );
 }

 /// <summary>
 /// Remove TimeStamp de 17 caracteres de uma string
 /// </summary>
 /// <param name="value"></param>
 /// <returns></returns>
 public static string RemoverTimeStamp(this string value)
 {
     try
     {
         if (PossuiCaracteresEspeciais(value))
         {
             value = RemoverCaracteresEspeciaisAnexo(value);
         }

         string timeStamp = value.Length >= 17 ? value.Substring(value.LastIndexOf('.') - 17, 17) : value;

         DateTime valueTimeStamp;
         //if (DateTime.TryParse(timeStamp, out valueTimeStamp))
         if (DateTime.TryParseExact(timeStamp, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture, DateTimeStyles.None, out valueTimeStamp))
         {
             return value.Replace("_" + timeStamp, "");
         }

         return value;
     }
     catch (Exception)
     {
         return value;
     }
 }

  /// <summary>
 /// Método responsável por remover os caracteres especiais de uma string.
 /// Exemplos de caracteres especiais: ",", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "(", ")", "|", "[", "]", "-", "~", "¸"
 /// </summary>
 /// <param name="valor"></param>
 /// <returns></returns>
 public static string RemoverCaracteresEspeciaisAnexo(this string valor)
 {
     string[] caracteresEspeciais = new string[] { ",", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "(", ")", "|", "[", "]", "-", "~", "¸" };
     string valorFormatado = string.Empty;

     foreach (char letter in valor)
     {
         if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
             valorFormatado += letter;
     }

     for (int i = 0; i < caracteresEspeciais.Length; i++)
     {
         if (valor.Contains(caracteresEspeciais[i]))
             valorFormatado = valorFormatado.Replace(caracteresEspeciais[i], String.Empty);
     }

     return valorFormatado;
 }

 /// <summary>
 /// Método responsável por validar se existem caracteres especiais em uma determinada string.
 /// Exemplos de caracteres especiais: ",", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "(", ")", "|", "[", "]", "-", "~", "¸"
 /// </summary>
 /// <param name="valor"></param>
 /// <returns></returns>
 public static bool PossuiCaracteresEspeciais(this string valor)
 {
     bool possuiCaracterEspecial = false;
     string[] caracteresEspeciais = new string[] { ",", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "(", ")", "|", "[", "]", "-", "~", "¸" };

     for (int i = 0; i < caracteresEspeciais.Length; i++)
     {
         if (valor.Contains(caracteresEspeciais[i]))
         {
             possuiCaracterEspecial = true;
             break;
         }
     }
     return possuiCaracterEspecial;
 }

}
