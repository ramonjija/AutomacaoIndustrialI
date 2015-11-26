using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using App.Model;
using Caliburn.Micro;

namespace ControleDePedido.ViewModels
{
    public class MassaPickerViewModel : BaseViewModel, IHandle<KeyValuePair<Massas, bool>>
    {
        private IList<MassasControlViewModel> _massas;
        
        public void Handle(KeyValuePair<Massas, bool> message)
        {
            _massas.Where(x => x.Massa != message.Key).ToList().ForEach(x =>
            {
                x.Enabled = !message.Value;
            });
        }

        public override string ToString()
        {
            return "MassaControl";
        }

        public MassaPickerViewModel(int? previousPicker, int? nextPicker, SolidColorBrush backgroundColor, SolidColorBrush buttonColor, IList<MassasControlViewModel> massas) : base(previousPicker, nextPicker, backgroundColor, buttonColor)
        {
            var aggregator = new EventAggregator();

            aggregator.Subscribe(this);

            massas.ToList().ForEach(x =>
            {
                x.EventAggregator = aggregator;
            });

            Massas = massas;
        }

        public IList<MassasControlViewModel> Massas
        {
            get { return _massas; }
            set
            {
                if (Equals(value, _massas)) return;
                _massas = value;
                NotifyOfPropertyChange(() => Massas);
            }
        }
    }
}