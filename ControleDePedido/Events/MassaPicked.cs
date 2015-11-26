using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;

namespace ControleDePedido.Events
{
    public class MassaPicked
    {
        public Massas SelectedMassa { get; set; }
        public bool Checked { get; set; }
    }
}
