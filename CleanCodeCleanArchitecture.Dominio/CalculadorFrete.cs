using CCCA.Dominio.Entidades;
using CCCA.Dominio.Interfaces;
using System.Collections.Generic;

namespace CCCA.Dominio
{
    public class CalculadorFrete : ICalculadorFrete
    {
        private readonly IItemRepository _itemRepository;

        public CalculadorFrete(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public const double VALOR_MINIMO_FRETE = 10.00;

        public double Calcular(List<PedidoItem> pedidoItens, double distancia)
        {
            double valorFrete = 0;
            foreach (var pedidoItem in pedidoItens)
            {
                var item = _itemRepository.ObterPorId(pedidoItem.ItemId).Result;
                valorFrete = item.CalcularVolume() * (item.CalcularDensidade() / 100) * pedidoItem.Quantidade;
            }
            valorFrete *= distancia;

            return valorFrete < VALOR_MINIMO_FRETE ? VALOR_MINIMO_FRETE : valorFrete;
        }
    }
}