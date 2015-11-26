using System.Collections.Generic;
using System.Windows.Media;
using App.Model;

namespace ControleDePedido.ViewModels
{
    public class ToppingPickerViewModel : BaseViewModel
    {
        private IList<ToppingControlViewModel> _toppings;

        public ToppingPickerViewModel(int? previousPicker, int? nextPicker, SolidColorBrush backgroundColor, SolidColorBrush buttonColor, List<ToppingControlViewModel> toppings) : base(previousPicker, nextPicker, backgroundColor, buttonColor)
        {
            Toppings = toppings;
        }

        public override string ToString()
        {
            return "ToppingControl";
        }

        public IList<ToppingControlViewModel> Toppings
        {
            get { return _toppings; }
            set
            {
                if (Equals(value, _toppings)) return;
                _toppings = value;
                NotifyOfPropertyChange(() => Toppings);
            }
        }
    }
}