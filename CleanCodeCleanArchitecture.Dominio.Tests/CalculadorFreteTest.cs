using CCCA.Dominio.Entidades;
using CCCA.Dominio.Interfaces;
using CCCA.Infra.Memoria;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace CCCA.Dominio.Tests
{
    public class CalculadorFreteTest
    {
        private IItemRepository _itemRepository;
        private CalculadorFrete _calculadorFrete;
       
        public const double VALOR_MINIMO_FRETE = 10.00;

        [SetUp]
        public void SetUp()
        {
            _itemRepository = new ItemRepositoryMemory();
            _calculadorFrete = new CalculadorFrete(_itemRepository);
        }

        [Test]
        public void Deve_Calcular_Frete_Maior_Que_Valor_Minimo()
        {
            var cpf = "821.369.750-21";
            double distancia = 100;

            var pedido = new Pedido(cpf, DateTime.Now);
            pedido.AdicionarItem(new Item("Geladeira", 3500.0, 200, 100, 50, 40) { Id = Guid.Parse("aaaab30d-43f7-4ba0-babd-fc4f21eacc9c") }, 1);

            var calculoFrete = _calculadorFrete.CalcularFrete(pedido.PedidoItens.ToList(), distancia);
            pedido.AdicionarFrete(calculoFrete);

            pedido.Frete.Should().BeGreaterThan(VALOR_MINIMO_FRETE);
        }

        [Test]
        public void Deve_Calcular_Frete_Menor_Que_Valor_Minimo()
        {
            var cpf = "821.369.750-21";
            double distancia = 5;

            var pedido = new Pedido(cpf, DateTime.Now);
            pedido.AdicionarItem(new Item("Camera", 1240.0, 20, 15, 10, 1) { Id = Guid.Parse("888b12ef-40d9-41fb-bd7f-e9140e0f3f92") }, 1);

            var calculoFrete = _calculadorFrete.CalcularFrete(pedido.PedidoItens.ToList(), distancia);
            pedido.AdicionarFrete(calculoFrete);

            pedido.Frete.Should().Be(VALOR_MINIMO_FRETE);
        }
    }
}