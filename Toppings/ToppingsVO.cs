using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;

namespace Toppings
{
    class ToppingsVO
    {
        public static void main()
        {
            Pedido pedido = new Pedido();

            pedido.Temperos.Add(App.Model.Temperos.Manjericão);

        } 
    }
}
