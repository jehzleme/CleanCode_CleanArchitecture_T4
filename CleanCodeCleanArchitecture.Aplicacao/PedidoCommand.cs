using System;
using System.Collections.Generic;

namespace CCCA.Aplicacao
{
    public class PedidoCommand
    {
        public string Cpf { get; set; }
        public ICollection<PedidoItemCommand> PedidoItens { get; set; }
        public DateTime Data{ get; set; }
        public string Cupom { get; set; }
        public double Distancia { get; set; }

        public PedidoCommand(string cpf, ICollection<PedidoItemCommand> pedidoItens, DateTime data, string cupom, double distancia)
        {
            Cpf = cpf;
            PedidoItens = pedidoItens;
            Data = data;
            Cupom = cupom;
            Distancia = distancia;
        }
    }
}