using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
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
            if (File.Exists("Pinky MXML2.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Pink.xaml", UriKind.Relative);

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dic);
            }
            else if (File.Exists("Mintful MXML2.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Mint.xaml", UriKind.Relative);

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dic);
            }
            else if (File.Exists("MXML2 In Sky.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Sky.xaml", UriKind.Relative);

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dic);
            }
            else if (File.Exists("Pastel MXML2.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Pastel.xaml", UriKind.Relative);

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dic);
            }
            else if (File.Exists("MXML2 보라해.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Purple.xaml", UriKind.Relative);

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dic);
            }

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

            var assembly = Assembly.GetExecutingAssembly();
            var verinfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string filever = verinfo.FileVersion;

            var chkver = "\\\\10.1.8.4\\windata\\NEW_TEAM_1\\11231\\root\\mxml2\\version";


            if (File.Exists(chkver))
            {
                string serverver = File.ReadAllText(chkver);
                if (filever != serverver)
                {
                    PopupBox.Show("프로그램의 버전을 확인하세요\r\n" + "최신 버전은 " + serverver + "입니다.");
                }
            }

        }

        private void btn_Reset_ResetAll(object sender, RoutedEventArgs e)
        {
            if (btn_END.IsEnabled==true)
            {
                tgbtn_01_bf.IsChecked = false;
                tgbtn_02_bf.IsChecked = false;
                tgbtn_03_bf.IsChecked = false;
                tgbtn_04_bf.IsChecked = false;
                tgbtn_05_bf.IsChecked = false;
                tgbtn_06_bf.IsChecked = false;
                tgbtn_07_bf.IsChecked = false;
            }

            if (tb_StartTime.Text == string.Empty)
            {
                tb_InputClipData.Text = null;
            }

            tb_StartTime.Text = null;
            tb_EndTime.Text = null;
            tb_OSVer.Text = null;
            tb_ModelName.Text = null;
            tb_Manufacturer.Text = null;
            tb_Carrier.Text = null;

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

                ToastMessage_.Show("방해금지 모드를\r\n설정하세요");

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
                ToastMessage_.Show("점검 기기의 정보가 없거나\r\n잘못된 정보입니다");
            }
            

        }

        private void btn_END_Inspection(object sender, RoutedEventArgs e)
        {
            try
            {
                tb_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                ToastMessage_.Show("방해금지 모드를\r\n해제하세요");

                btn_START.IsEnabled = false;
                btn_END.IsEnabled = false;
                btn_GeneXML.IsEnabled = true;
            }
            catch (Exception ex)
            {
                PopupBox.Show(ex.ToString());
            }
        }

        private void btn_GeneXML_Execution(object sender, RoutedEventArgs e)
        {
            try
            {

                List<string> BeforeList = new List<string>();
                List<string> AfterList = new List<string>();
                List<string> ReportList = new List<string>();

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
                
                
                ReportList.Add(tb_StartTime.Text);
                ReportList.Add(tb_EndTime.Text);
                ReportList.Add(tb_OSVer.Text);
                ReportList.Add(tb_ModelName.Text);
                ReportList.Add(tb_Manufacturer.Text);
                ReportList.Add(tb_Carrier.Text);

                foreach (var tgbtn in new bool[] { (bool)tgbtn_01_bf.IsChecked, (bool)tgbtn_02_bf.IsChecked, (bool)tgbtn_03_bf.IsChecked, (bool)tgbtn_04_bf.IsChecked,
                                                    (bool)tgbtn_05_bf.IsChecked,(bool)tgbtn_06_bf.IsChecked,(bool)tgbtn_07_bf.IsChecked,(bool)tgbtn_01_af.IsChecked,
                                                    (bool)tgbtn_02_af.IsChecked, (bool)tgbtn_03_af.IsChecked, (bool)tgbtn_04_af.IsChecked,
                                                    (bool)tgbtn_05_af.IsChecked,(bool)tgbtn_06_af.IsChecked,(bool)tgbtn_07_af.IsChecked})
                {
                    string togle;
                    if (tgbtn == true)
                    {
                        togle = "양호";
                    }
                    else
                    {
                        togle = "취약";
                    }

                    ReportList.Add(togle);
                }


                string StartTime = DateTime.ParseExact(tb_StartTime.Text, "yyyy-MM-dd HH:mm:ss", null).ToString("yyMMddHHmm");

                ReportDocument.GenerateReport(ReportList, StartTime);


                string[] xmlfiles = Directory.GetFiles(Environment.CurrentDirectory, "MOBILE_*.xml");
                string ZipPath = "점검결과_" + StartTime + ".zip";

                using (ZipArchive zip = ZipFile.Open(ZipPath, ZipArchiveMode.Create))
                {
                    List<string> files = new List<string>();
                    files.Add(xmlfiles[0]);
                    files.Add(xmlfiles[1]);

                    foreach (var file in files)
                    {
                        zip.CreateEntryFromFile(file, System.IO.Path.GetFileName(file));
                    }
                }

                foreach (var xmlfile in xmlfiles)
                {
                    File.Delete(xmlfile);
                }

                string ResultFolder = "모바일 점검결과_" + StartTime;

                Directory.CreateDirectory(ResultFolder);

                string docxfile = System.IO.Path.GetFileName(Directory.GetFiles(Environment.CurrentDirectory, "대국민*.docx")[0]);

                File.Move(ZipPath, ResultFolder + "\\" + ZipPath);
                File.Move(docxfile, ResultFolder + "\\" + docxfile);

                System.Diagnostics.Process.Start("explorer.exe", ResultFolder);

                ToastMessage_.Show("보고서가 생성되었습니다");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Close_Dialog(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MXML2_Window_Move(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Label_Credit_Click(object sender, MouseButtonEventArgs e)
        {
            PopupBox.Show("Dinner.At.Home\r\n만든이 : 11231");
            PopupBox.Show("도와준 사람들 : 우리 팀원들\r\n항상 감사드립니다 :D\r\n고맙습니다");
            PopupBox.Show("버그 및 피드백\r\nyeewony@0118.kr");
        }
    }
}
