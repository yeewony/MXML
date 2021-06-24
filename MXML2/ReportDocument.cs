using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;

namespace MXML2
{
    class ReportDocument
    {

        public static void GenerateReport(List<string> DataInfo, string StartTime)
        {

            string docFilename = "대국민 모바일 원격 보안점검_" + DataInfo[3] + "_" + StartTime + ".docx";


            byte[] docByte = Properties.Resources.ReportTemplate;
            using (FileStream docStream = File.Create(docFilename))
            {
                docStream.Write(docByte, 0, docByte.Length);
            }
            // 파일 옮기기

            using (WordprocessingDocument worddoc = WordprocessingDocument.Open(docFilename, true))
            {
                var DocumentBody = worddoc.MainDocumentPart.Document.Body;

                foreach (var Text in DocumentBody.Descendants<Text>())
                {
                    if (Text.Text.Contains("MO_START"))
                    {
                        Text.Text = Text.Text.Replace("MO_START", DataInfo[0]);
                    }
                    else if (Text.Text.Contains("MO_END"))
                    {
                        Text.Text = Text.Text.Replace("MO_END", DataInfo[1]);
                    }
                    else if (Text.Text.Contains("MO_OSVER"))
                    {
                        Text.Text = Text.Text.Replace("MO_OSVER", DataInfo[2]);
                    }
                    else if (Text.Text.Contains("MO_MODEL"))
                    {
                        Text.Text = Text.Text.Replace("MO_MODEL", DataInfo[3]);
                    }
                    else if (Text.Text.Contains("MO_MANU"))
                    {
                        Text.Text = Text.Text.Replace("MO_MANU", DataInfo[4]);
                    }
                    else if (Text.Text.Contains("MO_CARR"))
                    {
                        Text.Text = Text.Text.Replace("MO_CARR", DataInfo[5]);
                    }
                    // 점검 대상 끝
                }

                // 점검 결과 시작


                for (int i = 1; i <= 7; i++)
                {
                    Table table = worddoc.MainDocumentPart.Document.Body.Elements<Table>().Last();

                    TableRow row = table.Elements<TableRow>().ElementAt(i);

                    TableCell cell = row.Elements<TableCell>().ElementAt(2);

                    Paragraph p = cell.Elements<Paragraph>().First();

                    Run r = p.Elements<Run>().First();

                    Text t = r.Elements<Text>().First();
                    t.Text = DataInfo[i+5];
                }

                for (int i = 1; i <= 7; i++)
                {
                    Table table = worddoc.MainDocumentPart.Document.Body.Elements<Table>().Last();

                    TableRow row = table.Elements<TableRow>().ElementAt(i);

                    TableCell cell = row.Elements<TableCell>().ElementAt(3);

                    Paragraph p = cell.Elements<Paragraph>().First();

                    Run r = p.Elements<Run>().First();

                    Text t = r.Elements<Text>().First();
                    t.Text = DataInfo[i + 12];
                }

                worddoc.Save();
                worddoc.Close();
            }


        }

        public static void ReplaceBeforeCell(string DocxFilename, int Cell, string Data)
        {
            using (WordprocessingDocument worddoc = WordprocessingDocument.Open(DocxFilename, true))
            {
                Table table = worddoc.MainDocumentPart.Document.Body.Elements<Table>().Last();

                TableRow row = table.Elements<TableRow>().ElementAt(Cell);

                TableCell cell = row.Elements<TableCell>().ElementAt(2);

                Paragraph p = cell.Elements<Paragraph>().First();

                Run r = p.Elements<Run>().First();

                Text t = r.Elements<Text>().First();
                t.Text = Data;
            }            
        }

        public static void ReplaceAfterCell(string DocxFilename, int Cell, string Data)
        {
            using (WordprocessingDocument worddoc = WordprocessingDocument.Open(DocxFilename, true))
            {
                Table table = worddoc.MainDocumentPart.Document.Body.Elements<Table>().Last();

                TableRow row = table.Elements<TableRow>().ElementAt(Cell);

                TableCell cell = row.Elements<TableCell>().ElementAt(3);

                Paragraph p = cell.Elements<Paragraph>().First();

                Run r = p.Elements<Run>().First();

                Text t = r.Elements<Text>().First();
                t.Text = Data;
            }
        }
    }
}
