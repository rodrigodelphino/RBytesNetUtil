using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBytesNetUtil
{
    internal static class ExcelAux
    {
        internal static void GerarConteudo(ref int linhaAtual, IXLWorksheet worksheet, List<List<(string, string, string, string, string, string)>> conteudo,
                                  bool grid, bool corSimCorNao, string corFundo1, string corFundo2)
        {
            // Iterando sobre a lista genérica
            foreach (var linhaConteudo in conteudo)
            {
                int colunaAtual = 1;
                double tamanhoFonte = 10;
                string nomeFonte = "Arial";
                XLColor corFonte = XLColor.Black;
                XLColor corFundo = XLColor.NoColor;
                XLAlignmentHorizontalValues alinhamentoColuna = XLAlignmentHorizontalValues.Left;
                bool isRegular = true;
                bool isItalic = false;
                bool isBold = false;
                bool isUnderline = false;

                // Iterando sobre os elementos de cada linha
                foreach (var colunaConteudo in linhaConteudo)
                {
                    FormatarLinha(ref tamanhoFonte,
                                  ref corFonte,
                                  ref corFundo,
                                  ref alinhamentoColuna,
                                  ref isRegular,
                                  ref isItalic,
                                  ref isBold,
                                  ref isUnderline,
                                  colunaConteudo);

                    worksheet.Cell(linhaAtual, colunaAtual).Value = colunaConteudo.Item1; // salva o valor na coluna
                    worksheet.Cell(linhaAtual, colunaAtual).Style.Font.FontSize = tamanhoFonte;
                    worksheet.Cell(linhaAtual, colunaAtual).Style.Font.FontName = nomeFonte;
                    worksheet.Cell(linhaAtual, colunaAtual).Style.Font.FontColor = corFonte;
                    worksheet.Cell(linhaAtual, colunaAtual).Style.Font.Bold = isBold;
                    worksheet.Cell(linhaAtual, colunaAtual).Style.Font.Italic = isItalic;
                    worksheet.Cell(linhaAtual, colunaAtual).Style.Font.Strikethrough = isUnderline;
                    worksheet.Cell(linhaAtual, colunaAtual).Style.Fill.BackgroundColor = corFundo;
                    worksheet.Cell(linhaAtual, colunaAtual).Style.Alignment.SetHorizontal(alinhamentoColuna);

                    if (grid)
                    {
                        XLColor corBorda = RetornaCor(corFundo1);
                        worksheet.Cell(linhaAtual, colunaAtual).Style.Border.TopBorderColor = corBorda;
                        worksheet.Cell(linhaAtual, colunaAtual).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(linhaAtual, colunaAtual).Style.Border.BottomBorderColor = corBorda;
                        worksheet.Cell(linhaAtual, colunaAtual).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(linhaAtual, colunaAtual).Style.Border.RightBorderColor = corBorda;
                        worksheet.Cell(linhaAtual, colunaAtual).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(linhaAtual, colunaAtual).Style.Border.LeftBorderColor = corBorda;
                        worksheet.Cell(linhaAtual, colunaAtual).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    }

                    if (corSimCorNao)
                    {
                        if (linhaAtual % 2 == 0)
                        {
                            worksheet.Cell(linhaAtual, colunaAtual).Style.Fill.BackgroundColor = RetornaCor(corFundo1);
                        }
                        else
                        {
                            worksheet.Cell(linhaAtual, colunaAtual).Style.Fill.BackgroundColor = RetornaCor(corFundo2);
                        }
                    }

                    worksheet.Column(colunaAtual).AdjustToContents(); //ajusta o tamanho da coluna
                    colunaAtual++;
                }
                linhaAtual++;
            }
        }

        private static void FormatarLinha(ref double tamanhoFonte, ref XLColor corFonte, ref XLColor corFundo, ref XLAlignmentHorizontalValues alinhamentoColuna, ref bool isRegular, ref bool isItalic, ref bool isBold, ref bool isUnderline, (string, string, string, string, string, string) coluna)
        {
            //tamanho da fonte
            if (!String.IsNullOrWhiteSpace(coluna.Item2))
            {
                Double colunaTamanhoFonte;
                if (Double.TryParse(coluna.Item2, out colunaTamanhoFonte))
                {
                    tamanhoFonte = colunaTamanhoFonte;
                }
            }

            // cor da fonte
            if (!String.IsNullOrWhiteSpace(coluna.Item3))
            {
                corFonte = RetornaCor(coluna.Item3);
            }

            //estilo da fonte
            if (!String.IsNullOrWhiteSpace(coluna.Item4))
            {
                FormatarEstiloFonte(ref isRegular,
                                    ref isItalic,
                                    ref isBold,
                                    ref isUnderline,
                                    coluna);
            }

            //cor de fundo
            if (!String.IsNullOrWhiteSpace(coluna.Item5))
            {
                corFundo = RetornaCor(coluna.Item5);
            }

            //cor do fundo
            if (!String.IsNullOrWhiteSpace(coluna.Item5))
            {
                corFundo = RetornaCor(coluna.Item5);
            }

            //Alinhamento
            if (!String.IsNullOrWhiteSpace(coluna.Item6))
            {
                alinhamentoColuna = RetornaAlinhamentoColuna(coluna.Item6);
            }
        }

        private static void FormatarEstiloFonte(ref bool isRegular, ref bool isItalic, ref bool isBold, ref bool isUnderline, (string, string, string, string, string, string) coluna)
        {
            switch (coluna.Item4.ToLower().Trim())
            {
                case "normal":
                case "regular":
                    isRegular = true;
                    isItalic = false;
                    isBold = false;
                    isUnderline = false;
                    break;

                case "negrito":
                case "bold":
                    isRegular = false;
                    isItalic = false;
                    isBold = true;
                    isUnderline = false;
                    break;

                case "italico":
                case "italic":
                    isRegular = false;
                    isItalic = true;
                    isBold = false;
                    isUnderline = false;
                    break;

                case "sublinhado":
                case "underline":
                    isRegular = false;
                    isItalic = false;
                    isBold = false;
                    isUnderline = true;
                    break;
            }
        }

        private static XLAlignmentHorizontalValues RetornaAlinhamentoColuna(string alinhamentoColuna)
        {

            switch (alinhamentoColuna.ToLower().Trim())
            {
                case "esquerda":
                case "left":
                    return XLAlignmentHorizontalValues.Left;

                case "direita":
                case "right":
                    return XLAlignmentHorizontalValues.Right;

                case "centro":
                case "center":
                    return XLAlignmentHorizontalValues.Center;
            }

            return XLAlignmentHorizontalValues.Left;
        }
        private static XLColor RetornaCor(string nomeCor)
        {
            XLColor corFundo = XLColor.NoColor;

            switch (nomeCor.ToLower().Trim())
            {
                case "preto":
                case "black":
                    corFundo = XLColor.Black;
                    break;

                case "branco":
                case "white":
                    corFundo = XLColor.White;
                    break;

                case "vermelho":
                case "red":
                    corFundo = XLColor.Red;
                    break;

                case "azul":
                case "blue":
                    corFundo = XLColor.Blue;
                    break;

                case "azul-claro":
                case "lightblue":
                    corFundo = XLColor.LightBlue;
                    break;

                case "amarelo":
                case "yellow":
                    corFundo = XLColor.Yellow;
                    break;

                case "verde":
                case "green":
                    corFundo = XLColor.Green;
                    break;

                case "verde-claro":
                case "lightgreen":
                    corFundo = XLColor.LightGreen;
                    break;

                case "cinza":
                case "gray":
                    corFundo = XLColor.Gray;
                    break;

                case "cinza-claro":
                case "lightgray":
                    corFundo = XLColor.LightGray;
                    break;

                case "laranja":
                case "orange":
                    corFundo = XLColor.Orange;
                    break;

                default:
                    int colunaCorArgb;
                    if (int.TryParse(nomeCor.Trim(), out colunaCorArgb))
                    {
                        corFundo = XLColor.FromArgb(colunaCorArgb);
                    }
                    break;
            }

            return corFundo;
        }
    }
}
