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

                    // 점검 결과 시작
                    if (Text.Text.Contains("MO01_R"))
                    {
                        Text.Text = Text.Text.Replace("MO01_R", DataInfo[6]);
                    }
                    else if (Text.Text.Contains("MO02_R"))
                    {
                        Text.Text = Text.Text.Replace("MO02_R", DataInfo[7]);
                    }
                    else if (Text.Text.Contains("MO03_R"))
                    {
                        Text.Text = Text.Text.Replace("MO03_R", DataInfo[8]);
                    }
                    else if (Text.Text.Contains("MO04_R"))
                    {
                        Text.Text = Text.Text.Replace("MO04_R", DataInfo[9]);
                    }
                    else if (Text.Text.Contains("MO05_R"))
                    {
                        Text.Text = Text.Text.Replace("MO05_R", DataInfo[10]);
                    }
                    else if (Text.Text.Contains("MO06_R"))
                    {
                        Text.Text = Text.Text.Replace("MO06_R", DataInfo[11]);
                    }
                    else if (Text.Text.Contains("MO07_R"))
                    {
                        Text.Text = Text.Text.Replace("MO07_R", DataInfo[12]);
                    }
                    else if (Text.Text.Contains("MO01_RR"))
                    {
                        Text.Text = Text.Text.Replace("MO01_RR", DataInfo[13]);
                    }
                    else if (Text.Text.Contains("MO02_RR"))
                    {
                        Text.Text = Text.Text.Replace("MO02_RR", DataInfo[14]);
                    }
                    else if (Text.Text.Contains("MO03_RR"))
                    {
                        Text.Text = Text.Text.Replace("MO03_RR", DataInfo[15]);
                    }
                    else if (Text.Text.Contains("MO04_RR"))
                    {
                        Text.Text = Text.Text.Replace("MO04_RR", DataInfo[16]);
                    }
                    else if (Text.Text.Contains("MO05_RR"))
                    {
                        Text.Text = Text.Text.Replace("MO05_RR", DataInfo[17]);
                    }
                    else if (Text.Text.Contains("MO06_RR"))
                    {
                        Text.Text = Text.Text.Replace("MO06_RR", DataInfo[18]);
                    }
                    else if (Text.Text.Contains("MO07_RR"))
                    {
                        Text.Text = Text.Text.Replace("MO07_RR", DataInfo[19]);
                    }

                }

                worddoc.Save();
                worddoc.Close();
            }


        }
    }
}
