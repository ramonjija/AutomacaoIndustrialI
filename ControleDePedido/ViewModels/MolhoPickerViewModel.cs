using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using App.Model;
using Caliburn.Micro;

namespace ControleDePedido.ViewModels
{
    public class MolhoPickerViewModel : BaseViewModel, IHandle<KeyValuePair<Molhos, bool>>
    {
        private IList<MolhosControlViewModel> _molhos;

        public MolhoPickerViewModel(int? previousPicker, int? nextPicker, SolidColorBrush backgroundColor, SolidColorBrush buttonColor, IList<MolhosControlViewModel> molhos) : base(previousPicker, nextPicker, backgroundColor, buttonColor)
        {

            var aggregator = new EventAggregator();

            aggregator.Subscribe(this);

            molhos.ToList().ForEach(x =>
            {
                x.EventAggregator = aggregator;
            });

            Molhos = molhos;

        }

        public IList<MolhosControlViewModel> Molhos
        {
            get { return _molhos; }
            set
            {
                if (Equals(value, _molhos)) return;
                _molhos = value;
                NotifyOfPropertyChange(() => Molhos);
            }
        }

        public void Handle(KeyValuePair<Molhos, bool> message)
        {
            _molhos.Where(x => x.Molho != message.Key).ToList().ForEach(x =>
            {
                x.Enabled = !message.Value;
            });
        }
    }
}
