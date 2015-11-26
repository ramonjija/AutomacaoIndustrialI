using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;
using System.Threading;
using App.Extensions;

namespace Toppings
{
    public class ToppingsDTO : IToppings
    {
        /// <summary>
        /// Funcao responsavel por aquecer e misturar os toppins com a massa
        /// </summary>
        /// <param name="pedido">Pedido enviado</param>
        /// <param name="macarraoEstaPronto">Boleano que indica se ja é possivel receber o macarrao preparado</param>
        [STAThread]
        public void realizaToppings(Pedido pedido, bool macarraoEstaPronto)
        {
            //Checa se o macarrao pronto, indicando se os toppins devem ser aquecidos ou misturados ao macarrao
            if (macarraoEstaPronto == false)
            {

                Console.WriteLine();
                Console.WriteLine("---------------- Chamando Toppings  ------------------------------");
                Console.WriteLine("Ligando resistencia para aquecimento ...");
                //Liga a resistencia para aquecimento
                LigaResistenciaParaAquecimento(true);
                Console.WriteLine("Resistencia ligada ");
                Console.WriteLine("Ligando sensor de temperatura ...");
                //Liga o sensor de temperatura para verificar a temperatura ideal
                LigarSensorDeTemperatura(true);
                Console.WriteLine("Sensor de temperatura ligado ");
                Console.WriteLine("Ligando aquecimento por indução ... ");
                //Liga a inducao para realizar o aquecimento por inducao
                LigaAquecimentoPorInducao(true);
                Console.WriteLine("Monitoramento de temperatura do aquecimento por sensor de temperatura ... ");
                //Realiza o monitoramento para controle de temperatura
                MonitoraSensorDeTemperatura();
                Console.WriteLine("---------------- Aquecendo Toppings ...  -------------------------");
            }
            else //Nesse caso o macarrao ja esta pronto e sera enviado
            {
                //Liga o motor de rotaçao que ira receber o macarrar e misturar com os toppins
                LigaMotorDeRotacaoPneumatico(true);
                //Verifica a quantidade de toppins selecionado liberando-os para a mistura com a massa
                ToopingsPorSensoresDeNivel();
                Console.WriteLine();
                Console.WriteLine("-----------------Preparando Toppings ... -------------------------");
                Console.WriteLine();
                Console.WriteLine("Ligando sensores de niveis");
                Console.WriteLine("Sensores de niveis ligados");
                Console.WriteLine("Separação dos toppings");
                Console.WriteLine("Toppings monitorados por sensores de niveis ");
                Console.WriteLine("---------------- Toppings Aquecidos! -----------------------------");
                Console.WriteLine();
                Console.WriteLine("Ligando motores de rotação pneumaticos ... ");
                Console.WriteLine("Motores de rotação pneumaticos ligados. ");
                Console.WriteLine("Retirando pote para pedido");
                Console.WriteLine("Girando eixo da frigideira para mistura com toppins");
                Console.WriteLine("Ligando motores de rotação das panelas");
                //Gira o eixo da frigideira para mistura com toppins
                GiraOEixoDaFrigideira();
                Console.WriteLine("Entregando pedido ");
                Console.WriteLine("---------------- Preparando a entrega de pedido  -----------------");
                Console.WriteLine("---------------- Pedido Entregue ---------------------------------");
                Console.WriteLine();
                Console.WriteLine("Chamando Controle de limpeza");
                Console.WriteLine();
                //Envia o prato preparado para o controle de entrega e assim disponibilizar para o cliente
                ControleDeEntrega.AutomationCore.ControleDeEntrega enviaParaEntrega = new ControleDeEntrega.AutomationCore.ControleDeEntrega();
                enviaParaEntrega.DisponibilizaPratoAoCliente(ObjectExtensions.ToJson(pedido));
                //Chama o controle de limpeza para limpar as frigideiras utilizadas
                ChamaLimpeza();

            }
        }
        /// <summary>
        /// Sobrecarga da funcao anterior com o parametro de pedido no formato de json
        /// </summary>
        /// <param name="jsonPedido">string json contendo o pedido</param>
        /// <param name="macarraoEstaPronto">Boleano que indica se ja é possivel receber o macarrao preparado</param>
        [STAThread]
        public void realizaToppings(string jsonPedido, bool macarraoEstaPronto)
        {
            //Checa se o macarrao pronto, indicando se os toppins devem ser aquecidos ou misturados ao macarrao
            if (macarraoEstaPronto == false){

                Console.WriteLine();
                Console.WriteLine("---------------- Chamando Toppings  ------------------------------");
                Console.WriteLine("Ligando resistencia para aquecimento ...");
                //Liga a resistencia para aquecimento
                LigaResistenciaParaAquecimento(true);
                Console.WriteLine("Resistencia ligada ");
                Console.WriteLine("Ligando sensor de temperatura ...");
                //Liga o sensor de temperatura para verificar a temperatura ideal
                LigarSensorDeTemperatura(true);
                Console.WriteLine("Sensor de temperatura ligado ");
                Console.WriteLine("Ligando aquecimento por indução ... ");
                //Liga a inducao para realizar o aquecimento por inducao
                LigaAquecimentoPorInducao(true);
                Console.WriteLine("Monitoramento de temperatura do aquecimento por sensor de temperatura ... ");
                //Realiza o monitoramento para controle de temperatura
                MonitoraSensorDeTemperatura();
                Console.WriteLine("---------------- Aquecendo Toppings ...  -------------------------");
            }
            else //Nesse caso o macarrao ja esta pronto e sera enviado
            {

                //Liga o motor de rotaçao que ira receber o macarrar e misturar com os toppins
                LigaMotorDeRotacaoPneumatico(true);
                //Verifica a quantidade de toppins selecionado liberando-os para a mistura com a massa
                ToopingsPorSensoresDeNivel();
                Console.WriteLine();
                Console.WriteLine("-----------------Preparando Toppings ... -------------------------");
                Console.WriteLine();
                Console.WriteLine("Ligando sensores de niveis");
                Console.WriteLine("Sensores de niveis ligados");
                Console.WriteLine("Separação dos toppings");
                Console.WriteLine("Toppings monitorados por sensores de niveis ");
                Console.WriteLine("---------------- Toppings Aquecidos! -----------------------------");
                Console.WriteLine();
                Console.WriteLine("Ligando motores de rotação pneumaticos ... ");
                Console.WriteLine("Motores de rotação pneumaticos ligados. ");
                Console.WriteLine("Retirando pote para pedido");
                Console.WriteLine("Girando a panela em 90 graus");
                Console.WriteLine("Ligando motores de rotação das panelas");
                //Gira o eixo da frigideira para mistura com toppins
                GiraOEixoDaFrigideira();
                Console.WriteLine("Entregando pedido ");
                Console.WriteLine("---------------- Preparando a entrega de pedido  -----------------");
                Console.WriteLine("---------------- Pedido Entregue ---------------------------------");
                Console.WriteLine();
                Console.WriteLine("Chamando Controle de limpeza");
                Console.WriteLine();
                //Envia o prato preparado para o controle de entrega e assim disponibilizar para o cliente
                ControleDeEntrega.AutomationCore.ControleDeEntrega enviaParaEntrega = new ControleDeEntrega.AutomationCore.ControleDeEntrega();
                enviaParaEntrega.DisponibilizaPratoAoCliente(jsonPedido);
                //Chama o controle de limpeza para limpar as frigideiras utilizadas
                ChamaLimpeza();

            }
        }
        //Funcao booleana que indica o recebimento do macarrao
        public bool RecebeMacarrao(bool macarraoEstaPronto)
        {
            return macarraoEstaPronto;
        }
        //Funcao que indica o recebimento do pedido
        public void RecebePedido(Pedido pedido)
        {
            LigaResistenciaParaAquecimento(true);
            LigaMotorDeRotacaoPneumatico(true);
        }
        //Liga a resistencia para aquecimento
        public bool LigaResistenciaParaAquecimento(bool resistenciaEstaLigada)
        {
            Thread.Sleep(1000);
            var frigideira = FrigideiraEnum.Aquecida;

            return resistenciaEstaLigada;
        }
        //Liga o motor para rotacao
        public bool LigaMotorDeRotacaoPneumatico(bool motorEstaLigado)
        {
            Thread.Sleep(1000);
            return motorEstaLigado;
        }
        //Indica a liberacao dos toppins para a frigideira utilizando o sensor de niveis
        public void ToopingsPorSensoresDeNivel()
        {
            Thread.Sleep(1000);
            var frigideira = FrigideiraEnum.Utilizada;

        }
        //Gira o eixo da frigideira para misturar os toppins
        public bool GiraOEixoDaFrigideira()
        {
            Thread.Sleep(1000);
            return true;
        }
        //Chama a rotina de limpeza para limpar a frigideira utilizada
        public void ChamaLimpeza()
        {
            ControleDeLimpeza.LimpezaDeFrigideiras rotinaDeLimpeza = new ControleDeLimpeza.LimpezaDeFrigideiras();
            ControleDeLimpeza.Frigideira frigideiraSuja = new ControleDeLimpeza.Frigideira { aquecida = false, limpa = false, utilizada = false };
            List<ControleDeLimpeza.Frigideira> listaDeFrigideiras = new List<ControleDeLimpeza.Frigideira>();
            listaDeFrigideiras.Add(frigideiraSuja);
            rotinaDeLimpeza.RealizaLimpeza(listaDeFrigideiras);
            var frigideira = FrigideiraEnum.Limpa;
        }

        //Liga o sendor de temperatura
        public int LigarSensorDeTemperatura(bool sensorEstaLigado)
        {
            var temperatura = 20;
            return temperatura;
        }
        //Reliza o monitoramento de temperatura
        public bool MonitoraSensorDeTemperatura()
        {

            if (LigarSensorDeTemperatura(true) > 30)
                throw new NotImplementedException();
            return true;
        }

        //Liga o aquecimento por inducao
        public bool LigaAquecimentoPorInducao(bool aquecimentoEstaLigado)
        {
            return aquecimentoEstaLigado;
        }
    }
}
