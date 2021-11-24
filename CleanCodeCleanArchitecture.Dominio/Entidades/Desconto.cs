using System.Linq;
using System.Text.RegularExpressions;

namespace CleanCodeCleanArchitecture.Dominio
{
    public class Desconto
    {
        public string Cupom { get; set; }
        public double Porcentagem { get; private set; }

        public Desconto(string cupom)
        {
            Cupom = cupom;
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