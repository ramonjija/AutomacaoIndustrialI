using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeLimpeza
{
    public abstract class Limpeza : ILimpeza
    {
        //Lista de métodos que devem ser implmenetados para realização da limpeza
        protected abstract bool RealizaAquecimendoDeAgua();
        protected abstract bool LigaORotor(bool rotorLigado);
        protected abstract bool DesligaORotor(bool rotorLigado);
        protected abstract bool GiraOEixoDasFrigideiras(int graus);
        protected abstract bool JateamentoDeAguaAquecida(bool aguaAquecida);
        protected abstract bool LigaResistenciaParaAquecimento(bool resistenciaLigada);
        protected abstract double IniciarATemperaturaDeLimpeza(bool resistenciaLigada);
        protected abstract bool RealizaSecagemDeFrigideiras();
        public void RealizaLimpeza(List<Frigideira> listaDeFrigideiras)
        {
            Console.WriteLine("--- Modulo de limpeza Iniciado ---");
            Console.WriteLine();

            //Inicialização de variaveis para a limpeza
            bool aguaAquecida;
            bool resistenciaLigada = false;
            bool rotorLigado = false;
            double temperaturaDeAquecimento;
            bool frigideiraGirada;
            bool aguaJateada;
            int graus = 90;
            int numeroDaFrigideira = 1;
            
            //Ligando a resistencia para aquecimendo
            resistenciaLigada = LigaResistenciaParaAquecimento(resistenciaLigada);
            //Setando a temperatura de aquecimento
            temperaturaDeAquecimento = IniciarATemperaturaDeLimpeza(resistenciaLigada);
            //Aquecendo a agua para limpeza
            aguaAquecida = RealizaAquecimendoDeAgua();
            if (aguaAquecida)
            {
                //Ligando o rotor para realizar as revoluções das frigideiras
                rotorLigado = LigaORotor(rotorLigado);
                Console.WriteLine();
                //Entrada no metodo que realizara o processo de limpeza
                while (rotorLigado)
                {
                    //Seleciona a frigideira
                    foreach (Frigideira frigideiraEmUso in listaDeFrigideiras)
                    {
                        Console.WriteLine("Inicio da limpeza da frigideira " + numeroDaFrigideira);
                        Console.WriteLine();
                        if (frigideiraEmUso.limpa == false)
                        {
                            frigideiraEmUso.utilizada = true;
                            //Realiza um giro vertical para o jateamento de agua quente na frigideira
                            frigideiraGirada = GiraOEixoDasFrigideiras(graus);
                            
                            //Checa se a frigideira foi girada corretamente
                            if (frigideiraGirada)
                            {
                                //Jateia agua quente na frigideira girada
                                aguaJateada = JateamentoDeAguaAquecida(aguaAquecida);

                                //Verifica se a temperatura é a ideal
                                if (temperaturaDeAquecimento >= 80)
                                {
                                    //Realiza a Secagem/Aquecimento da frigideira. A frigideira chega aquecida para os Toppings reutilizarem.
                                    frigideiraEmUso.aquecida = RealizaSecagemDeFrigideiras();
                                    
                                    //Verifica se a frigideira esta aquecida.
                                    if (frigideiraEmUso.aquecida)
                                    {
                                        //Indica que a frigideira foi limpa.
                                        frigideiraEmUso.limpa = true;
                                        frigideiraEmUso.utilizada = false;

                                        //Retorna a posição inicial do eixo vertical da frigideira.
                                        if (GiraOEixoDasFrigideiras(-90))
                                        {
                                            frigideiraGirada = false; //zera a variavel para condição inicial
                                        }
                                        aguaJateada = false; //zera a variavel para condição inicial
                                        Console.WriteLine();
                                        Console.WriteLine(">> Frigideira " + numeroDaFrigideira + " limpa com sucesso");
                                        Console.WriteLine();

                                    }
                                }

                            }
                        }
                        else//Figideira está limpa, não é necessário a limpeza
                        {
                            Console.WriteLine(">> Frigideira nao precisa de limpeza");
                            Console.WriteLine();
                        }
                        numeroDaFrigideira++; //Seleciona proxima frigideira, se houver
                    }
                    //Desliga o rotor do eixo que gira as frigideiras selecionando-as para a limpeza.
                    rotorLigado = DesligaORotor(rotorLigado);
                }
            }
            Console.WriteLine();
            Console.WriteLine("--- Modulo de limpeza Finalizado ---");
        }

    }
}