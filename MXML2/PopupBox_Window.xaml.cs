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
    }
}
