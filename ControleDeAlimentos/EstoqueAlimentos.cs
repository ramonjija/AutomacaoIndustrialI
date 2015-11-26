using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlimentos
{
    public class EstoqueAlimentos
    {
        public EstoqueAlimentos()
        {
            estoqueDeTemperos = new List<int>();
            estoqueDeMolhos = new List<int>();
            estoqueDeMassas = new List<int>();
            estoqueDeToppings = new List<int>();
        }

        //A posição da lista será semelhante ao enum de seu respectivo tipo.
        public IList<int> estoqueDeTemperos { get; set; }
                
        public IList<int> estoqueDeMolhos { get; set; }
        
        public IList<int> estoqueDeMassas { get; set; }
                
        public IList<int> estoqueDeToppings { get; set; }

        public DateTime? dataDeAtualizacao { get; set; }
    }
}
