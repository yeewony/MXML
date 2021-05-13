using System;
using System.Collections.Generic;
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

namespace xmlgenerator
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MobileXML.Generate("22:22 연월일", "10", "SM_048d", "SAMSUNG", "SKT");
        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            string[] File = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (File != null && File.Length != 0)
            {
                testbox.Text = File[0];
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string zip = testbox.Text;
            LogExtractor.LogToXML(zip);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
