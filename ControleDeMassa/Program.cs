using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using App.Extensions;
using App.Model;
using Toppings;

namespace ControleDeMassa
{
   public static class Program
    {
       static Program()
       {
            fila = new Queue<Pedido>();
            toppingsDTO = new ToppingsDTO();
       }

       public static Queue<Pedido> fila { get; set; }
       private static bool _ocupado;
       private static ToppingsDTO toppingsDTO;

        [STAThread]
        public static void Main()
        {
            Console.WriteLine("----------------Iniciando Modulo de Massa ----------------");
            Console.WriteLine("Aguardando pedido...");

            while(true)
            {
                if (!_ocupado)
                    try
                    {
                        var pedido = fila.Dequeue();

                        Thread.Sleep(500);
                        Console.WriteLine("Recebendo pedido");
                        Thread.Sleep(500);
                        CozinharMassa(pedido);
                    }
                    catch (Exception)
                    {
                        //fila está vazia
                    }
            }
        }

        [STAThread]
        public static void IniciarFila(Pedido pedido)
        {
            // recebendo o pedido e colocando na fila
            fila.Enqueue(pedido);
        }

        //enviando a massa para cozinhar
        public static void CozinharMassa(Pedido pedido)
        {
            _ocupado = true;

            if (RealizaAquecimendoDeAgua())
            {
                //simulacao de cozinhar massa por 5 s
                Console.WriteLine("Cozinhando a massa...");
                Thread.Sleep(2000);

                //enviar para o controle de toppings fazer toppings e cozinhar por mais tempo
                Console.WriteLine("Enviando os toppings...");
                toppingsDTO.realizaToppings(pedido.ToJson(), false);
                Console.WriteLine("Terminando de cozinhar a massa...");
                Thread.Sleep(3000);

                 //enviar a massa para o controle de toppings pronta
                toppingsDTO.realizaToppings(pedido.ToJson(), true);
                Console.WriteLine("Massa pronta!");
                Console.ReadKey();               

                _ocupado = false;
            }
        }


        public static bool RealizaAquecimendoDeAgua()
        {
            Console.WriteLine("Realizando o aquecimento de agua...");
            double temp = 0.0;
            //Aumentando a temperatura
            while (temp < 80.0)
            {
                temp += 0.5;
            }
            Console.WriteLine("Agua aquecida com sucesso");
            return true;
        }
    }
}
