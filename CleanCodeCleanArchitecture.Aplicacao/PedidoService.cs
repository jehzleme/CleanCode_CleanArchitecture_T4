using CCCA.Dominio;
using CCCA.Dominio.Entidades;
using CCCA.Dominio.Interfaces;
using System;
using System.Threading.Tasks;

namespace CCCA.Aplicacao
{
    public class PedidoService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICupomRepository _cupomRepository;
        private readonly ICalculadorFrete _calculadorFrete;

        public PedidoService(IItemRepository itemRepository, IPedidoRepository pedidoRepository, ICupomRepository cupomRepository, ICalculadorFrete calculadorFrete)
        {
            _itemRepository = itemRepository;
            _pedidoRepository = pedidoRepository;
            _cupomRepository = cupomRepository;
            _calculadorFrete = calculadorFrete;
        }

        public async Task<PedidoFeitoCommand> ExecutarAsync(PedidoCommand command)
        {
            var pedido = new Pedido(command.Cpf, command.Data);
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

            pedido.CalcularFrete(command.Distancia, _calculadorFrete);

            await _pedidoRepository.Salvar(pedido);

            return new PedidoFeitoCommand(pedido.Total);
        }
    }
}