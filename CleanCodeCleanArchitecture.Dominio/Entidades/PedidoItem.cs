using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeCleanArchitecture.Dominio.Entidades
{
    public class PedidoItem
    {
        public Guid IdItem { get; private set; }
        public double PrecoItem { get; private set; }
        public int Quantidade { get; private set; }
        public PedidoItem(Guid idItem, double precoItem, int quantidade)
        {
            IdItem = idItem;
            PrecoItem = precoItem;
            Quantidade = quantidade;
        }

        public double SomarTotal()
        {
            return PrecoItem * Quantidade;
        }
    }
}