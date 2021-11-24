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
            string novePrimeirosDigitosCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;
            novePrimeirosDigitosCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(novePrimeirosDigitosCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            digito = resto.ToString();
            novePrimeirosDigitosCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(novePrimeirosDigitosCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}