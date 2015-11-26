using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ControleDeEntrega.AutomationCore
{
    [Serializable]
    public abstract class ControleDeEntregaGeral : IControleDeEntrega
    {
        //Lista de métodos que devem ser implmenetados para realização da entrega
        protected abstract bool LigaBomba();
        protected abstract bool AcionaPistaoComGarra();
        protected abstract bool AcoplaPotesNaGarra();
        protected abstract bool LigaMotorParaGiroDaGarra();
        protected abstract bool RealizaGiroDoMotor(bool motorLigado);
        protected abstract bool RecebePedidoPreparadoDaFrigideira(string pedido);
        protected abstract void LiberaGarraComPedido(bool pedidoRecebido);

        [STAThread]
        public void DisponibilizaPratoAoCliente(string pedido)
        {
            //Inicialização de variaveis para a entrega
            bool bombaLigada;
            bool pistaoAcionado;
            bool poteAcoplado;
            bool motorLigado;
            bool giroRealizado;
            bool pedidoRecebido;

            //Verifica se o pedido é nulo
            if (pedido != null || pedido != "")
            {
                Console.WriteLine();
                Console.WriteLine("--- Iniciando Controle de Entrega de Pedido ---");
                //Liga a bomba hidraulica
                bombaLigada = LigaBomba();
                //Liga o motor que irá realizar o giro da garra
                motorLigado = LigaMotorParaGiroDaGarra();
                //Checa se a bomba foi ligada
                if (bombaLigada)
                {
                    //Aciona o pistão que empurra o pote ate a garra
                    pistaoAcionado = AcionaPistaoComGarra();
                    if (pistaoAcionado)
                    {
                        //Acopla os potes enviados pelo pistão ate a garra
                        poteAcoplado = AcoplaPotesNaGarra();
                        if (poteAcoplado)
                        {
                            //realiza o giro para posicionar o pote na garra e receber a massa e toppins da frigideira
                            giroRealizado = RealizaGiroDoMotor(motorLigado);
                            //Recebe a massa e toppings da frigideira
                            pedidoRecebido = RecebePedidoPreparadoDaFrigideira(pedido);
                            giroRealizado = false;
                            if (pedidoRecebido)
                            {
                                //Realiza mais um giro para disponibilizar o pote com o pedido para o cliente
                                giroRealizado = RealizaGiroDoMotor(motorLigado);
                                //Libera o pedido da garra, para o cliente
                                LiberaGarraComPedido(giroRealizado);

                            }
                        }
                    }
                }
                Console.WriteLine("Enviando Pedido Para Tela");

                //Escreve um arquivo txt com o pedido para ser exibido em tela
                EntregaReader.EscreverEntrega(pedido);

                //Cria um novo domínio pois WPFs não podem possuir mais de uma instancia no mesmo dominio
                var domain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
                
                //Delega a ação no novo dominio
                CrossAppDomainDelegate action = () =>
                {
                    //Cria uma thread pois o WPF trabalha com STAthreads
                    var thread = new Thread(() =>
                    {
                        //Cria um novo objeto do tipo WPF controleDeEntrega
                        App ped = new App();
                        ped.InitializeComponent();
                        ped.Run();
                    });
                    //Indica o tipo de thread
                    thread.SetApartmentState(ApartmentState.STA);
                    //Inicia a thread
                    thread.Start();
                };
                //Chama a nova ação do novo dominio, inicia o ShellViewModel do Controle de Entrega
                domain.DoCallBack(action);

                Console.WriteLine("--- Finalizando o Controle de Entrega de Pedido ---");
            }
        }
    }
}
