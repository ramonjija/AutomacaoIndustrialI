using System;
using System.Collections.Generic;

namespace App.Model
{
    [Serializable]
    public class Pedido
    {
        public Pedido()
        {
            Toppings = new List<Toppings>(6);
            Temperos = new List<Temperos>();
        }

        public int Id { get; set; }
        public Molhos Molho { get; set; }
        public Massas Massa { get; set; }
        public List<Toppings> Toppings { get; set; }
        public List<Temperos> Temperos { get; set; } 
    }
}