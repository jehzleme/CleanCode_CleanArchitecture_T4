using System.Collections.Generic;
using System.Linq;

namespace CleanCodeCleanArchitecture.Dominio.Entidades
{
    public class Pedido
    {


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
            Frete = CalculadorFrete.Calcular(_pedidoItens, distancia);
        }

        private Status AlterarStatus()
        {
            return Status;
        }

        private void SomarSubTotal()
        {
            SubTotal = _pedidoItens.Sum(pedidoItem => pedidoItem.SomarSubTotalItem());
            Total = SubTotal;
        }

        private void DescontarCupom() => Total = SubTotal - (SubTotal * Desconto.Porcentagem / 100);
    }

    public enum Status
    {
        Aguardando,
        Realizado,
        Recusado
    }
}