using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Compression;
using System.IO;
using System.Xml;
using System.Resources;

namespace xmlgenerator
{
    class LogExtractor
    {

        /// <summary>
        /// log.zip 파일을 읽어서 화면에 뿌리기, 다시 xml 파일과 Virus_Result.txt 파일을 만들어서
        /// 압축시켜서 내보낸다.
        /// 
        /// 1. 압축을 푼다.
        /// 2. 각 폴더의 txt 파일을 전부 읽어서 하나로 합친다.
        /// 3. 각각의 xml 파일로 내보낸다.
        /// 4. Virus log를 읽어서 필요없는 부분을 쳐낸다.
        /// 5. txt 파일을 만들어서 내보낸다.
        /// 6. 세 파일을 압축시켜서 파일을 만든다.
        /// 
        /// </summary>
        /// 
        
        public static void LogToXML(string ZipPath)
        {
            //0. 디렉토리 세팅
            string tmpdir = System.Environment.CurrentDirectory + "\\temp";
            string tmpafdir = tmpdir + "\\after_result";
            string tmpbfdir = tmpdir + "\\before_result";

            //1. tmp에 압축을 푼다.
            ExpandArchive(ZipPath, tmpdir);

            //2.각 폴더의 txt 파일을 전부 읽어서 하나로 합친다.
            MergeTextfile(tmpbfdir, "bf");
            MergeTextfile(tmpafdir, "af");

            //3.텍스트파일을 XML 파일로 변환한다.
            TxtfiletoXML();

            //4.이름 변경을 위한 hostname 뽑아내서 이름 변경하기
            NameChange();

            //5.virus log 분석해서 virus result로 뽑아내기
            ViruslogToResult();

            //6. 3개를 하나로 묶기, 리포트 생성?

        }


        //압축풀기
        private static bool ExpandArchive(string ZipPath, string DestinationPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(ZipPath, DestinationPath);

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return false;
            }

        }

        //합치기
        private static void MergeTextfile(string LogtxtfilePath, string isAB)
        {
            string txtFilePath;

            if (isAB != "af")
            {
                txtFilePath = System.Environment.CurrentDirectory + "\\Result_Before.txt";
            }
            else
            {
                txtFilePath = System.Environment.CurrentDirectory + "\\Result_After.txt";
            }

            try
            {
                using (var output = File.Create(txtFilePath))
                {
                    foreach (var file in new[] { "info.txt", "PC-01.txt", "PC-02.txt", "PC-03.txt", "PC-04.txt",
                        "PC-05.txt","PC-06.txt","PC-07.txt","PC-08.txt","PC-09.txt","PC-10.txt","PC-11.txt",
                    "PC-12.txt","PC-13.txt","PC-14.txt","PC-15.txt","PC-16.txt","PC-17.txt","info2.txt",})
                    {
                        string txtfiles = LogtxtfilePath + "\\" + file;

                        using (var input = File.OpenRead(txtfiles))
                        {
                            input.CopyTo(output);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        //인코딩 후 XML 파일 변환
        private static void TxtfiletoXML()
        {
            string pwd = Environment.CurrentDirectory;

            if (File.Exists(pwd+"\\Result_before.txt"))
            {
                if (File.Exists(pwd + "\\Result_After.txt"))
                {
                    File.WriteAllText(pwd + "\\Result_Before.xml",File.ReadAllText(pwd + "\\Result_Before.txt",Encoding.Default), new UTF8Encoding(false));
                    File.WriteAllText(pwd + "\\Result_After.xml",File.ReadAllText(pwd + "\\Result_After.txt", Encoding.Default), new UTF8Encoding(false));
                }
            }
            else
            {
                System.Windows.MessageBox.Show("XML로 변환 할 텍스트 파일을 찾지 못하였습니다.");
            }
        }

        private static void NameChange()
        {
            try
            {
                string xmlfile = Environment.CurrentDirectory + "\\Result_before.xml";
                string hostname = null;

                XmlDocument xdc = new XmlDocument();
                xdc.Load(xmlfile);

                XmlNodeList xmlNodes = xdc.SelectNodes("PC-Check");

                foreach (XmlNode nodes in xmlNodes)
                {
                    XmlElement element = (XmlElement)nodes;

                    hostname = Convert.ToString(nodes["HOSTNAME"].InnerText);
                }

                try
                {
                    if (File.Exists(Environment.CurrentDirectory + "\\Result_Before.xml"))
                    {
                        if (File.Exists(Environment.CurrentDirectory + "\\Result_After.xml"))
                        {
                            File.Move(Environment.CurrentDirectory + "\\Result_Before.xml", Environment.CurrentDirectory + "\\" + hostname + "_Result_Before.xml");
                            File.Move(Environment.CurrentDirectory + "\\Result_After.xml", Environment.CurrentDirectory + "\\" + hostname + "_Result_After.xml");
                        }

                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private static void ViruslogToResult()
        {
            //각 라인 끝에 특수한 문자를 붙이고 서브스트링을 통해 해당 문자열 앞 라인 하나와 뒷라인 하나를 걸러낸다.
            string logpath = Environment.CurrentDirectory + "\\temp\\Virus_Log.txt";
            string resultpath = Environment.CurrentDirectory + "\\Virus_Result.txt";

            ResourceManager RM = new ResourceManager("items", System.Reflection.Assembly.GetExecutingAssembly());

            var AlllogLines = File.ReadAllLines(logpath).Count();
            var dellines = AlllogLines - 13;


            List<string> linesList = File.ReadAllLines(logpath).ToList();

            linesList.RemoveRange(0, dellines);

            File.WriteAllLines(resultpath, linesList.ToArray());

            File.AppendAllText(resultpath, RM.GetString("VirusResultsTail"));
        }
    }
}
