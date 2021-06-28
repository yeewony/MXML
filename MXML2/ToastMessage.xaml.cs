using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MXML2
{
    /// <summary>
    /// ToastMessage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ToastMessage : Window
    {
        public double Time = 950;

        public ToastMessage(string Message)
        {
            InitializeComponent();
            tbb_MessageZone.Text = Message;
        }

        DoubleAnimation ani;
        private void Toast_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Toast_Close;
            e.Cancel = true;
            ani = new DoubleAnimation(0, (Duration)TimeSpan.FromMilliseconds(Time));
            ani.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, ani);
        }

        private void Toast_Loaded(object sender, RoutedEventArgs e)
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
            Close();
        }

        private void Toast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FastClose();
        }

        public void FastClose()
        {
            ani = new DoubleAnimation(0, (Duration)TimeSpan.FromMilliseconds(100));
            ani.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, ani);
        }
    }
}
