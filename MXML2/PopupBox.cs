using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;

namespace MXML2
{
    class PopupBox
    {
        public static void Show(string MessageText)
        {
            ShowBlurEffect();
            PopupBox_Window msgbox = new PopupBox_Window(MessageText);
            msgbox.ShowDialog();
            StopBlurEffect();
        }

        static BlurEffect blur = new BlurEffect();
        public static void ShowBlurEffect()
        {
            blur.Radius = 10;
            foreach (Window window in Application.Current.Windows)
            {
                window.Effect = blur;
            }
        }

        public static void StopBlurEffect()
        {
            blur.Radius = 0;
        }
    }
}
