using CCCA.Dominio;
using CCCA.Dominio.Interfaces;
using CCCA.Infra.Memoria;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCCA.Aplicacao.Tests
{
    public class PedidoServiceTest
    {
        private IItemRepository _itemRepository;
        private IPedidoRepository _pedidoRepository;
        private ICupomRepository _cupomRepository;
        private ICalculadorFrete _calculadorFrete;

        [SetUp]
        public void SetUp()
        {
            _itemRepository = new ItemRepositoryMemory();
            _pedidoRepository = new PedidoRepositoryMemory();
            _cupomRepository = new CupomRepositoryMemory();
            _calculadorFrete = new CalculadorFrete(_itemRepository);
        }

        [TestCase("40off", 1210, TestName = "Deve_Fazer_Pedido_Com_Cupom_Valido")]
        [TestCase("vale20", 2010, TestName = "Deve_Fazer_Pedido_Com_Cupom_Expirado")]
        [TestCase("black", 2010, TestName = "Deve_Fazer_Pedido_Com_Cupom_Invalido")]
        [TestCase(null, 2010, TestName = "Deve_Fazer_Pedido_Sem_Cupom")]
        public async Task Deve_Fazer_Pedido(string cupom, double total)
        {
            var pedidoItens = new List<PedidoItemCommand>()
            {
               new PedidoItemCommand { ItemId = Guid.Parse("80fbfab2-7266-11ec-90d6-0242ac120003"), Quantidade = 1 },
            };
            var command = new PedidoCommand("821.369.750-21", pedidoItens, DateTime.Now, cupom, default);
            var pedidoService = new PedidoService(_itemRepository, _pedidoRepository, _cupomRepository, _calculadorFrete);

            var actual = await pedidoService.ExecutarAsync(command);

            var expected = new PedidoFeitoCommand(total);

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Test]
        public async Task Deve_Fazer_Pedido_Com_Calculo_Frete()
        {
            var pedidoItens = new List<PedidoItemCommand>()
            {
               new PedidoItemCommand { ItemId = Guid.Parse("55ab9ea8-7266-11ec-90d6-0242ac120003"), Quantidade = 2 },
            };
            var command = new PedidoCommand("821.369.750-21", pedidoItens, DateTime.Now, null, 100);
            var pedidoService = new PedidoService(_itemRepository, _pedidoRepository, _cupomRepository, _calculadorFrete);

            var actual = await pedidoService.ExecutarAsync(command);

            var total = 13;
            var expected = new PedidoFeitoCommand(total);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}