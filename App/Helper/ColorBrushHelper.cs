using System.Windows.Media;

namespace App.Helper
{
    public static class ColorBrushHelper
    {
        public static SolidColorBrush ColorBrushFromRgb(byte r, byte g, byte b)
        {
            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}