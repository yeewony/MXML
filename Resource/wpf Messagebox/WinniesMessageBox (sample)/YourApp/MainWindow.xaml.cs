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
using WinniesMessageBox;

namespace YourApp
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MyMessageBox.ShowDialog(txbYourText.Text);
        }

        private void btnShortNotification_Click(object sender, RoutedEventArgs e)
        {
            MyShortNotification.ShowDialog(txbYourText.Text);
        }

        private void btnMessageBox2_Click(object sender, RoutedEventArgs e)
        {
            MyMessageBox.ShowDialog(txbYourText.Text, MyMessageBox.Buttons.Yes_No);
        }
    }
}
