using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ControleDePedido.ViewModels
{
    public class TemperoPickerViewModel : BaseViewModel
    {
        private IList<TemperosControlViewModel> _temperos;

        public TemperoPickerViewModel(int? previousPicker, int? nextPicker, SolidColorBrush backgroundColor, SolidColorBrush buttonColor, List<TemperosControlViewModel> temperos) : base(previousPicker, nextPicker, backgroundColor, buttonColor)
        {
            Temperos = temperos;
        }

        public IList<TemperosControlViewModel> Temperos
        {
            get { return _temperos; }
            set
            {
                if (Equals(value, _temperos)) return;
                _temperos = value;
                NotifyOfPropertyChange(() => Temperos);
            }
        }
    }
}
