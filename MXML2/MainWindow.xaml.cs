using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            if (File.Exists(Environment.CurrentDirectory+"\\Pinky_MXML2.exe"))
            {
                MessageBox.Show("Cherry Blossom Activated");
                
            }
        }

        private void btn_Reset_ResetAll(object sender, RoutedEventArgs e)
        {
            ///모바일 점검 정보 리셋
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
        }

        private void btn_START_Inspection(object sender, RoutedEventArgs e)
        {
            try
            {
                string clipdata = tb_InputClipData.Text;
                List<string> InfoList = new List<string>(clipdata.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

                tb_StartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tb_OSVer.Text = InfoList.Where(x => x.StartsWith("안드로이드 버전")).Select(x => x.Replace("안드로이드 버전", string.Empty)).ToArray()[0].Trim();
                tb_ModelName.Text = InfoList.Where(x => x.StartsWith("모델 번호")).Select(x => x.Replace("모델 번호", string.Empty)).ToArray()[0].Trim();
                tb_Manufacturer.Text = InfoList.Where(x => x.StartsWith("제조사")).Select(x => x.Replace("제조사", string.Empty)).ToArray()[0].Trim();
                tb_Carrier.Text = InfoList.Where(x => x.StartsWith("통신사")).Select(x => x.Replace("통신사", string.Empty)).ToArray()[0].Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void btn_END_Inspection(object sender, RoutedEventArgs e)
        {
            try
            {
                tb_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                List<string> InfoList = new List<string>();

                InfoList.Add(tb_StartTime.Text);
                InfoList.Add(tb_EndTime.Text);
                InfoList.Add(tb_OSVer.Text);
                InfoList.Add(tb_ModelName.Text);
                InfoList.Add(tb_Manufacturer.Text);
                InfoList.Add(tb_Carrier.Text);

                MobileXML.GenerateXML(InfoList);

                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
