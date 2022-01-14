using CCCA.Dominio.Interfaces;
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
        public double SubTotal { get; private set; }
        public Cupom Desconto { get; private set; }
        public double Frete { get; private set; }
        public double Total { get; private set; }
        private readonly List<PedidoItem> _pedidoItens;

        public Pedido(string cpf, DateTime data, int sequencia = 1)
        {
            Data = data;
            Codigo = new PedidoCodigo(data, sequencia);
            Cpf = new Cpf(cpf);
            _pedidoItens = new List<PedidoItem>();
            Status = Status.Aguardando;
            Frete = 0;
        }

        public void AdicionarItem(Item item, int quantidade)
        {
            _pedidoItens.Add(new PedidoItem(item.Id, item.Preco, quantidade));
            SomarSubTotal();
        }

        public void AdicionarCupom(Cupom desconto)
        {
            if (desconto.Valido)
            {
                Desconto = desconto;
                DescontarCupom();
            }
        }

        public void CalcularFrete(double distancia, ICalculadorFrete calculadorFrete)
        {
            Frete = calculadorFrete.Calcular(_pedidoItens, distancia);

            if (Frete > 0)
                Total += Frete;
        }

        //private Status AlterarStatus()
        //{
        //    return Status;
        //}

        private void SomarSubTotal()
        {
            SubTotal = _pedidoItens.Sum(pedidoItem => pedidoItem.SomarSubTotalItem());
            Total = SubTotal;
        }

        private void DescontarCupom() => Total = SubTotal - (SubTotal * Desconto.Desconto / 100);
    }

    public enum Status
    {
        Aguardando,
        //Realizado,
        //Recusado
    }
}