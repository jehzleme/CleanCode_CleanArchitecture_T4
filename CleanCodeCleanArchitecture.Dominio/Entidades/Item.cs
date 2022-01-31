using System;

namespace CCCA.Dominio.Entidades
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Descricao { get; private set; }
        public double Preco { get; private set; }
        public double Altura { get; private set; }
        public double Largura { get; private set; }
        public double Profundidade { get; private set; }
        public double Peso { get; private set; }

        public Item(string descricao, double preco, double altura, double largura, double profundidade, double peso)
        {
            Descricao = descricao;
            Preco = preco;
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
            Peso = peso;
        }

        public double CalcularVolume()
        {
            return Altura * Largura * Profundidade;
        }

        public double CalcularDensidade()
        {
            return Peso / CalcularVolume();
        }
    }
}