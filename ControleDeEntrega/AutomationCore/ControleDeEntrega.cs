using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControleDeEntrega.AutomationCore
{
    /// <summary>
    /// Classe que implementa os metodos necessarios para a entrega
    /// </summary>
    public class ControleDeEntrega : ControleDeEntregaGeral
    {
        //Empurra o pistao para levar o porte à garra
        protected override bool AcionaPistaoComGarra()
        {
            Console.WriteLine("Ligando Pistao...");
            bool acionado;
            Thread.Sleep(1000);
            try
            {
                Console.WriteLine("Pistao Acionado");
                acionado = true;
            }
            catch (InvalidOperationException IE)
            {
                throw IE.InnerException;
            }
            return acionado;
        }
        //Acopla o pote a garra
        protected override bool AcoplaPotesNaGarra()
        {
            Console.WriteLine("Acoplando Pote na garra...");
            bool acionado;
            Thread.Sleep(1000);
            try
            {
                Console.WriteLine("Pote Acoplado");

                acionado = true;
            }
            catch (InvalidOperationException IE)
            {
                throw IE.InnerException;
            }
            return acionado;
        }
        //Libera o pote da garra
        protected override void LiberaGarraComPedido(bool pedidoRecebido)
        {
            Console.WriteLine("Liberando Garra com Pote...");
            Thread.Sleep(1000);
            if (pedidoRecebido)
            {
                Libera();
            }
        }

        private bool Libera()
        {
            Console.WriteLine("Pote Liberado");
            return true;
        }
        //Liga a bomba hidraulica para o pistao
        protected override bool LigaBomba()
        {
            Console.WriteLine("Ligando Bomba...");
            Thread.Sleep(1000);
            bool ligada;
            try
            {
                Console.WriteLine("Bomba Ligada");

                ligada = true;
            }
            catch (InvalidOperationException IE)
            {
                throw IE.InnerException;
            }
            return ligada;
        }
        //Liga o motor para girar o eixo da garra
        protected override bool LigaMotorParaGiroDaGarra()
        {
            Console.WriteLine("Ligando Motor Para Giro...");
            Thread.Sleep(1000);
            bool ligada;
            try
            {
                Console.WriteLine("Motor Ligado");
                ligada = true;
            }
            catch (InvalidOperationException IE)
            {
                throw IE.InnerException;
            }
            return ligada;
        }
        //Realiza o giro do eixo da garra
        protected override bool RealizaGiroDoMotor(bool motorLigado)
        {
            Console.WriteLine("Iniciando Giro...");

            bool girado = false;
            Thread.Sleep(1000);
            if (motorLigado)
            {
                Console.WriteLine("Giro Realizado");
                girado = true;
            }
            return girado;
        }
        //Recebe o pedido da frigideira
        protected override bool RecebePedidoPreparadoDaFrigideira(string pedido)
        {
            bool recebido = false;
            Thread.Sleep(1000);
            if (pedido != null || pedido != "")
            {
                Console.WriteLine("Pedido Recebido");
                recebido = true;
            }
            return recebido;
        }
    }
}
