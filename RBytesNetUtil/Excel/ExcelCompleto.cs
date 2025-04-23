using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using SixLabors.Fonts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;


namespace RBytesNetUtil
{
    public static class RBytesExcelXLSX
    {
        public static string GerarExcel(string arquivo, string tab, 
                                        List<List<(string,string,string,string,string, string)>> conteudo)
        {
              return GerarExcel(arquivo,tab,conteudo,false,false,"","");
        }

        public static string GerarExcel(string arquivo, string tab,
                                       List<List<(string, string, string, string, string, string)>> conteudo,
                                       bool grid)
        {
            return GerarExcel(arquivo, tab, conteudo, grid, false, "", "");
        }

        public static string GerarExcel(string arquivo, string tab,
                                       List<List<(string, string, string, string, string, string)>> conteudo,
                                       bool grid, bool corSimCorNao)
        {
            return GerarExcel(arquivo, tab, conteudo, grid, corSimCorNao, "", "");
        }

        public static string GerarExcel(string arquivo, string tab, List<List<string>> conteudoSimples)
        {
            List<List<(string, string, string, string, string, string)>> conteudo = new();
            List<(string, string, string, string, string, string)> coluna = new();

            foreach (var linha in conteudoSimples)
            {
                coluna = new();

                foreach (var colunaAtual in linha)
                  {
                    coluna.Add((colunaAtual, "", "", "", "",""));
                  }

                conteudo.Add(coluna);
            }

            return GerarExcel(arquivo, tab, conteudo, false, false, "", "");
        }

        public static XLWorkbook GerarExcelBuffer(string tab,
                                        List<List<(string, string, string, string, string, string)>> conteudo,
                                        bool exibirBordas, bool corSimCorNao, string corFundo1, string corFundo2)
        {
            return ExcelArquivo.CriarPlanilhaExcelRetornaBuffer(tab, conteudo, exibirBordas, corSimCorNao, corFundo1, corFundo2);
        }

        public static string GerarExcel(string arquivo, string tab,
                                        List<List<(string, string, string, string, string, string)>> conteudo,
                                        bool exibirBordas, bool corSimCorNao, string corFundo1, string corFundo2)
        {
            return ExcelArquivo.CriarPlanilhaExcel(arquivo, tab, conteudo, exibirBordas, corSimCorNao, corFundo1, corFundo2);
        }

        public static string GerarNovaAba(string arquivo, string nomeNovaTab,
                                         List<List<(string, string, string, string, string, string)>> conteudo)
        {
            return GerarNovaAba(arquivo, nomeNovaTab, conteudo, false, false, "", "");
        }

        public static string GerarNovaAba(string arquivo, string nomeNovaTab,
                                   List<List<(string, string, string, string, string, string)>> conteudo,
                                   bool exibirBordas)
        {
            return GerarNovaAba(arquivo, nomeNovaTab, conteudo, exibirBordas, false, "", "");
        }

        public static string GerarNovaAba(string arquivo, string nomeNovaTab,
                                         List<List<(string, string, string, string, string, string)>> conteudo,
                                         bool exibirBordas, bool corSimCorNao)
        {
            return GerarNovaAba(arquivo, nomeNovaTab, conteudo, exibirBordas, corSimCorNao, "", "");
        }

        public static string GerarNovaAba(string arquivo, string nomeNovaTab,
                                         List<List<(string, string, string, string, string, string)>> conteudo,
                                         bool exibirBordas, bool corSimCorNao, string corFundo1, string corFundo2)
        {
           return ExcelArquivo.GerarNovaAbaPlanilha(arquivo,nomeNovaTab,conteudo,exibirBordas,corSimCorNao, corFundo1, corFundo2);
        }
    }
}