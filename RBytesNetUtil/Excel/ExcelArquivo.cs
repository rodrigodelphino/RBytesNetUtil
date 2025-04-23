using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBytesNetUtil
{
    internal static class ExcelArquivo
    {
        internal static XLWorkbook CriarPlanilhaExcelRetornaBuffer(string tab,
                                        List<List<(string, string, string, string, string, string)>> conteudo,
                                        bool exibirBordas, bool corSimCorNao, string corFundo1, string corFundo2)
        {
            using (var workbook = new XLWorkbook())
            {
                var planilha = workbook.Worksheets.Add(tab);
                int linha    = 1;

                if (conteudo.Count != 0)
                    ExcelAux.GerarConteudo(ref linha, planilha, conteudo, exibirBordas, corSimCorNao, corFundo1, corFundo2);

                return workbook;
            }
        }

        internal static string CriarPlanilhaExcel(string arquivo, string tab,
                                        List<List<(string, string, string, string, string, string)>> conteudo,
                                        bool exibirBordas, bool corSimCorNao, string corFundo1, string corFundo2)
        {
            if (File.Exists(arquivo))
                File.Delete(arquivo);            

            using (var workbook = new XLWorkbook())
            {

                var planilha    = workbook.Worksheets.Add(tab);
                int linha       = 1;

                if (conteudo.Count != 0)
                    ExcelAux.GerarConteudo(ref linha, planilha, conteudo, exibirBordas, corSimCorNao, corFundo1, corFundo2);

                workbook.SaveAs(arquivo);
            }

            return "";
        }

        internal static string GerarNovaAbaPlanilha(string arquivo, string nomeNovaTab,
                                         List<List<(string, string, string, string, string, string)>> conteudo,
                                         bool exibirBordas, bool corSimCorNao, string corFundo1, string corFundo2)
        {
            if (!File.Exists(arquivo))
                return "Arquivo não existe!";

            using (var workbook = new XLWorkbook(arquivo))
            {
                var planilha = workbook.Worksheets.Add(nomeNovaTab);
                int linha    = 1;

                if (conteudo.Count != 0)
                    ExcelAux.GerarConteudo(ref linha, planilha, conteudo, exibirBordas, corSimCorNao, corFundo1, corFundo2);

                workbook.Save();
            }

            return "";
        }
    }
}
