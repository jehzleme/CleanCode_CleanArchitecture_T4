using System.Text.RegularExpressions;

namespace CleanCodeCleanArchitecture.Dominio.Entidades
{
    public class Cupom
    {
        public string Descricao { get; set; }
        public double Porcentagem { get; private set; }

        public Cupom(string cupom)
        {
            Descricao = cupom;
            Porcentagem = CalcularPorcentagem(cupom);
        }

        private double CalcularPorcentagem(string cupom)
        {
            var digitosCupom = Regex.Replace(cupom, "[aA-zZ]", "");
            var desconto = double.Parse(digitosCupom);
            return desconto;
        }
    }
}