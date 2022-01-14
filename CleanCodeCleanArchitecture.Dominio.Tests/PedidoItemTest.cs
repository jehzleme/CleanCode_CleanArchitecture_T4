using CCCA.Dominio.Entidades;
using FluentAssertions;
using NUnit.Framework;

namespace CCCA.Dominio.Tests
{
    public class PedidoItemTest
    {
        [Test]
        public void Deve_Criar_Um_Item_Do_Pedido()
        {
            var item = new Item("Bicicleta", 2000.0, 70, 150, 40, 2.5);
            var pedidoItem = new PedidoItem(item.Id, item.Preco, 3);

            double totalItemPedido = pedidoItem.SomarSubTotalItem();
            var expected = item.Preco * pedidoItem.Quantidade;
            
           totalItemPedido.Should().Be(expected);
        }
    }
}