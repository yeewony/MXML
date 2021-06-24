using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MXML2
{
    /// <summary>
    /// PopupBox_Window.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PopupBox_Window : Window
    {
        public PopupBox_Window(string MessageText)
        {
            InitializeComponent();

            tbb_MessageZone.Text = MessageText;
        }

        private void btn_popupcloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PopupBox_Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Pinky MXML2.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Pink.xaml", UriKind.Relative);

                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(dic);
            }
            else if (File.Exists("Mintful MXML2.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Mint.xaml", UriKind.Relative);

                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(dic);
            }
            else if (File.Exists("MXML2 In Sky.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Sky.xaml", UriKind.Relative);

                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(dic);
            }
            else if (File.Exists("Pastel MXML2.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Pastel.xaml", UriKind.Relative);

                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(dic);
            }
            else if (File.Exists("MXML2 보라해.exe"))
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("Resources/ColorPalette_Purple.xaml", UriKind.Relative);

                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(dic);
            }

            Application curApp = Application.Current;
            Window mainwindow = curApp.MainWindow;
            this.Left = mainwindow.Left + (mainwindow.Width - this.ActualWidth) / 2;
            this.Top = mainwindow.Top + (mainwindow.Height - this.ActualHeight) / 2;
        }
    }
}
