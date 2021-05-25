using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.Xml;


namespace xmlgenerator
{
    class LogToXML
    {



        public static void Extraction(string ZipPath)
        {


            string dir = Environment.CurrentDirectory;

            try
            {
                ///tmp 에 압축해제
                ZipFile.ExtractToDirectory(ZipPath, dir+"\\tmp");

                ///텍스트 파일 합치기
                MergeTextFiles("before");
                MergeTextFiles("after");

                ///텍스트 파일을 XML 파일로 변환하기
                if (File.Exists(dir+"\\Result_before.txt"))
                {
                    if (File.Exists(dir+"\\Result_After.txt"))
                    {
                        File.WriteAllText(dir + "\\Result_Before.xml", File.ReadAllText(dir + "\\Result_Before.txt", Encoding.Default), new UTF8Encoding(false));
                        File.WriteAllText(dir + "\\Result_After.xml", File.ReadAllText(dir + "\\Result_After.txt", Encoding.Default), new UTF8Encoding(false));
                    }

                }

                ///바이러스 로그 변환하기
                

                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        public static void MergeTextFiles(string xmlfilename)
        {
            string mergedtxtfile, txtfilepath;

            if (ab != "after")
            {
                mergedtxtfile = Environment.CurrentDirectory + "\\Result_Before.txt";
                txtfilepath = Environment.CurrentDirectory + "\\tmp\\before_result";
            }
            else
            {
                mergedtxtfile = Environment.CurrentDirectory +  "\\Result_After.txt";
                txtfilepath = Environment.CurrentDirectory + "\\tmp\\after_result";
            }

            try
            {
                using (var output = File.Create(mergedtxtfile))
                {
                    foreach (var file in new[] { "info.txt", "PC-01.txt", "PC-02.txt", "PC-03.txt", "PC-04.txt",
                        "PC-05.txt","PC-06.txt","PC-07.txt","PC-08.txt","PC-09.txt","PC-10.txt","PC-11.txt",
                    "PC-12.txt","PC-13.txt","PC-14.txt","PC-15.txt","PC-16.txt","PC-17.txt","info2.txt",})
                    {
                        string txtfiles = txtfilepath + "\\" + file;

                        using (var input = File.OpenRead(txtfiles))
                        {
                            input.CopyTo(output);
                        }
                    }
                }

                if (ab!="after")
                {
                    if (File.Exists(mergedtxtfile))
                    {
                        File.WriteAllText(Environment.CurrentDirectory + "\\Result_Before.xml", File.ReadAllText(mergedtxtfile, Encoding.Default), new UTF8Encoding(false));
                    }
                }
                else
                {
                    if (File.Exists(mergedtxtfile))
                    {
                        File.WriteAllText(Environment.CurrentDirectory + "\\Result_After.xml", File.ReadAllText(mergedtxtfile, Encoding.Default), new UTF8Encoding(false));
                    }
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

    }
}
