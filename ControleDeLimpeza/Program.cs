using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeLimpeza
{
    /// <summary>
    /// Classe para testar comportamento de frigideira, não é chamada na execução e comunicação com outros Controles
    /// </summary>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Frigideira frigideiraA = new Frigideira
            {
                aquecida = false,
                limpa = true,
                utilizada = false
            };
            Frigideira frigideiraB = new Frigideira
            {
                aquecida = false,
                limpa = false,
                utilizada = false
            };
            Frigideira frigideiraC = new Frigideira
            {
                aquecida = false,
                limpa = false,
                utilizada = false
            };

            List<Frigideira> listaDeFrigideiras = new List<Frigideira>();

            //listaDeFrigideiras.Add(frigideiraA);
            listaDeFrigideiras.Add(frigideiraB);
            //listaDeFrigideiras.Add(frigideiraC);

            LimpezaDeFrigideiras realizarLimpeza = new LimpezaDeFrigideiras();
            realizarLimpeza.RealizaLimpeza(listaDeFrigideiras);
            Console.Read();

            //ControleDeEntrega.AutomationCore.ControleDeEntrega enviaPedido = new ControleDeEntrega.AutomationCore.ControleDeEntrega();
            //enviaPedido.DisponibilizaPratoAoCliente("{\"Id\":0,\"Molho\":1,\"Massa\":1,\"Toppings\":[0,6,4,7,4,3],\"Temperos\":[3,1]}");
        }
    }
}
