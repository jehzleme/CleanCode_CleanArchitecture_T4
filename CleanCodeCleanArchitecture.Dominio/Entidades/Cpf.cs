using System.Text.RegularExpressions;

namespace CleanCodeCleanArchitecture.Dominio
{
    public class Cpf
    {
        public string Numero { get; private set; }
        public bool Valido { get; private set; }

        public Cpf(string cpf)
        {
            Numero = cpf;
            Valido = ValidarCpf(cpf);
        }

        private bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string digito;
            int resto;

            cpf = Regex.Replace(cpf, "[\\D]", "");

            if (cpf.Length != 11) return false;

            var novePrimeirosDigitosCpf = cpf.Substring(0, 9);

            MultiplicarDigitos(multiplicador1, novePrimeirosDigitosCpf, out resto);
            digito = resto.ToString();
            novePrimeirosDigitosCpf += digito;

            MultiplicarDigitos(multiplicador2, novePrimeirosDigitosCpf, out resto);
            digito += resto.ToString();
            return cpf.EndsWith(digito);
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