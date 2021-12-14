using System;

namespace CCCA.Aplicacao
{
    public class PedidoItemCommand
    {
        public Guid ItemId { get; set; }
        public int Quantidade { get; set; }
    }
}