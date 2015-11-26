using System.Collections.Generic;
using App.Extensions;
using App.Model;
using Xunit;

namespace App.Test.Extensions
{
    [Trait("Extensões de Pedido", "")]
    public class PedidoExtensionTests
    {
        [Fact(DisplayName = "Converter pedido para o formato Json")]
        public void ConvertPedidoToJson()
        {
            var pedidoJson = Pedido.ToJson();

            Assert.NotNull(pedidoJson);
        }

        [Fact(DisplayName = "Converter json para o tipo 'Pedido'")]
        public void ConvertJsonToPedido()
        {
            var pedido = PedidoJson.ToObject<Pedido>();

            Assert.NotNull(pedido);
        }

        #region objectMoq

        public Pedido Pedido
        {
            get
            {
                return new Pedido
                {
                    Massa = Massas.Farfalle,
                    Molho = Molhos.Sugo,
                    Temperos = new List<Temperos> {Temperos.Manjericão, Temperos.Oregano},
                    Toppings =
                        new List<Toppings>
                        {
                            Toppings.Azeitona,
                            Toppings.Bacon,
                            Toppings.Champignon,
                            Toppings.CarneSeca,
                            Toppings.Champignon,
                            Toppings.Cebola
                        }
                };
            }
        }

        public string PedidoJson { get { return "{\"Id\":0,\"Molho\":1,\"Massa\":3,\"Toppings\":[0,6,4,7,4,3],\"Temperos\":[3,1]}"; } }

    #endregion
    }
}