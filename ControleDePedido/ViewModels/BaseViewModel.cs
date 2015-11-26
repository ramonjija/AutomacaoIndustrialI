using System.Windows.Media;
using Caliburn.Micro;

namespace ControleDePedido.ViewModels
{
    public class BaseViewModel : Screen
    {
        private readonly SolidColorBrush _backgroundColor;
        private readonly SolidColorBrush _buttonColor;

        public BaseViewModel(int? previousPicker, int? nextPicker, SolidColorBrush backgroundColor, SolidColorBrush buttonColor)
        {
            _backgroundColor = backgroundColor;
            _buttonColor = buttonColor;
            PreviousPicker = previousPicker;
            NextPicker = nextPicker;
        }

        public BaseViewModel(int? previousPicker, int? nextPicker)
        {
            PreviousPicker = previousPicker;
            NextPicker = nextPicker;
        }

        public int? PreviousPicker { get; set; }
        public int? NextPicker { get; set; }

        public SolidColorBrush BackgroundColor
        {
            get { return _backgroundColor; }
        }

        public SolidColorBrush ButtonColor
        {
            get { return _buttonColor; }
        }
    }
}