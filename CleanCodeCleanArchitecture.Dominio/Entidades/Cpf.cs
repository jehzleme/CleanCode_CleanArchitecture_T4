using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CCCA.Dominio.Entidades
{
    public class Cpf
    {
        public string Numero { get; private set; }

        public Cpf(string cpf)
        {
            if (!ValidarCpf(cpf)) { throw new Exception("CPF inválido."); }
            Numero = cpf;
        }

        private bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return false;
            var digitosCpf = Regex.Replace(cpf, "[\\D]", "");
            if (digitosCpf.Length != 11) return false;
            if (VerificarDigitosRepetidos(digitosCpf)) return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var novePrimeirosDigitosCpf = digitosCpf.Substring(0, 9);

            MultiplicarDigitos(multiplicador1, novePrimeirosDigitosCpf, out int resto);
            var digito = resto.ToString();
            novePrimeirosDigitosCpf += digito;

            MultiplicarDigitos(multiplicador2, novePrimeirosDigitosCpf, out resto);
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }

        private static bool VerificarDigitosRepetidos(string cpf)
        {
            return cpf.All(caracter => caracter == cpf[0]);
        }

        private static void MultiplicarDigitos(int[] multiplicador, string novePrimeirosDigitosCpf, out int resto)
        {
            var soma = 0;

            for (int i = 0; i < multiplicador.Length; i++)
                soma += int.Parse(novePrimeirosDigitosCpf[i].ToString()) * multiplicador[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
        }
    }
}