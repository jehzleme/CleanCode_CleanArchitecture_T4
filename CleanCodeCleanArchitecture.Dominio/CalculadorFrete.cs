using CleanCodeCleanArchitecture.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeCleanArchitecture.Dominio
{
    public class CalculadorFrete
    {
        public const double VALOR_MINIMO_FRETE = 10.00;

        public static double Calcular(List<PedidoItem> pedidoItens, double distancia)
        {
            double valorFrete = 0;
            foreach (var item in pedidoItens)
            {
                valorFrete = item.Item.CalcularVolume() * (item.Item.CalcularDensidade() / 100) * item.Quantidade;
            }
            valorFrete *= distancia;

            return valorFrete < VALOR_MINIMO_FRETE ? VALOR_MINIMO_FRETE : valorFrete;
        }
    }
}
