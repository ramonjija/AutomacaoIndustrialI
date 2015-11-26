using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;
using Caliburn.Micro;

namespace ControleDePedido.ViewModels
{
    public class TemperosControlViewModel : PropertyChangedBase
    {
        private bool _checked;
        private bool _enabled;
        private Temperos _tempero;
        public IEventAggregator EventAggregator { get; set; }

        public TemperosControlViewModel()
        {
            Enabled = true;
        }

        public Temperos Tempero
        {
            get { return _tempero; }
            set
            {
                if (value == _tempero) return;
                _tempero = value;
                NotifyOfPropertyChange(() => Tempero);
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
