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

        private void DetectColorMode(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Environment.CurrentDirectory+"\\Pink_MXML2.exe"))
            {
                MessageBox.Show("핑크로 전환합니다.");
            }
        }

        private void START_Inspection(object sender, RoutedEventArgs e)
        {

            try
            {
                MessageBox.Show("점검 전 방해금지 모드 설정");


                tb_StartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void END_Inspection(object sender, RoutedEventArgs e)
        {
            try
            {
                tb_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GenerateXML(object sender, RoutedEventArgs e)
        {
            MobileXML.GenerateXML(tb_StartTime.Text, tb_EndTime.Text, tb_OSVer.Text, tb_ModelName.Text, tb_Manufacturer.Text, tb_Carrier.Text);

        }
    }
}
