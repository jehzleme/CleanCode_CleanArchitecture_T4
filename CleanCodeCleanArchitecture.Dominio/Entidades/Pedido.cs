using System.Collections.Generic;
using System.Linq;

namespace CleanCodeCleanArchitecture.Dominio.Entidades
{
    public class Pedido
    {
        public const double VALOR_MINIMO_FRETE = 10.00;

        public Cpf Cpf { get; private set; }
        public Status Status { get; private set; }
        public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens;
        public double SubTotal { get; private set; }
        public Cupom Desconto { get; private set; }
        public double Frete { get; private set; }
        public double Total { get; private set; }
        private List<PedidoItem> _pedidoItens;

        public Pedido(string cpf)
        {
            Cpf = new Cpf(cpf);
            _pedidoItens = new List<PedidoItem>();
            Status = Status.Aguardando;
        }

        public void AdicionarItem(Item item, int quantidade)
        {
            _pedidoItens.Add(new PedidoItem(item, quantidade));
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

        public void CalcularFrete(double distancia)
        {
            double valorFrete = 0;
            foreach (var item in _pedidoItens)
            {
                valorFrete = item.Item.CalcularVolume() * (item.Item.CalcularDensidade() / 100) * item.Quantidade;
            }
            valorFrete *= distancia;

            Frete = valorFrete < VALOR_MINIMO_FRETE ? VALOR_MINIMO_FRETE : valorFrete;
        }

        private Status AlterarStatus()
        {
            return Status;
        }

        private void SomarSubTotal() => SubTotal = _pedidoItens.Sum(pedidoItem => pedidoItem.SomarSubTotal());

        private void DescontarCupom() => Total = SubTotal - (SubTotal * Desconto.Porcentagem / 100);
    }

    public enum Status
    {
        Aguardando,
        Realizado,
        Recusado
    }
}