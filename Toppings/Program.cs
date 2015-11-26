using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;
using App.Extensions;
using System.Diagnostics;
using System.Threading;

namespace Toppings
{
    class Program
    {
        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomainHost)]
        static void Main(string[] args)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
          

            ToppingsDTO toppings = new ToppingsDTO();
            var pedidoFeito = PedidoJson();
            toppings.realizaToppings(pedidoFeito, true);
            Thread.Sleep(200);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                        ts.Hours, ts.Minutes, ts.Seconds,
                                        ts.Milliseconds / 10);

            Console.WriteLine("Pedido realizado com latencia de " + elapsedTime);
            
            ControleDeEntrega.AutomationCore.ControleDeEntrega enviaParaEntrega = new ControleDeEntrega.AutomationCore.ControleDeEntrega();
            enviaParaEntrega.DisponibilizaPratoAoCliente(ObjectExtensions.ToJson((Pedido)pedidoFeito));

        }

        private static Pedido PedidoJson()
        {
            string pedidoJson = "{\"Id\":0,\"Molho\":1,\"Massa\":2,\"Toppings\":[0,6,4,7,4,3],\"Temperos\":[3,1]}";
            Pedido pedido = ObjectExtensions.ToObject<Pedido>(pedidoJson);
            return pedido;
        }
    }
}
