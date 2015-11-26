using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeLimpeza
{
    /// <summary>
    /// Interface contendo os metodos da limpeza. Existem 3 frigideiras ligadas por pistao a um eixo. 
    /// A agua é aquecida até a temperatura de fervimento.
    /// As frigideiras entao, giram 90º e a agua fervendo é jateada nas frigideiras.
    /// O rotor é ligado e as frigideiras realizam 3 revoluções.
    /// Uma resistencia é utilizada para aquecer as frigideiras e seca-lás, para serem utilizadas novamente
    /// </summary>
    public interface ILimpeza
    {
        void RealizaLimpeza(List<Frigideira> listaDeFrigideiras);
        
    }
}
