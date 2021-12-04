using System;

namespace CleanCodeCleanArchitecture.Dominio.Entidades
{
    public class Item
    {
        public Guid Id { get; private set;  }
        public string Descricao { get; private set; }
        public double Preco { get; private set; }

        public Item(string descricao, double preco)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Preco = preco;
        }
    }
}