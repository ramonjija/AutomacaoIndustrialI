using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ControleDeEntrega
{
    interface IControleDePedido
    {
        void RecebeComponentesDoControleDeToppin(String MolhoToppinMassa);
        void RecebeComponentesDoControleDeToppin(Object MolhoToppinMassa);
        void MontaComponenetesNoPrato(String Componentes);
        void MontaComponenetesNoPrato(Object Componentes);
        void DisponibilizaPratoAoCliente();
    }
}
