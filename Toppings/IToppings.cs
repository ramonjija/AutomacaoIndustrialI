using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppings
{
    /// <summary>
    /// Interface com ações dos toppings 
    /// </summary>
    interface IToppings
    {
        void realizaToppings(Pedido pedido, bool macarraoEstaPronto);
        bool RecebeMacarrao(bool macarraoEstaPronto);
        void RecebePedido(Pedido pedido);
        bool LigaResistenciaParaAquecimento(bool resistenciaEstaLigada);
        bool LigaAquecimentoPorInducao(bool aquecimentoEstaLigado);
        int LigarSensorDeTemperatura(bool sensorEstaLigado);
        bool MonitoraSensorDeTemperatura();
        bool LigaMotorDeRotacaoPneumatico(bool motorEstaLigado);
        void ToopingsPorSensoresDeNivel();
        bool GiraOEixoDaFrigideira();
        void ChamaLimpeza();
    }
}
