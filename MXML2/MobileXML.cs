using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Xml;
using System.IO;

namespace MXML2
{
    class MobileXML
    {

        public static void GenerateBeforeXML(List<string> InfoList)
        {
            try
            {
                string[] namelist = { "스마트폰 잠금 설정 여부", "구글 플레이 프로텍트 인증 상태",
                                      "최신 보안 업데이트 여부", "개발자 옵션 활성화 여부", "애플리케이션 권한 관리 점검",
                                      "백신 설치 여부", "백신 최신 업데이트 및 실시간 감시 여부" };

                XmlDocument Mxml = new XmlDocument();

                XmlDeclaration Mxmldecl;
                Mxmldecl = Mxml.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                Mxmldecl.Encoding = "UTF-8";
                Mxmldecl.Standalone = "yes";
                Mxml.InsertBefore(Mxmldecl, Mxml.DocumentElement);

                XmlNode root = Mxml.CreateElement("MOBILE-Check");
                Mxml.AppendChild(root);

                XmlNode START_TIME = Mxml.CreateElement("START_TIME");
                START_TIME.InnerText = InfoList[0];
                root.AppendChild(START_TIME);

                XmlNode END_TIME = Mxml.CreateElement("END_TIME");
                END_TIME.InnerText = InfoList[0];
                root.AppendChild(END_TIME);

                XmlNode ANDROID_VERSION = Mxml.CreateElement("ANDROID_VERSION");
                ANDROID_VERSION.InnerText = InfoList[2];
                root.AppendChild(ANDROID_VERSION);

                XmlNode MODEL_VERSION = Mxml.CreateElement("MODEL_VERSION");
                MODEL_VERSION.InnerText = InfoList[3];
                root.AppendChild(MODEL_VERSION);

                XmlNode MANUFACTURER = Mxml.CreateElement("MANUFACTURER");
                MANUFACTURER.InnerText = InfoList[4];
                root.AppendChild(MANUFACTURER);

                XmlNode CARRIER = Mxml.CreateElement("CARRIER");
                CARRIER.InnerText = InfoList[5];
                root.AppendChild(CARRIER);

                for (int i = 1; i <= 7; i++)
                {
                    string monum = "MO-0" + i;

                    XmlNode mo = Mxml.CreateElement(monum);
                    XmlNode NAME = Mxml.CreateElement("NAME"); NAME.InnerText = namelist[i-1]; mo.AppendChild(NAME);
                    XmlNode RESULT = Mxml.CreateElement("RESULT"); RESULT.InnerText = InfoList[i+5]; mo.AppendChild(RESULT);
                    root.AppendChild(mo);
                }

                string xmlfile = "MOBILE_" + InfoList[3] + "_Result_Before.xml";
                
                Mxml.Save(xmlfile);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        public static void GenerateAfterXML(List<string> InfoList)
        {
            try
            {
                string[] namelist = { "스마트폰 잠금 설정 여부", "구글 플레이 프로텍트 인증 상태",
                                      "최신 보안 업데이트 여부", "개발자 옵션 활성화 여부", "애플리케이션 권한 관리 점검",
                                      "백신 설치 여부", "백신 최신 업데이트 및 실시간 감시 여부" };

                XmlDocument Mxml = new XmlDocument();

                XmlDeclaration Mxmldecl;
                Mxmldecl = Mxml.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                Mxmldecl.Encoding = "UTF-8";
                Mxmldecl.Standalone = "yes";
                Mxml.InsertBefore(Mxmldecl, Mxml.DocumentElement);

                XmlNode root = Mxml.CreateElement("MOBILE-Check");
                Mxml.AppendChild(root);

                XmlNode START_TIME = Mxml.CreateElement("START_TIME");
                START_TIME.InnerText = InfoList[1];
                root.AppendChild(START_TIME);

                XmlNode END_TIME = Mxml.CreateElement("END_TIME");
                END_TIME.InnerText = InfoList[1];
                root.AppendChild(END_TIME);

                XmlNode ANDROID_VERSION = Mxml.CreateElement("ANDROID_VERSION");
                ANDROID_VERSION.InnerText = InfoList[2];
                root.AppendChild(ANDROID_VERSION);

                XmlNode MODEL_VERSION = Mxml.CreateElement("MODEL_VERSION");
                MODEL_VERSION.InnerText = InfoList[3];
                root.AppendChild(MODEL_VERSION);

                XmlNode MANUFACTURER = Mxml.CreateElement("MANUFACTURER");
                MANUFACTURER.InnerText = InfoList[4];
                root.AppendChild(MANUFACTURER);

                XmlNode CARRIER = Mxml.CreateElement("CARRIER");
                CARRIER.InnerText = InfoList[5];
                root.AppendChild(CARRIER);

                for (int i = 1; i <= 7; i++)
                {
                    string monum = "MO-0" + i;

                    XmlNode mo = Mxml.CreateElement(monum);
                    XmlNode NAME = Mxml.CreateElement("NAME"); NAME.InnerText = namelist[i - 1]; mo.AppendChild(NAME);
                    XmlNode RESULT = Mxml.CreateElement("RESULT"); RESULT.InnerText = InfoList[i + 5]; mo.AppendChild(RESULT);
                    root.AppendChild(mo);
                }

                string xmlfile = "MOBILE_" + InfoList[3] + "_Result_After.xml";


                Mxml.Save(xmlfile);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }


    }
}
