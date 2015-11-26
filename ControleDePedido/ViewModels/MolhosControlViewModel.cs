using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;
using Caliburn.Micro;

namespace ControleDePedido.ViewModels
{
    public class MolhosControlViewModel : PropertyChangedBase
    {
        private bool _checked;
        private Molhos _molho;
        private bool _enabled;

        public MolhosControlViewModel()
        {
            Enabled = true;
        }

        public Molhos Molho
        {
            get { return _molho; }
            set
            {
                if (value == _molho) return;
                _molho = value;
                NotifyOfPropertyChange(() => Molho);
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

                EventAggregator.PublishOnUIThread(new KeyValuePair<Molhos, bool>(Molho, _checked));
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
