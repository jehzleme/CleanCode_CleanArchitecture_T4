using CCCA.Dominio.Entidades;
using CCCA.Dominio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CCCA.Aplicacao
{
    public class PedidoService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICupomRepository _cupomRepository;

        public PedidoService(IItemRepository itemRepository, IPedidoRepository pedidoRepository, ICupomRepository cupomRepository)
        {
            _itemRepository = itemRepository;
            _pedidoRepository = pedidoRepository;
            _cupomRepository = cupomRepository;
        }

        public async Task<PedidoFeitoCommand> ExecutarAsync(PedidoCommand command)
        {
            //var sequencia = _pedidoRepository.ObterUltimoCodigoSequencia();
            var pedido = new Pedido(command.Cpf, command.Data, command.Distancia);
            foreach (var pedidoItem in command.PedidoItens)
            {
                var item = await _itemRepository.ObterPorId(pedidoItem.ItemId);
                if (item is null) throw new Exception("Não existe item.");
                pedido.AdicionarItem(item, pedidoItem.Quantidade);
            }

            if (!string.IsNullOrEmpty(command.Cupom))
            {
                var cupom = await _cupomRepository.ObterPorDescricao(command.Cupom);

                if (cupom != null)
                    pedido.AdicionarCupom(cupom);
            }

            var frete = new CalculadorFrete(_itemRepository);
            var calculoFrete = frete.CalcularFrete(pedido.PedidoItens.ToList(), command.Distancia);
            pedido.AdicionarFrete(calculoFrete);

            await _pedidoRepository.Salvar(pedido);

            return new PedidoFeitoCommand(pedido.Total);
        }
    }
}