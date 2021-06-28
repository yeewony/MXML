using System.Windows.Media;

namespace MXML2
{
    class ColorPalette
    {

        public SolidColorBrush Pinky()
        {
            Color fff0f5 = (Color)ColorConverter.ConvertFromString("#fff0f5");

            SolidColorBrush PinkyPrimary = new SolidColorBrush(fff0f5);

            return PinkyPrimary;
        }

        public SolidColorBrush TextDark()
        {
            Color a7a7a7 = (Color)ColorConverter.ConvertFromString("#a7a7a7");
            SolidColorBrush TextDark = new SolidColorBrush(a7a7a7);

            return TextDark;
        }

    }
}
