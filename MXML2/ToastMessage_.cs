using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;

namespace MXML2
{
    class ToastMessage_
    {
        public static string Show(string Message)
        {
            BlurEffect_ON();
            ToastMessage toastMessage = new ToastMessage(Message);
            toastMessage.ShowDialog();
            BlurEffect_OFF();
            return "1";
        }

        static BlurEffect Blur = new BlurEffect();
        public static void BlurEffect_ON()
        {
            Blur.Radius = 10;
            foreach (Window window in Application.Current.Windows)
            {
                window.Effect = Blur;
            }
        }

        public static void BlurEffect_OFF()
        {
            Blur.Radius = 0;
        }
    }
}
