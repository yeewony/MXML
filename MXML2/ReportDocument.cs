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

namespace MXML2
{
    class ReportDocument
    {

        public static void GenerateReport(string starttime, string model)
        {

            DateTime Ax = DateTime.ParseExact(starttime, "yyyy-MM-dd HH:mm:ss", null);

            string a = Ax.ToString("yyMMddHHmm");
            string b = model;

            string docFilename = "대국민 모바일 원격 보안점검_" + b + "_" + a + ".docx";


            byte[] docByte = Properties.Resources.ReportTemplate;
            using (FileStream docStream = File.Create(docFilename))
            {
                docStream.Write(docByte, 0, docByte.Length);
            }
            // 파일 옮기기

            using (WordprocessingDocument worddoc = WordprocessingDocument.Open(docFilename,true))
            {
                var DocumentBody = worddoc.MainDocumentPart.Document.Body;

                foreach (var Text in DocumentBody.Descendants<Text>())
                {
                    if (Text.Text.Contains("MO_START"))
                    {
                        Text.Text = Text.Text.Replace("MO_START", starttime);
                    }
                    else if (Text.Text.Contains("MO_END"))
                    {
                        Text.Text = Text.Text.Replace("MO_END", b);
                    }
                }

                worddoc.Save();
                worddoc.Close();
            }


        }
    }
}
