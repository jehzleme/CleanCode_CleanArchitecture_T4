using NUnit.Framework;
using FluentAssertions;
using System.Linq;
using System;
using CleanCodeCleanArchitecture.Dominio.Entidades;

namespace CleanCodeCleanArchitecture.Dominio.Tests
{
    public class PedidoTest
    {
        [Test]
        public void Deve_Fazer_Pedido_Com_Cpf_Valido()
        {
            var cpf ="821.369.750-21";
            var pedido = new Pedido(cpf);

            pedido.Status.Should().Be(Status.Realizado);
        }
        
        [Test]
        public void Nao_Deve_Fazer_Pedido_Com_Cpf_Invalido()
        {
            var cpf = "123.456.789-00";

            var expected = Assert.Throws<Exception>(() => new Pedido(cpf));

            expected.Message.Should().Be("CPF inválido.");
        }

        [Test]
        public void Deve_Fazer_Pedido_Com_3_Itens()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);

            pedido.AdicionarItem(new Item("Caneta", 1.50), 2);
            pedido.AdicionarItem(new Item("Bicicleta", 2000.0), 1);
            pedido.AdicionarItem(new Item("Mouse", 50.50), 2);

            pedido.PedidoItens.Count().Should().Be(3);
        }

        [Test]
        public void Deve_Fazer_Pedido_Com_Cupom_Desconto()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);
            var desconto = new Cupom("40off");

            pedido.AdicionarItem(new Item("Caneta", 1.50), 2);
            pedido.AdicionarItem(new Item("Bicicleta", 2000.0), 1);
            pedido.AdicionarItem(new Item("Mouse", 50.50), 2);
            pedido.AdicionarCupom(desconto);

            var expected = pedido.SubTotal - (pedido.SubTotal * desconto.Porcentagem / 100);

            pedido.Total.Should().Be(expected);
        }
    }
}