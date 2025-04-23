using System.IO;
using System.IO.Compression;
using System.Text;

namespace RBytesNetUtil;

/// <summary>
/// Funções utilitárias para criação de arquivos Excel no formato XLSX sem dependências externas.
/// </summary>
public static class RBytesExcelUtil
{

public static void CriarExcelXLSX(string caminho, string nomePlanilha, List<List<string>> dados)
{
    using var stream = new MemoryStream();
    using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
    {
        // [Content_Types].xml
        var contentTypesEntry = archive.CreateEntry("[Content_Types].xml");
        using (var entryStream = contentTypesEntry.Open())
        {
            var contentTypesXml = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Types xmlns=""http://schemas.openxmlformats.org/package/2006/content-types"">
    <Override PartName=""/xl/worksheets/sheet1.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml""/>
    <Override PartName=""/xl/workbook.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml""/>
    <Override PartName=""/xl/_rels/workbook.xml.rels"" ContentType=""application/vnd.openxmlformats-package.relationships+xml""/>
    <Override PartName=""/_rels/.rels"" ContentType=""application/vnd.openxmlformats-package.relationships+xml""/>
</Types>";
            entryStream.Write(Encoding.UTF8.GetBytes(contentTypesXml));
        }

        // _rels/.rels
        var relsEntry = archive.CreateEntry("_rels/.rels");
        using (var entryStream = relsEntry.Open())
        {
            var relsXml = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
  <Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"" Target=""xl/workbook.xml""/>
</Relationships>";
            entryStream.Write(Encoding.UTF8.GetBytes(relsXml));
        }

        // xl/workbook.xml
        string workbookXml = $@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<workbook xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"" xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships"">
  <sheets>
    <sheet name=""{nomePlanilha}"" sheetId=""1"" r:id=""rId1""/>
  </sheets>
</workbook>";
        var workbookEntry = archive.CreateEntry("xl/workbook.xml");
        using (var entryStream = workbookEntry.Open())
        {
            entryStream.Write(Encoding.UTF8.GetBytes(workbookXml));
        }

        // xl/_rels/workbook.xml.rels
        var workbookRelsEntry = archive.CreateEntry("xl/_rels/workbook.xml.rels");
        using (var entryStream = workbookRelsEntry.Open())
        {
            var workbookRelsXml = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
  <Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"" Target=""worksheets/sheet1.xml""/>
</Relationships>";
            entryStream.Write(Encoding.UTF8.GetBytes(workbookRelsXml));
        }

        // xl/worksheets/sheet1.xml
        var sb = new StringBuilder();
        sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
        sb.Append("<worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\">");
        sb.Append("<sheetData>");
        foreach (var row in dados)
        {
            sb.Append("<row>");
            foreach (var cell in row)
            {
                sb.Append($"<c t=\"inlineStr\"><is><t>{System.Security.SecurityElement.Escape(cell)}</t></is></c>");
            }
            sb.Append("</row>");
        }
        sb.Append("</sheetData></worksheet>");

        var sheetEntry = archive.CreateEntry("xl/worksheets/sheet1.xml");
        using (var entryStream = sheetEntry.Open())
        {
            entryStream.Write(Encoding.UTF8.GetBytes(sb.ToString()));
        }

        // xl/styles.xml (arquivo vazio, mas necessário)
        var stylesEntry = archive.CreateEntry("xl/styles.xml");
        using (var entryStream = stylesEntry.Open())
        {
            entryStream.Write(Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<styles xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main""/>
"));
        }

        // Finaliza o fluxo de memória
        archive.Dispose();
    }

    // Salva o arquivo gerado
    using var file = File.Create(caminho);
    stream.Seek(0, SeekOrigin.Begin);
    stream.CopyTo(file);
}

    private static void Write(this Stream stream, byte[] data) => stream.Write(data, 0, data.Length);
}
