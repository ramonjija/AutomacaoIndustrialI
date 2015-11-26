using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppings
{
    public class FrigideiraEnum
    {
        private FrigideiraEnum(String value) { Value = value; }
        public String Value { get; set; }
        public static FrigideiraEnum Limpa { get { return new FrigideiraEnum("Limpa"); } }
        public static FrigideiraEnum Aquecida { get { return new FrigideiraEnum("Aquecida"); } }
        public static FrigideiraEnum Utilizada { get { return new FrigideiraEnum("Utilizada"); } }

    }
    
}
