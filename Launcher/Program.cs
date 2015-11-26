using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ControleDePedido.Helpers;

namespace Launcher
{
    internal class Program
    {
        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomainHost)]
        private static void Main()
        {
            Console.Write("===== AUTOFOOD v1.4.6 =====");

            var domain = AppDomain.CreateDomain(Guid.NewGuid().ToString());

            var controle = new ControleDeAlimentos.ControleDeAlimentos();
            controle.CriaEstoque();
            
            CrossAppDomainDelegate action = () =>
            {
                var thread = new Thread(() =>
                {
                    ControleDePedido.App app = new ControleDePedido.App();
                    app.InitializeComponent();
                    app.Run();
                });
                thread.SetApartmentState(ApartmentState.STA);

                thread.Start();
            };

            domain.DoCallBack(action);

            Console.ReadKey();
        }
    }
}