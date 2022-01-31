using System;
using System.Text.RegularExpressions;

namespace CCCA.Dominio.Entidades
{
    public class Cupom
    {
        public string Descricao { get; private set; }
        public double Desconto { get; private set; }
        public DateTime? InicioVigencia { get; private set; }
        public DateTime? FinalVigencia { get; private set; }
        public bool Valido { get; private set; }

        public Cupom(string cupom, DateTime? inicioVigencia, DateTime? finalVigencia)
        {
            Descricao = cupom;
            InicioVigencia = inicioVigencia;
            FinalVigencia = finalVigencia;
            Valido = ValidarCupom(this);
            Desconto = ObterDesconto(cupom);
        }

        public double CalcularDesconto(double valor)
        {
            if (!Valido) return 0;
                return (valor * Desconto) / 100;
        }

        private double ObterDesconto(string cupom)
        {
            var digitosCupom = Regex.Replace(cupom, "[aA-zZ]", "");
            var desconto = double.Parse(digitosCupom);
            return desconto;
        }

        private bool ValidarCupom(Cupom cupom)
        {
            if (InicioVigencia == null && FinalVigencia == null) return true;
            return DateTime.UtcNow >= cupom.InicioVigencia && DateTime.UtcNow <= cupom.FinalVigencia;
        }
    }
}