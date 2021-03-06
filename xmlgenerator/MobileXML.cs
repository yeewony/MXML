﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.IO;

namespace xmlgenerator
{

    class MobileXML
    {

        public static void Generate(string StartTime, string AndroidVersion, string ModelName, string Manufacturer, string Carrier)
        {
            try
            {
                XmlDocument Mxml = new XmlDocument();

                XmlDeclaration Mxmldecl;
                Mxmldecl = Mxml.CreateXmlDeclaration("1.0", "UTF8", null);
                Mxmldecl.Encoding = "UTF-8";
                Mxmldecl.Standalone = "yes";

                XmlNode root = Mxml.CreateElement("MOBILE-Check");
                Mxml.AppendChild(root);

                XmlNode START_TIME = Mxml.CreateElement("START_TIME");
                START_TIME.InnerText = StartTime;
                root.AppendChild(START_TIME);

                XmlNode END_TIME = Mxml.CreateElement("END_TIME");
                END_TIME.InnerText = "";
                root.AppendChild(END_TIME);

                XmlNode ANDROID_VERSION = Mxml.CreateElement("ANDROID_VERSION");
                ANDROID_VERSION.InnerText = AndroidVersion;
                root.AppendChild(ANDROID_VERSION);

                XmlNode MODEL_VERSION = Mxml.CreateElement("MODEL_VERSION");
                MODEL_VERSION.InnerText = ModelName;
                root.AppendChild(MODEL_VERSION);

                XmlNode MANUFACTURER = Mxml.CreateElement("MANUFACTURER");
                MANUFACTURER.InnerText = Manufacturer;
                root.AppendChild(MANUFACTURER);

                XmlNode CARRIER = Mxml.CreateElement("CARRIER");
                CARRIER.InnerText = Carrier;
                root.AppendChild(CARRIER);

                for(int i = 1; i <= 7; i++)
                {
                    string monum = "MO-0" + i;

                    XmlNode mo = Mxml.CreateElement(monum);
                    XmlNode NAME = Mxml.CreateElement("NAME"); NAME.InnerText = ""; mo.AppendChild(NAME);
                    XmlNode RESULT = Mxml.CreateElement("RESULT"); RESULT.InnerText = ""; mo.AppendChild(RESULT);
                    root.AppendChild(mo);
                }

                string bfxmlfile = Environment.CurrentDirectory + "MOBILE_" + ModelName + "_Result_Before.xml";
                string afxmlfile = Environment.CurrentDirectory + "MOBILE_" + ModelName + "_Result_After.xml";

                if (File.Exists(bfxmlfile))
                {
                    if (File.Exists(afxmlfile))
                    {
                        File.Delete(afxmlfile);
                    }
                    File.Delete(bfxmlfile);
                }

                Mxml.Save(bfxmlfile);
                Mxml.Save(afxmlfile);

            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("XML 파일 생성 실패 {0}", ex.ToString()));
            }
        }

        
    }

}
