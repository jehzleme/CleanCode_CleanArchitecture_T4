using CCCA.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCCA.Aplicacao
{
    public class PedidoCommand
    {
        public string Cpf { get; set; }
        public ICollection<PedidoItemCommand> PedidoItens { get; set; }
        public DateTime Data{ get; set; }
        public string Cupom { get; set; }

        public PedidoCommand(string cpf, ICollection<PedidoItemCommand> pedidoItens, DateTime data, string cupom)
        {
            Cpf = cpf;
            PedidoItens = pedidoItens;
            Data = data;
            Cupom = cupom;
        }
    }
}
