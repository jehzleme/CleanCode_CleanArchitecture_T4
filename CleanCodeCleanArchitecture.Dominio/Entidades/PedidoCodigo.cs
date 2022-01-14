using System;
using System.Text;

namespace CCCA.Dominio.Entidades
{
    public class PedidoCodigo
    {
        public string Numero { get; private set; }

        public PedidoCodigo(DateTime data, int sequencia)
        {
            Numero = GerarCodigoPedido(data, sequencia);
        }

        private string GerarCodigoPedido(DateTime data, int sequencia)
        {
            var ano = data.Year.ToString();
            sequencia.ToString().PadLeft(8, '0');

            var sb = new StringBuilder();
            sb.Append(ano);
            sb.Append(sequencia);

            return sb.ToString();
        }
    }
}