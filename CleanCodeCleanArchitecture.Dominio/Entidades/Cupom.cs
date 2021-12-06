using System;
using System.Text.RegularExpressions;

namespace CleanCodeCleanArchitecture.Dominio.Entidades
{
    public class Cupom
    {
        public string Descricao { get; private set; }
        public double Porcentagem { get; private set; }
        public DateTime InicioVigencia { get; private set; }
        public DateTime FinalVigencia { get; private set; }
        public bool Valido { get; private set; }

        public Cupom(string cupom, DateTime inicioVigencia, DateTime finalVigencia)
        {
            Descricao = cupom;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
            Valido = ValidarCupom(this);
            Porcentagem = CalcularPorcentagem(cupom);
        }

        private double CalcularPorcentagem(string cupom)
        {
            var digitosCupom = Regex.Replace(cupom, "[aA-zZ]", "");
            var desconto = double.Parse(digitosCupom);
            return desconto;
        }

        private bool ValidarCupom(Cupom cupom)
        {
            return DateTime.UtcNow >= cupom.InicioVigencia && DateTime.UtcNow <= cupom.FinalVigencia;
        }
    }
}