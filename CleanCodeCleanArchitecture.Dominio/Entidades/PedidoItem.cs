using System;

namespace CCCA.Dominio.Entidades
{
    public class PedidoItem
    {
        //public Item Item { get; private set; }
        public Guid ItemId { get; private set; }
        public double Preco { get; private set; }
        public int Quantidade { get; private set; }

        public PedidoItem(Guid itemId, double preco, int quantidade)
        {
            ItemId = itemId;
            Preco = preco;
            Quantidade = quantidade;
        }

        public double SomarSubTotalItem()
        {
            return Preco * Quantidade;
        }
    }
}