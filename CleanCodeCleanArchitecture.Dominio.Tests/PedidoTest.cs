using NUnit.Framework;
using FluentAssertions;
using System.Linq;
using System;
using CCCA.Dominio.Entidades;

namespace CCCA.Dominio.Tests
{
    public class PedidoTest
    {
        public const double VALOR_MINIMO_FRETE = 10.00;

        [Test]
        public void Deve_Permitir_Criar_Pedido_Com_Cpf_Valido()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);

            pedido.Status.Should().Be(Status.Aguardando);
        }
        
        [Test]
        public void Deve_Impedir_Criar_Pedido_Com_Cpf_Invalido()
        {
            var cpf = "123.456.789-00";

            var expected = Assert.Throws<Exception>(() => new Pedido(cpf));

            expected.Message.Should().Be("CPF inválido.");
        }

        [Test]
        public void Deve_Criar_Pedido_Com_3_Itens()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);

            pedido.AdicionarItem(new Item("Caneta", 1.50, 15, 3, 1, 0.01), 2);
            pedido.AdicionarItem(new Item("Bicicleta", 2000.0, 70, 150, 40, 2.5), 1);
            pedido.AdicionarItem(new Item("Mouse", 50.50, 4, 6, 8, 0.02), 2);

            pedido.PedidoItens.Count().Should().Be(3);
        }

        [Test]
        public void Deve_Criar_Pedido_Com_Cupom_Desconto_Vigente()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);
            var desconto = new Cupom("40off", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));

            pedido.AdicionarItem(new Item("Caneta", 1.50, 15, 3, 1, 0.01), 2);
            pedido.AdicionarCupom(desconto);

            var expected = pedido.SubTotal - (pedido.SubTotal * desconto.Porcentagem / 100);

            pedido.Total.Should().Be(expected);
        }
        
        [Test]
        public void Deve_Criar_Pedido_Com_Cupom_Desconto_Expirado()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);
            var desconto = new Cupom("40off", null, DateTime.Now.AddDays(-1));

            pedido.AdicionarItem(new Item("Caneta", 1.50, 15, 3, 1, 0.01), 2);
            pedido.AdicionarCupom(desconto);

            var expected = pedido.SubTotal;

            pedido.Total.Should().Be(expected);
        }
        
        [Test]
        public void Deve_Criar_Pedido_Com_Frete_Minimo()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);

            pedido.AdicionarItem(new Item("Caneta", 1.50, 15, 3, 1, 0.01), 2);
            pedido.CalcularFrete(100);

            var expected = pedido.SubTotal + VALOR_MINIMO_FRETE;

            pedido.Total.Should().Be(expected);
        }
        
        [Test]
        public void Deve_Criar_Pedido_Com_Frete()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);

            pedido.AdicionarItem(new Item("Bicicleta", 2000.0, 70, 150, 40, 2.5), 1);
            pedido.CalcularFrete(100);

            var expected = pedido.SubTotal + pedido.Frete;

            pedido.Total.Should().Be(expected);
        }
    }
}