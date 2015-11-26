using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class StatusEstoque
    {
        public IList<Temperos> estoqueDeTemperos { get; set; }

        public IList<Molhos> estoqueDeMolhos { get; set; }

        public IList<Massas> estoqueDeMassas { get; set; }

        public IList<Toppings> estoqueDeToppings { get; set; }

    }
}
