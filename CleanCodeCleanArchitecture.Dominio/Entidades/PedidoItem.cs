using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeCleanArchitecture.Dominio.Entidades
{
    public class PedidoItem
    {
        public Item Item { get; private set; }
        public int Quantidade { get; private set; }

        public PedidoItem(Item item, int quantidade)
        {
            Item = item;
            Quantidade = quantidade;
        }

        public double SomarSubTotal()
        {
            return Item.Preco * Quantidade;
        }
    }
}