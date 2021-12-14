using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CCCA.Dominio.Entidades
{
    public class Pedido
    {
        public string Codigo { get; private set; }
        public DateTime Data { get; private set; }
        public Cpf Cpf { get; private set; }
        public Status Status { get; private set; }
        public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens;
        public double SubTotal { get; private set; }
        public Cupom Desconto { get; private set; }
        public double Frete { get; private set; }
        public double Total { get; private set; }
        private List<PedidoItem> _pedidoItens;


        public Pedido(string cpf, DateTime data)
        {
            Data = data;
            Codigo = GerarCodigoPedido(data);
            Cpf = new Cpf(cpf);
            _pedidoItens = new List<PedidoItem>();
            Status = Status.Aguardando;
        }

        private string GerarCodigoPedido(DateTime data)
        {
            var ano = data.Year.ToString();

            var sequencia = 

            var sb = new StringBuilder();
            sb.Append(ano);
            sb.Append();
            
            return ano;
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

        private void DescontarCupom() => Total = SubTotal - (SubTotal * Desconto.Porcentagem / 100);
    }

    public enum Status
    {
        Aguardando,
        //Realizado,
        //Recusado
    }
}