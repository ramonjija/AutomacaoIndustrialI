﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ControleDeEntrega
{
    interface IControleDeEntrega
    {
        void DisponibilizaPratoAoCliente(string pedido);
    }
}
