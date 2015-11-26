using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControleDeLimpeza
{
    public class LimpezaDeFrigideiras : Limpeza
    {

        protected override bool GiraOEixoDasFrigideiras(int graus)
        {
            Console.WriteLine("Girando a frigideira em: " + graus + "º");
            bool girada = false;
            int incremento = 0;
            Thread.Sleep(1000);
            //Verifica se o parametro de graus passado está dentro do estabelecido
            if (graus != 0)
            {
                if (graus > 0)
                {
                    //Faz o papel de sensor de graus incrementando um grau ate que chegue no valor desejado
                    while (incremento < graus)
                    {
                        incremento++;
                    }
                }
                else
                {
                    //Faz o papel de sensor de graus decrementando um grau ate que chegue no valor desejado
                    while (incremento > graus)
                    {
                        incremento--;
                    }
                }

                if (incremento == graus)
                {
                    girada = true;
                    Console.WriteLine("Frigideira girada com sucesso");
                }
            }
            return girada;

        }

        protected override bool JateamentoDeAguaAquecida(bool aguaAquecida)
        {
            Console.WriteLine("Jateando agua quente...");
            bool jateado = false;
            Thread.Sleep(1000);
            if (aguaAquecida)
            {
                jateado = true;
            }
            return jateado;
        }

        protected override bool LigaORotor(bool rotorLigado)
        {
            Console.WriteLine("Ligando o Rotor do eixo...");
            bool ligado = false;
            Thread.Sleep(1000);
            if (rotorLigado == false)
            {
                ligado = true;
                Console.WriteLine("Rotor ligado com sucesso");

            }
            return ligado;
        }

        protected override bool DesligaORotor(bool rotorLigado)
        {
            Console.WriteLine("Desligando o Rotor do eixo...");
            bool ligado = true;
            Thread.Sleep(500);
            if (rotorLigado == true)
            {
                ligado = false;
                Console.WriteLine("Rotor desligado com sucesso");
            }
            return ligado;
        }

        protected override bool LigaResistenciaParaAquecimento(bool resistenciaLigada)
        {
            Console.WriteLine("Ligando a resistencia para aquecimento...");
            bool ligada = false;
            Thread.Sleep(500);
            if (resistenciaLigada == false)
            {
                ligada = true;
                Console.WriteLine("Resistencia ligada com sucesso");
            }
            return ligada;
        }

        protected override bool RealizaAquecimendoDeAgua()
        {
            Console.WriteLine("Realizando o aquecimento de agua...");
            double tempLimpeza = 0.0;
            Thread.Sleep(2000);
            //Aumentando a temperatura para aquecimento de agua
            while (tempLimpeza < 80.0)
            {
                tempLimpeza += 0.5;
            }
            Console.WriteLine("Agua aquecida com sucesso");
            return true;
        }

        protected override bool RealizaSecagemDeFrigideiras()
        {
            Console.WriteLine("Realizando a secagem e aquecimento da frigideira...");
            Thread.Sleep(1000);
            return true;
        }

        protected override double IniciarATemperaturaDeLimpeza(bool resistenciaLigada)
        {
            Console.WriteLine("Inicio do incremento de temperatura para limpeza...");
            double tempLimpeza = 0.0;
            Thread.Sleep(1000);
            if (resistenciaLigada)
            {
                //Aumentando a temperatura para setar temperatura otima de limpeza
                while (tempLimpeza < 80.0)
                {
                    tempLimpeza += 0.5;
                }
            }
            Console.WriteLine("Temperatura de limpeza alcançada");
            return tempLimpeza;
        }
    }
}
