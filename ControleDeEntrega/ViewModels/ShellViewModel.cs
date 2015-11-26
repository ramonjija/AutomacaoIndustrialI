using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Helper;
using App.Extensions;
using App.Model;
using Newtonsoft.Json;
using Caliburn.Micro;
using ControleDeEntrega.AutomationCore;

namespace ControleDeEntrega.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>
    {
        private string _message;

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }
        /// <summary>
        /// Recebe o pedido e converte para objeto, e exibe na tela
        /// </summary>
        /// <param name="pedidoJson"></param>
        [STAThread]
        public void RecebePedido(string pedidoJson)
        {
            Pedido pedido = ObjectExtensions.ToObject<Pedido>(pedidoJson);
            Message = ExibeSelecao(pedido);
        }
        /// <summary>
        /// Cria uma string no forma correto para exibição na tela
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        [STAThread]
        private string ExibeSelecao(Pedido pedido)
        {
            string pedidoFormatado;
            string massa;
            string toppins;
            string molho;
            string temperos;
            StringBuilder sb = new StringBuilder();

            massa = pedido.Massa.ToString();
            molho = pedido.Molho.ToString();

            foreach (Toppings toppin in pedido.Toppings)
            {
                sb.Append(toppin.ToString() + ", ");
            }
            sb.Length -= 2;
            toppins = sb.ToString();
            sb.Clear();
            foreach (Temperos tempero in pedido.Temperos)
            {
               sb.Append(tempero.ToString() + ", ");
            }
            sb.Length -= 2;
            temperos = sb.ToString();
           return pedidoFormatado = "Massa: " + massa + '\n' + "Molho: " + molho + '\n'+"Temperos: " + temperos + '\n' +"Toppins: " + toppins + '\n';
        }

        /// <summary>
        /// Contrutor do WPF para exibição na tela
        /// </summary>
        public ShellViewModel()
        {
            string pedidoJsonLido = EntregaReader.LerEntrega();
            RecebePedido(pedidoJsonLido);
            
        }

        public void Close()
        {
            TryClose();
        }
    }
}
