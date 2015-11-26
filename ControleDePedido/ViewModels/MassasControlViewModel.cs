using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;
using Caliburn.Micro;

namespace ControleDePedido.ViewModels
{

    public class MassasControlViewModel : PropertyChangedBase
    {
        private bool _checked;
        private Massas _massa;
        private bool _enabled;

        public MassasControlViewModel()
        {
            Enabled = true;
        }

        public Massas Massa
        {
            get { return _massa; }
            set { _massa = value; }
        }

        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (value == _checked) return;
                _checked = value;
                NotifyOfPropertyChange(() => Checked);

                EventAggregator.PublishOnUIThread(new KeyValuePair<Massas, bool>(Massa, _checked));
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

        public EventAggregator EventAggregator { get; set; }
    }
}
