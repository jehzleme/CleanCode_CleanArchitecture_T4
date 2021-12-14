using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CCCA.Aplicacao.Tests
{
    public class PedidoServiceTest
    {
        [Test]
        public async Task Deve_Fazer_Pedido()
        {
            var pedidoItens = new List<PedidoItemCommand>();
            var command = new PedidoCommand("821.369.750-21", pedidoItens, DateTime.Now, "vale20");
            var pedidoService = new PedidoService();
            await pedidoService.ExecutarAsync(command);


        }
    }
}
