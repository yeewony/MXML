using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///아래 참조 영역에 추가
using System.Configuration;

namespace xmlgenerator
{
    class Appconfig
    {
        ///Summary///
        ///Config.ini 파일을 만들고 해당 컨픽을 불러온다.///
        ///프로젝트 참조에 System.Configuration DLL을 추가하고 클래스에 System.Configuration 참조를 추가한다.
        ///레퍼런스에 System.Configuration 추가
        ///
        
        //추가하기 SetConfig("key" , "value");
        public static void SetConfig(string key, string val)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection configCollection = config.AppSettings.Settings;

            configCollection.Add(key, val);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

        }

        //가져오기 string cfg = GetConfig("key");
        public static string GetConfig(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection configcollection = config.AppSettings.Settings;

            string val = "";
            try
            {
                val = configcollection[key].Value;
            }
            catch { }

            return val;
        }

        //삭제하기 DelConfig("KEY");
        public static void DelConfig(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection configcollection = config.AppSettings.Settings;

            try
            {
                configcollection.Remove(key);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            catch { }
        }

    }
}
