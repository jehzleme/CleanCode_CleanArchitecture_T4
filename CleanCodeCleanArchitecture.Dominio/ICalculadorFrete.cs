using CCCA.Dominio.Entidades;
using System.Collections.Generic;

namespace CCCA.Dominio
{
    public interface ICalculadorFrete
    {
        double Calcular(List<PedidoItem> pedidoItens, double distancia);
    }
}