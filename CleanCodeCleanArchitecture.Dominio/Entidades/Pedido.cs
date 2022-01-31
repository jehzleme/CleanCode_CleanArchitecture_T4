using System;
using System.Collections.Generic;
using System.Linq;

namespace CCCA.Dominio.Entidades
{
    public class Pedido
    {
        public PedidoCodigo Codigo { get; private set; }
        public DateTime Data { get; private set; }
        public Cpf Cpf { get; private set; }
        public Status Status { get; private set; }
        public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens;
        public Cupom Cupom { get; private set; }
        public double Frete { get; private set; }
        public double SubTotal { get; private set; }
        public double Total { get; private set; }
        private readonly List<PedidoItem> _pedidoItens;
        private readonly double _distancia;

        public Pedido(string cpf, DateTime data, double distancia = 0, int sequencia = 1)
        {
            Data = data;
            Codigo = new PedidoCodigo(data, sequencia);
            Cpf = new Cpf(cpf);
            _pedidoItens = new List<PedidoItem>();
            _distancia = distancia;
            Status = Status.Aguardando;
        }

        public void AdicionarItem(Item item, int quantidade)
        {
            _pedidoItens.Add(new PedidoItem(item.Id, item.Preco, quantidade));
            SomarSubTotal();
        }

        public void AdicionarCupom(Cupom cupom)
        {
            if (cupom != null && cupom.Valido)
            {
                Cupom = cupom;
                Total -= Cupom.CalcularDesconto(SubTotal);
            }
        }

        public void AdicionarFrete(double valor)
        {
            Frete = valor;
            Total += Frete;
        }

        private double SomarSubTotal()
        {
            SubTotal = _pedidoItens.Sum(pedidoItem => pedidoItem.SomarSubTotalItem());
            Total = SubTotal;
            return SubTotal;
        }
    }

    public enum Status
    {
        Aguardando,
        //Realizado,
        //Recusado
    }
}