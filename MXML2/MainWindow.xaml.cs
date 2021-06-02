using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MXML2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tgbtn_01_af.IsEnabled = false;
            tgbtn_02_af.IsEnabled = false;
            tgbtn_03_af.IsEnabled = false;
            tgbtn_04_af.IsEnabled = false;
            tgbtn_05_af.IsEnabled = false;
            tgbtn_06_af.IsEnabled = false;
            tgbtn_07_af.IsEnabled = false;

            tgbtn_01_bf.IsEnabled = false;
            tgbtn_02_bf.IsEnabled = false;
            tgbtn_03_bf.IsEnabled = false;
            tgbtn_04_bf.IsEnabled = false;
            tgbtn_05_bf.IsEnabled = false;
            tgbtn_06_bf.IsEnabled = false;
            tgbtn_07_bf.IsEnabled = false;

            if (File.Exists("PinkyMXML2.exe"))
            {
                MessageBox.Show("Cherry Blossom Activated");
                
            }
        }

        private void btn_Reset_ResetAll(object sender, RoutedEventArgs e)
        {
            ///모바일 점검 정보 리셋

            if (tb_StartTime.Text==string.Empty)
            {
                tb_InputClipData.Text = null;
            }

            tb_StartTime.Text = null;
            tb_EndTime.Text = null;
            tb_OSVer.Text = null;
            tb_ModelName.Text = null;
            tb_Manufacturer.Text = null;
            tb_Carrier.Text = null;

            ///토글 버튼 리셋
            tgbtn_01_bf.IsChecked = false;
            tgbtn_02_bf.IsChecked = false;
            tgbtn_03_bf.IsChecked = false;
            tgbtn_04_bf.IsChecked = false;
            tgbtn_05_bf.IsChecked = false;
            tgbtn_06_bf.IsChecked = false;
            tgbtn_07_bf.IsChecked = false;

            btn_START.IsEnabled = true;
            btn_END.IsEnabled = false;
            btn_GeneXML.IsEnabled = false;
        }

        private void btn_START_Inspection(object sender, RoutedEventArgs e)
        {
            try
            {
                string clipdata = tb_InputClipData.Text;
                List<string> DataList = new List<string>(clipdata.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

                tb_OSVer.Text = DataList.Where(x => x.StartsWith("안드로이드 버전")).Select(x => x.Replace("안드로이드 버전", string.Empty)).ToArray()[0].Trim();
                tb_ModelName.Text = DataList.Where(x => x.StartsWith("모델 번호")).Select(x => x.Replace("모델 번호", string.Empty)).ToArray()[0].Trim();
                tb_Manufacturer.Text = DataList.Where(x => x.StartsWith("제조사")).Select(x => x.Replace("제조사", string.Empty)).ToArray()[0].Trim();
                tb_Carrier.Text = DataList.Where(x => x.StartsWith("통신사")).Select(x => x.Replace("통신사", string.Empty)).ToArray()[0].Trim();

                tb_StartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                MessageBox.Show("방해금지 모드를 설정하세요");

                tgbtn_01_af.IsEnabled = true;
                tgbtn_02_af.IsEnabled = true;
                tgbtn_03_af.IsEnabled = true;
                tgbtn_04_af.IsEnabled = true;
                tgbtn_05_af.IsEnabled = true;
                tgbtn_06_af.IsEnabled = true;
                tgbtn_07_af.IsEnabled = true;

                tgbtn_01_bf.IsEnabled = true;
                tgbtn_02_bf.IsEnabled = true;
                tgbtn_03_bf.IsEnabled = true;
                tgbtn_04_bf.IsEnabled = true;
                tgbtn_05_bf.IsEnabled = true;
                tgbtn_06_bf.IsEnabled = true;
                tgbtn_07_bf.IsEnabled = true;

                btn_END.IsEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("점검 기기의 정보가 없거나 잘못된 정보입니다");
            }
            

        }

        private void btn_END_Inspection(object sender, RoutedEventArgs e)
        {
            try
            {
                tb_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                MessageBox.Show("방해금지 모드를 해제하세요");

                btn_GeneXML.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_GeneXML_Execution(object sender, RoutedEventArgs e)
        {
            try
            {

                List<string> BeforeList = new List<string>();
                List<string> AfterList = new List<string>();

                BeforeList.Add(tb_StartTime.Text);
                BeforeList.Add(tb_EndTime.Text);
                BeforeList.Add(tb_OSVer.Text);
                BeforeList.Add(tb_ModelName.Text);
                BeforeList.Add(tb_Manufacturer.Text);
                BeforeList.Add(tb_Carrier.Text);

                AfterList.Add(tb_StartTime.Text);
                AfterList.Add(tb_EndTime.Text);
                AfterList.Add(tb_OSVer.Text);
                AfterList.Add(tb_ModelName.Text);
                AfterList.Add(tb_Manufacturer.Text);
                AfterList.Add(tb_Carrier.Text);

                foreach (var tgbtn in new bool[] { (bool)tgbtn_01_bf.IsChecked, (bool)tgbtn_02_bf.IsChecked, (bool)tgbtn_03_bf.IsChecked, (bool)tgbtn_04_bf.IsChecked,
                                                    (bool)tgbtn_05_bf.IsChecked,(bool)tgbtn_06_bf.IsChecked,(bool)tgbtn_07_bf.IsChecked})
                {
                    string togle;
                    if (tgbtn==true)
                    {
                        togle = "Y";
                    }
                    else
                    {
                        togle = "N";
                    }

                    BeforeList.Add(togle);
                }

                foreach (var tgbtn in new bool[] { (bool)tgbtn_01_af.IsChecked, (bool)tgbtn_02_af.IsChecked, (bool)tgbtn_03_af.IsChecked, (bool)tgbtn_04_af.IsChecked,
                                                    (bool)tgbtn_05_af.IsChecked,(bool)tgbtn_06_af.IsChecked,(bool)tgbtn_07_af.IsChecked})
                {
                    string togle;
                    if (tgbtn == true)
                    {
                        togle = "Y";
                    }
                    else
                    {
                        togle = "N";
                    }

                    AfterList.Add(togle);
                }

                MobileXML.GenerateBeforeXML(BeforeList);
                MobileXML.GenerateAfterXML(AfterList);

                MessageBox.Show("XML 생성 완료");

                //string[] xmlfiles = Directory.GetFiles(Environment.CurrentDirectory, "*.xml");
                //string ZipPath = "점검결과_" + DateTime.Now.ToString("yyMMddHHmm") + ".zip";

                //using (ZipArchive zip = ZipFile.Open(ZipPath, ZipArchiveMode.Create))
                //{
                //    List<string> files = new List<string>();
                //    files.Add(xmlfiles[0]);
                //    files.Add(xmlfiles[1]);

                //    foreach (var file in files)
                //    {
                //        zip.CreateEntryFromFile(file, System.IO.Path.GetFileName(file));
                //    }
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
