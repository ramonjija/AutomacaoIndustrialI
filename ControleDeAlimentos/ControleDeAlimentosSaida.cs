using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlimentos
{
    public class ControleDeAlimentosSaida
    {
        EstoqueAlimentos estoque;

        public ControleDeAlimentosSaida(EstoqueAlimentos estoqueJSon)
        {
            estoque = estoqueJSon;
        }

        public void SaidaDeAlimentos(IList<Temperos> listaTemperos)
        {
            foreach (var tempero in listaTemperos)
            {
                switch (tempero)
                {
                    case Temperos.Pimenta:
                        --estoque.estoqueDeTemperos[0];
                        break;
                    case Temperos.Oregano:
                        --estoque.estoqueDeTemperos[1];
                        break;
                    case Temperos.Salsa:
                        --estoque.estoqueDeTemperos[2];
                        break;
                    case Temperos.Manjericão:
                        --estoque.estoqueDeTemperos[3];
                        break;
                    default:
                        break;
                }
            }            
        }

        public void SaidaDeAlimentos(Molhos molho)
        {
            switch (molho)
            {
                case Molhos.Branco:
                    --estoque.estoqueDeMolhos[0];
                    break;
                case Molhos.Sugo:
                    --estoque.estoqueDeMolhos[1];
                    break;
                default:
                    break;
            }
        }

        public void SaidaDeAlimentos(Massas massa)
        {
            switch (massa)
            {
                case Massas.Spaghetti:
                    --estoque.estoqueDeMassas[0];
                    break;
                case Massas.Parafuso:
                    --estoque.estoqueDeMassas[1];
                    break;
                case Massas.Penne:
                    --estoque.estoqueDeMassas[2];
                    break;
                case Massas.Farfalle:
                    --estoque.estoqueDeMassas[3];
                    break;
                default:
                    break;
            }
        }

        public void SaidaDeAlimentos(IList<Toppings>  listaToppings)
        {
            foreach (var topping in listaToppings)
            {
                switch (topping)
                {
                    case Toppings.Azeitona:
                        --estoque.estoqueDeToppings[0];
                        break;
                    case Toppings.Milho:
                        --estoque.estoqueDeToppings[1];
                        break;
                    case Toppings.Tomate:
                        --estoque.estoqueDeToppings[2];
                        break;
                    case Toppings.Cebola:
                        --estoque.estoqueDeToppings[3];
                        break;
                    case Toppings.Champignon:
                        --estoque.estoqueDeToppings[4];
                        break;
                    case Toppings.FrangoDesfiado:
                        --estoque.estoqueDeToppings[5];
                        break;
                    case Toppings.Bacon:
                        --estoque.estoqueDeToppings[6];
                        break;
                    case Toppings.CarneSeca:
                        --estoque.estoqueDeToppings[7];
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
