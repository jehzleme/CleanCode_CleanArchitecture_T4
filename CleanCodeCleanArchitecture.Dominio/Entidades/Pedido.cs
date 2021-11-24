using System.Collections.Generic;

namespace CleanCodeCleanArchitecture.Dominio
{
    public class Pedido
    {
        private List<Item> _itens;
        public Cpf Cpf { get; private set; }
        public Status Status { get; private set; }
        public IReadOnlyCollection<Item> Itens => _itens;
        public double ValorTotal { get; private set; }
        public Desconto Desconto { get; set; }
        public double ValorFinal { get; private set; }


        public Pedido(Cpf cpf)
        {
            Cpf = cpf;
            Status = AlterarStatus(cpf);
            _itens = new List<Item>();
            ValorTotal = SomarTotal(_itens);
        }

        public void AdicionarItens(IEnumerable<Item> itens)
        {
            _itens.AddRange(itens);
        }

        public void AdicionarCupom(Desconto desconto)
        {
            ValorFinal = ValorTotal - (ValorTotal * desconto.Porcentagem / 100);
        }

        private Status AlterarStatus(Cpf cpf)
        {
            return cpf.Valido ? Status.Realizado : Status.Recusado;
        }

        private double SomarTotal(ICollection<Item> itens)
        {
            double valorTotal = 0;
            foreach (var item in itens)
            {
                valorTotal += item.Preco;
            }
            return valorTotal;
        }
    }

    public enum Status
    {
        Realizado = 1,
        Recusado = 2
    }
}