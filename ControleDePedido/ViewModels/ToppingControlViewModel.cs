using System.Collections.Generic;
using App.Model;
using Caliburn.Micro;

namespace ControleDePedido.ViewModels
{
    public class ToppingControlViewModel : PropertyChangedBase
    {
        private bool _checked;
        private bool _enabled;
        private Toppings _topping;
        public IEventAggregator EventAggregator { get; set; }

        public ToppingControlViewModel()
        {
            Enabled = true;
        }

        public Toppings Topping
        {
            get { return _topping; }
            set
            {
                if (value == _topping) return;
                _topping = value;
                NotifyOfPropertyChange(() => Topping);
            }
        }

        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (value == _checked) return;
                _checked = value;
                NotifyOfPropertyChange(() => Checked);
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (value == _enabled) return;
                _enabled = value;
                NotifyOfPropertyChange(() => Enabled);
            }
        }
    }
}