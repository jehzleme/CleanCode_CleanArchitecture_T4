using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeCleanArchitecture.Dominio.Tests
{
    public class PedidoTest
    {
        [Test]
        public void Nao_Deve_Fazer_Pedido_Com_Cpf_Invalido()
        {
            var cpf = new Cpf("123.456.789-00");
            var pedido = new Pedido(cpf);

            pedido.Status.Should().Be(Status.Recusado);
        }

        [Test]
        public void Deve_Fazer_Pedido_Com_3_Itens()
        {
            var cpf = new Cpf("821.369.750-21");
            var itens = new List<Item> { new Item("Caneta", 1.50, 2), new Item("Bicicleta", 2000.0, 1), new Item("Mouse", 50.50, 2) }; ;
            var pedido = new Pedido(cpf);
            pedido.AdicionarItens(itens);

            pedido.Itens.Count().Should().Be(3);
        }

        [Test]
        public void Deve_Fazer_Pedido_Com_Cupom_Desconto()
        {
            var cpf = new Cpf("821.369.750-21");
            var itens = new List<Item> { new Item("Caneta", 1.50, 2), new Item("Bicicleta", 2000.0, 1), new Item("Mouse", 50.50, 2) };
            var desconto = new Desconto("40off");
            var pedido = new Pedido(cpf);

            pedido.AdicionarItens(itens);
            pedido.AdicionarCupom(desconto);

            var expected = pedido.ValorTotal - (pedido.ValorTotal * desconto.Porcentagem / 100);

            pedido.ValorFinal.Should().Be(expected);
        }
    }
}