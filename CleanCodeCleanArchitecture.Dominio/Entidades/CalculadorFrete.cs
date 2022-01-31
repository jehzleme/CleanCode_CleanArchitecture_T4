using CCCA.Dominio.Interfaces;
using System.Collections.Generic;

namespace CCCA.Dominio.Entidades
{
    public class CalculadorFrete
    {
        public CalculadorFrete(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        private readonly IItemRepository _itemRepository;

        public const double VALOR_MINIMO_FRETE = 10.00;

        public double CalcularFrete(List<PedidoItem> pedidoItens, double? distancia)
        {
            if (distancia == null) return 0;

            double valor = 0;
            foreach (var pedidoItem in pedidoItens)
            {
                var item = _itemRepository.ObterPorId(pedidoItem.ItemId).Result;
                valor = item.CalcularVolume() * (item.CalcularDensidade() / 100) * pedidoItem.Quantidade;
            }
            valor *= distancia.Value;

            return valor < VALOR_MINIMO_FRETE ? VALOR_MINIMO_FRETE : valor;
        }
    }
}