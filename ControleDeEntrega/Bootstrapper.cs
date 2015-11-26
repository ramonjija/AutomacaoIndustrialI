using System.Windows;
using Caliburn.Micro;
using ControleDeEntrega.ViewModels;

namespace ControleDeEntrega
{
    internal class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}