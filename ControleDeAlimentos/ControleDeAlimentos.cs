using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlimentos
{
    public class ControleDeAlimentos
    {

        public void recebePedido(Pedido pedido)
        {
            DBEstoque dBEstoque = new DBEstoque();
            EstoqueAlimentos estoque = dBEstoque.RecuperaEstoqueSerializado();

            ControleDeAlimentosSaida controleDeAlimentosS = new ControleDeAlimentosSaida(estoque);

            controleDeAlimentosS.SaidaDeAlimentos(pedido.Temperos);
            controleDeAlimentosS.SaidaDeAlimentos(pedido.Molho);
            controleDeAlimentosS.SaidaDeAlimentos(pedido.Massa);
            controleDeAlimentosS.SaidaDeAlimentos(pedido.Toppings);

            dBEstoque.SalvaEstoqueSerializado(estoque);

            enviaStatusEstoque();

        }

        public static StatusEstoque enviaStatusEstoque()
        {
            DBEstoque dBEstoque = new DBEstoque();
            EstoqueAlimentos estoque = dBEstoque.RecuperaEstoqueSerializado();
            StatusEstoque statusEstoque = new StatusEstoque
            {
                estoqueDeMassas = new List<Massas>(),
                estoqueDeMolhos = new List<Molhos>(),
                estoqueDeTemperos = new List<Temperos>(),
                estoqueDeToppings = new List<Toppings>()
            };

            preencheStatus(estoque, statusEstoque);

            return statusEstoque;
        }

        private static void preencheStatus(EstoqueAlimentos estoque, StatusEstoque statusEstoque)
        {
            for (int i = 0; i < estoque.estoqueDeTemperos.Count(); i++)
            {
                if (estoque.estoqueDeTemperos[i] > 0)
                {
                    statusEstoque.estoqueDeTemperos.Add(((Temperos)i));
                }
            }

            for (int i = 0; i < estoque.estoqueDeMolhos.Count(); i++)
            {
                if (estoque.estoqueDeMolhos[i] > 0)
                {
                    statusEstoque.estoqueDeMolhos.Add(((Molhos)i));
                }
            }

            for (int i = 0; i < estoque.estoqueDeMassas.Count(); i++)
            {
                if (estoque.estoqueDeMassas[i] > 0)
                {
                    statusEstoque.estoqueDeMassas.Add(((Massas)i));
                }
            }

            for (int i = 0; i < estoque.estoqueDeToppings.Count(); i++)
            {
                if (estoque.estoqueDeToppings[i] > 0)
                {
                    statusEstoque.estoqueDeToppings.Add(((Toppings)i));
                }
            }
        }

        public void CriaEstoque()
        {
            DBEstoque dBEstoque = new DBEstoque();
            EstoqueAlimentos estoqueAlimentos = new EstoqueAlimentos();
            Random numeroRandom = new Random();

            for (int i = 0; i < 4; i++)
            {
                estoqueAlimentos.estoqueDeTemperos.Add(numeroRandom.Next(0,20));
            }

            for (int i = 0; i < 2; i++)
            {
                estoqueAlimentos.estoqueDeMolhos.Add(numeroRandom.Next(0, 20));
            }            

            for (int i = 0; i < 4; i++)
            {
                estoqueAlimentos.estoqueDeMassas.Add(numeroRandom.Next(0, 20));
            }
            
            for (int i = 0; i < 8; i++)
            {
                estoqueAlimentos.estoqueDeToppings.Add(numeroRandom.Next(0, 20));
            }

            dBEstoque.SalvaEstoqueSerializado(estoqueAlimentos);
            
        }
    }
}