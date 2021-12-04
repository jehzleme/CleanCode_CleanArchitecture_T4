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
        public double Total { get; private set; }
        private List<PedidoItem> _pedidoItens;

        public Pedido(string cpf)
        {
            Cpf = new Cpf(cpf);
            _pedidoItens = new List<PedidoItem>();
            Status = AlterarStatus(Cpf);
        }

        public void AdicionarItem(Item item, int quantidade)
        {
            _pedidoItens.Add(new PedidoItem(item.Id, item.Preco, quantidade));
            SomarSubTotal();
        }

        public void AdicionarCupom(Cupom desconto)
        {
            Desconto = desconto;
            DescontarCupom();
        }

        private Status AlterarStatus(Cpf cpf)
        {
            return cpf is null ? Status.Recusado : Status.Realizado;
        }

        private void SomarSubTotal()
        {
            SubTotal = _pedidoItens.Sum(pedidoItem => pedidoItem.SomarTotal());
        }

        private void DescontarCupom()
        {
            Total = SubTotal - (SubTotal * Desconto.Porcentagem / 100);
        }
    }

    public enum Status
    {
        Realizado = 1,
        Recusado = 2
    }
}